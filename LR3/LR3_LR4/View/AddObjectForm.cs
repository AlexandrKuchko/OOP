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
		/// Ключ выхода из метода присваивания
		/// </summary>
		private bool _keyExit = false;

		/// <summary>
		/// Ключ выхода из метода после рандома
		/// </summary>
		private bool _keyClearExit = false;

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string _keyBook = "Book";

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string _keyCollection = "Collection";

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string _keyThesis = "Thesis";

		/// <summary>
		/// Строковый ключ
		/// </summary>
		private const string _keyMagazine = "Magazine";

		/// <summary>
		/// Выходное издание
		/// </summary>
		public EditionBase Edition = null;

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
		private const int _max = 10;

		/// <summary>
		/// Ширина ячейки для заполнения
		/// </summary>
		private const int _width = 200;

		/// <summary>
		/// Высота ячейки для заполнения
		/// </summary>
		private const int _height = 20;

		/// <summary>
		/// При инициализации формы
		/// </summary>
		public AddObjectForm()
		{
			InitializeComponent();

			#if !DEBUG
			CreateRandomDataButton.Visible = false;
			#endif
		}

		/// <summary>
		/// Очитска полей для заполнения
		/// </summary>
		private void Clear_Propeties()
		{
			for (int i = 0; i < _max; i++)
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
		private List<PropertyInfo> PropertyInfo(EditionBase editionBase)
		{
			List<PropertyInfo> propertyInfo = new List<PropertyInfo>();
			foreach (PropertyInfo info in editionBase.GetType().GetProperties())
			{
				if (info.Name == "Info" || info.Name == "Item")
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
		private void PropetiesRename(EditionBase editionBase)
		{
			Clear_Propeties();
			var propertyInfo = PropertyInfo(editionBase);
			for (int i = 0; i < propertyInfo.Count; i++)
			{
				_properties[i].Visible = true;
				_keyLabel.Add(propertyInfo[i].Name);
				_propertiesLabel[i].Text = Regex.Replace(propertyInfo[i].Name, @"([A-Z])", " $1").Trim().ToLower();
				_propertiesLabel[i].Visible = true;
			}
		}

		/// <summary>
		/// Рандомное заполнение полей для атрибутов
		/// </summary>
		private void PropetiesRandom(EditionBase editionBase)
		{
			var propertyInfo = PropertyInfo(editionBase);
			for (int i = 0; i < propertyInfo.Count; i++)
			{
				if (_keyLabel[i] == "Year" ||
						_keyLabel[i] == "PageLimits")
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
			Type ourtype = typeof(EditionBase);
			IEnumerable<Type> listClass = Assembly.GetAssembly(ourtype).GetTypes().Where(type => type.IsSubclassOf(ourtype));
			List<string> listNameClass = new List<string>();
			foreach (Type edition in listClass)
			{
				listNameClass.Add(edition.Name);
			}

			EditionComboBox.DataSource = listNameClass;

			_properties = new TextBox[_max];
			_propertiesLabel = new Label[_max];

			for (int i = 0; i < _max; i++)
			{
				_properties[i] = new TextBox();
				_properties[i].TextChanged += new System.EventHandler(this.TextBoxTextChange);
				_properties[i].Text = "";
				_properties[i].Location = new System.Drawing.Point(50, 70 + i * (_height + 10));
				_properties[i].Size = new System.Drawing.Size(_width, _height);
				_properties[i].Visible = false;
				this.Controls.Add(_properties[i]);

				_propertiesLabel[i] = new Label();
				_propertiesLabel[i].Text = "";
				_propertiesLabel[i].Location = new System.Drawing.Point(255, 74 + i * (_height + 10));
				_propertiesLabel[i].Size = new System.Drawing.Size(_width, _height);
				_propertiesLabel[i].Visible = false;
				this.Controls.Add(_propertiesLabel[i]);
			}
		}


		/// <summary>
		/// При выборе нового значения в списке
		/// </summary>
		private void EditionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			EditionBase tmpEdition = null;
			switch ((string)EditionComboBox.SelectedItem)
			{
				case _keyBook:
				{
					tmpEdition = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					break;
				}
				case _keyThesis:
				{
					tmpEdition = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					break;
				}
				case _keyCollection:
				{
					tmpEdition = new Collection("A", "A", "A", "A", "100", "1997");
					break;
				}
				case _keyMagazine:
				{
					tmpEdition = new Magazine("A", "A", "A", "A", "A", "1", "1");
					break;
				}
			}
			PropetiesRename(tmpEdition);
		}

		/// <summary>
		/// Присвоение значения свойству класса 
		/// </summary>
		private void AssigningValue(EditionBase editionBase, string name, string value)
		{
			try
			{
				editionBase[name] = value;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.InnerException.Message + " Please enter again.");
				_keyExit = true;
			}
		}

		/// <summary>
		/// При покидании текстбокса
		/// </summary>5
		private void TextBoxTextChange(object sender, EventArgs e)
		{
			if (_keyClearExit == true)
			{
				return;
			}
			var textBox = (TextBox)sender;
			int index = Array.IndexOf(_properties, textBox);
            EditionBase tmpEdition = null;
			switch ((string)EditionComboBox.SelectedItem)
			{
				case _keyBook:
				{
                    tmpEdition = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					break;
				}
				case _keyThesis:
				{
                    tmpEdition = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					break;
				}
				case _keyCollection:
				{
                    tmpEdition = new Collection("A", "A", "A", "A", "100", "1997");
                    break;
				}
				case _keyMagazine:
				{
                    tmpEdition = new Magazine("A", "A", "A", "A", "A", "1", "1");
					break;
				}
			}
            AssigningValue(tmpEdition, _keyLabel[index], textBox.Text);
		}

		/// <summary>
		/// При нажатии кнопки добавить данные
		/// </summary>
		private void OKButton_Click(object sender, EventArgs e)
		{
			_keyExit = false;
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
			EditionBase tmpEdition = null;
			try
			{
				switch ((string)EditionComboBox.SelectedItem)
				{
					case _keyBook:
					{
						tmpEdition = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
						break;
					}
					case _keyThesis:
					{
						tmpEdition = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
						break;
					}
					case _keyCollection:
					{
						tmpEdition = new Collection("A", "A", "A", "A", "100", "1997");
						break;
					}
					case _keyMagazine:
					{
						tmpEdition = new Magazine("A", "A", "A", "A", "A", "1", "1");
						break;
					}
				}
				for (int i = 0; i < count; i++)
				{
					AssigningValue(tmpEdition, _keyLabel[i], _properties[i].Text);
					if (_keyExit == true)
					{
						DialogResult = DialogResult.None;
						return;
					}
				}
				Edition = tmpEdition;
				DialogResult = DialogResult.OK;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message + " Please enter again.");
				DialogResult = DialogResult.None;
				return;
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
			EditionBase tmpEdition = null;
			if (_properties[0].Visible == false)
            {
				return;
            }
			switch ((string)EditionComboBox.SelectedItem)
			{
				case _keyBook:
				{
					tmpEdition = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					break;
				}
				case _keyThesis:
				{
					tmpEdition = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					break;
				}
				case _keyCollection:
				{
					tmpEdition = new Collection("A", "A", "A", "A", "100", "1997");
					break;
				}
				case _keyMagazine:
				{
					tmpEdition = new Magazine("A", "A", "A", "A", "A", "1", "1");
					break;
				}
			}
			PropetiesRandom(tmpEdition);
		}
    }
}
