using System;
using LibraryLR3LR4;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Text.RegularExpressions;

namespace View
{
	/// <summary>
	/// Форма добавления объекта
	/// </summary>
	public partial class AddObjectForm : Form
	{
        /// <summary>
		/// Ключ выхода из метода валидации при принудителшьной очистке
		/// </summary>
		private bool _keyClearExit = false;

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string KeyBook = nameof(Book);

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string KeyCollection = nameof(Collection);

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string KeyThesis = nameof(Thesis);

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string KeyMagazine = nameof(Magazine);

		/// <summary>
		/// Выходное издание
		/// </summary>
		public EditionBase Edition { get; private set; }

		/// <summary>
		/// Окна для заполнения свойств
		/// </summary>
		private TextBox[] _properties = null;

		/// <summary>
		/// Подписи для окон для заполнения свойств
		/// </summary>
		private Label[] _propertiesLabel = null;

		/// <summary>
		/// Ключи для распознавания нужных свойств в классах
		/// </summary>
		private List<string> _keyLabel = new List<string>();

		/// <summary>
		/// Максимальное количество свойств в классе
		/// </summary>
		private const int MaximumPropertiesNumber = 10;

		/// <summary>
		/// При инициализации формы
		/// </summary>
		public AddObjectForm()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			#if !DEBUG
			CreateRandomDataButton.Visible = false;
			#endif
		}

		/// <summary>
		/// Очитска полей для заполнения
		/// </summary>
		private void ClearPropeties()
		{
			for (int i = 0; i < MaximumPropertiesNumber; i++)
			{
				_keyClearExit = true;
				_properties[i].Text = "";
				_properties[i].Visible = false;
				_propertiesLabel[i].Visible = false;
			}
			_keyLabel.Clear();
			_keyClearExit = false;
		}

		/// <summary>
		/// Получение листа с информацией о свойствах класса без Info
		/// </summary>
		/// <param name="editionBase">Объект нужного издания 
		/// по ссылке на EditionBase</param>
		private List<PropertyInfo> PropertyInfo(EditionBase editionBase)
		{
			var propertyInfo = new List<PropertyInfo>();
			foreach (var info in editionBase.GetType().GetProperties())
			{
				if (info.Name == nameof(EditionBase.Info) || info.Name == "Item")
				{
					continue;
				}
				propertyInfo.Add(info);
			}
			return propertyInfo;
		}

		/// <summary>
		/// Перезаполнение полей для атрибутов
		/// </summary>
		/// <param name="editionBase">Объект нужного издания 
		/// по ссылке на EditionBase</param>
		private void PropetiesRename(EditionBase editionBase)
		{
			ClearPropeties();
			var propertyInfo = PropertyInfo(editionBase);
			for (int i = 0; i < propertyInfo.Count; i++)
			{
				_properties[i].Visible = true;
				_keyLabel.Add(propertyInfo[i].Name);
				_propertiesLabel[i].Text = Regex.Replace
					(propertyInfo[i].Name, @"([A-Z])", " $1").Trim().ToLower();
				_propertiesLabel[i].Visible = true;
			}
		}

		/// <summary>
		/// Рандомное заполнение полей для атрибутов
		/// </summary>
		/// <param name="editionBase">Объект нужного издания 
		/// по ссылке на EditionBase</param>
		private void PropetiesRandom(EditionBase editionBase)
		{
			var propertyInfo = PropertyInfo(editionBase);
			for (int i = 0; i < propertyInfo.Count; i++)
			{
				if (_keyLabel[i] == nameof(editionBase.Year) ||
						_keyLabel[i] == nameof(editionBase.PageLimits))
				{
					_properties[i].Text = "100";
				}
				else
				{
					_properties[i].Text = "Random" + _propertiesLabel[i].Text;
				}
			}
		}

		/// <summary>
		/// При загрузке формы
		/// </summary>
		private void AddObjectForm_Load(object sender, EventArgs e)
		{
			//EditionComboBox.Items.Clear();
			//Получение списка дочерник классов
			var typeOfEditionBase = typeof(EditionBase);
			var listClass = Assembly.GetAssembly(typeOfEditionBase)
				.GetTypes().Where(type => type.IsSubclassOf(typeOfEditionBase));
			var listNameClass = new List<string>();
			foreach (Type edition in listClass)
			{
				listNameClass.Add(edition.Name);
			}

			EditionComboBox.DataSource = listNameClass;

			_properties = new TextBox[MaximumPropertiesNumber];
			_propertiesLabel = new Label[MaximumPropertiesNumber];

			for (int i = 0; i < MaximumPropertiesNumber; i++)
			{
				const int widthCell = 200;
                const int heightCell = 20;
				_properties[i] = new TextBox
				{
					Text = "",
					Location = new System.Drawing.Point(50, 70 + i * (heightCell + 10)),
					Size = new System.Drawing.Size(widthCell, heightCell),
					Visible = false
				};
				_properties[i].TextChanged += new System.EventHandler(this.TextBoxTextChange);

				this.Controls.Add(_properties[i]);

				_propertiesLabel[i] = new Label
				{
					Text = "",
					Location = new System.Drawing.Point(255, 74 + i * (heightCell + 10)),
					Size = new System.Drawing.Size(widthCell, heightCell),
					Visible = false
				};
				this.Controls.Add(_propertiesLabel[i]);
			}

			var tmpEdition = GetDefaultSelectedEdition();
			PropetiesRename(tmpEdition);
		}


		/// <summary>
		/// При выборе нового значения в списке
		/// </summary>
		private void EditionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			var tmpEdition = GetDefaultSelectedEdition();
			PropetiesRename(tmpEdition);
		}

		/// <summary>
		/// Присвоение значения свойству класса 
		/// </summary>
		/// <param name="editionBase">Объект нужного издания 
		/// по ссылке на EditionBase</param>
		/// <param name="name">Имя свойства для строкового индексатора</param>
		/// <param name="value">Присваиваемое свойству значение</param>
		/// <returns>Ключ, true - если возникла ошибка</returns>
		private bool AssigningValue(EditionBase editionBase, string name, string value)
		{
			try
			{
				editionBase[name] = value;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.InnerException.Message + " Please enter again.");
				return true;
			}

            return false;
        }

		/// <summary>
		/// При покидании текстбокса
		/// </summary>
		private void TextBoxTextChange(object sender, EventArgs e)
		{
			if (_keyClearExit)
			{
				return;
			}

			var textBox = (TextBox)sender;
			int index = Array.IndexOf(_properties, textBox);
			var tmpEdition = GetDefaultSelectedEdition();
			AssigningValue(tmpEdition, _keyLabel[index], textBox.Text);
		}

		/// <summary>
		/// Выдаёт нужный объект издания для присвания в 
		/// зависимости от выбранного значения в комбобоксе
		/// </summary>
		/// <returns>Нужный объект издания</returns>
		private EditionBase GetDefaultSelectedEdition()
		{
			return (string)EditionComboBox.SelectedItem switch
			{
				KeyBook => new Book(),
				KeyThesis => new Thesis(),
				KeyCollection => new Collection(),
				KeyMagazine => new Magazine(),
				_ => throw new ArgumentException("Incorrect selected item")
			};

		}

		/// <summary>
		/// При нажатии кнопки добавить данные
		/// </summary>
		private void OKButton_Click(object sender, EventArgs e)
		{
			if (_properties[0].Visible == false)
			{
				DialogResult = DialogResult.None;
				return;
			}

			int count = 0;

			while (_propertiesLabel[count].Visible == true)
			{
				count++;
			}

			var tmpEdition = GetDefaultSelectedEdition();

			try
			{
				for (int i = 0; i < count; i++)
				{
                    var isKeyExit = AssigningValue
						(tmpEdition, _keyLabel[i], _properties[i].Text);
                    if (!isKeyExit) continue;

                    DialogResult = DialogResult.None;
                    return;
                }
				Edition = tmpEdition;
				DialogResult = DialogResult.OK;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message + " Please enter again.");
				DialogResult = DialogResult.None;
			}
		}

		/// <summary>
		/// Закрытие формы
		/// </summary>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Заполнение формы случайными данными формы
		/// </summary>
		private void CreateRandomDataButton_Click(object sender, EventArgs e)
		{
			if (_properties[0].Visible == false)
			{
				return;
			}

			var tmpEdition = GetDefaultSelectedEdition();
			
			PropetiesRandom(tmpEdition);
		}
	}
}
