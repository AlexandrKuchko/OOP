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

namespace View
{
	/// <summary>
	/// Форма добавления объекта
	/// </summary>
	public partial class AddObjectForm : Form
	{
		/// <summary>
		/// Выходной результат (введённое издание)
		/// </summary>
		public List<EditionBase> ReturnList = new List<EditionBase>();

		/// <summary>
		/// Окна для заполнения свойств
		/// </summary>
		private TextBox[] _properties = null;

		/// <summary>
		/// Подписи для окон для заполнения свойств
		/// </summary>
		private Label[] _propertiesLabel = null;

		/// <summary>
		/// Максимальное количество свойств в классе
		/// </summary>
		private const int _max = 10;

		/// <summary>
		/// Ширина ячейки для заполнения
		/// </summary>
		private const int _width = 120;

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
				_properties[i].Text = "";
				_properties[i].Visible = false;
				_propertiesLabel[i].Visible = false;
			}
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
				_propertiesLabel[i].Text = propertyInfo[i].Name;
				_propertiesLabel[i].Visible = true;
			}
		}

		/// <summary>
		/// Рандомное заполнение полей для атрибутов
		/// </summary>
		private void PropetiesRandom(EditionBase editionBase)
		{
			for (int i = 0; i < editionBase.GetType().GetProperties().Length; i++)
			{
				_properties[i].Text = "Random" + editionBase.GetType().GetProperties()[i].Name;
				if (editionBase.GetType().GetProperties()[i].Name == "Year" ||
						editionBase.GetType().GetProperties()[i].Name == "PageLimits")
				{
					_properties[i].Text = "100";
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
				_properties[i].Leave += new System.EventHandler(this.TextBoxLeave);
				_properties[i].Text = "";
				_properties[i].Location = new System.Drawing.Point(50, 70 + i * (_height + 10));
				_properties[i].Size = new System.Drawing.Size(_width, _height);
				_properties[i].Visible = false;
				this.Controls.Add(_properties[i]);

				_propertiesLabel[i] = new Label();
				_propertiesLabel[i].Text = "";
				_propertiesLabel[i].Location = new System.Drawing.Point(175, 74 + i * (_height + 10));
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
			switch ((string)EditionComboBox.SelectedItem)
			{
				case "Book":
				{
					Book book = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					PropetiesRename(book);
					return;
				}
				case "Thesis":
				{
					Thesis thesis = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					PropetiesRename(thesis);
					return;
				}
				case "Collection":
				{
					Collection collection = new Collection("A", "A", "A", "A", "100", "1997");
					PropetiesRename(collection);
					return;
				}
				case "Magazine":
				{
					Magazine magazine = new Magazine("A", "A", "A", "A", "A", "1", "1");
					PropetiesRename(magazine);
					return;
				}
			}
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
				MessageBox.Show(exception.Message + " Please enter again.");
			}
		}

		/// <summary>
		/// При покидании текстбокса
		/// </summary>
		private void TextBoxLeave(object sender, EventArgs e)
		{
			var textBox = (TextBox)sender;
			int index = Array.IndexOf(_properties, textBox);

			switch ((string)EditionComboBox.SelectedItem)
			{
				case "Book":
				{
					Book book = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					AssigningValue(book, _propertiesLabel[index].Text, textBox.Text);
					break;
				}
				case "Thesis":
				{
					Thesis thesis = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					AssigningValue(thesis, _propertiesLabel[index].Text, textBox.Text);
					break;
				}
				case "Collection":
				{
					Collection collection = new Collection("A", "A", "A", "A", "100", "1997");
					AssigningValue(collection, _propertiesLabel[index].Text, textBox.Text); 
					break;
				}
				case "Magazine":
				{
					Magazine magazine = new Magazine("A", "A", "A", "A", "A", "1", "1");
					AssigningValue(magazine, _propertiesLabel[index].Text, textBox.Text);
					break;
				}
			}
		}

		/// <summary>
		/// При нажатии кнопки добавить данные
		/// </summary>
		private void AddDataButton_Click(object sender, EventArgs e)
		{
			int count = 0;
			while (_propertiesLabel[count].Visible == true)
            {
				count++;
            }
			try
			{
				switch ((string)EditionComboBox.SelectedItem)
				{
					case "Book":
					{
						Book book = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
						for (int i = 0; i < count; i++)
						{
							AssigningValue(book, _propertiesLabel[i].Text, _properties[i].Text);
						}
						ReturnList.Add(book);
						break;
					}
					case "Thesis":
					{
						Thesis thesis = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
						for (int i = 0; i < count; i++)
						{
							AssigningValue(thesis, _propertiesLabel[i].Text, _properties[i].Text);
						}
						ReturnList.Add(thesis);
						break;
					}
					case "Collection":
					{
						Collection collection = new Collection("A", "A", "A", "A", "100", "1997");
						for (int i = 0; i < count; i++)
						{
							AssigningValue(collection, _propertiesLabel[i].Text, _properties[i].Text);
						}
						ReturnList.Add(collection);
						break;
					}
					case "Magazine":
					{
						Magazine magazine = new Magazine("A", "A", "A", "A", "A", "1", "1");
						for (int i = 0; i < count; i++)
						{
							AssigningValue(magazine, _propertiesLabel[i].Text, _properties[i].Text);
						}
						ReturnList.Add(magazine);
						break;
					}
				}
				foreach (TextBox textbox in _properties)
				{
					textbox.Text = "";
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message + " Please enter again.");
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
			switch ((string)EditionComboBox.SelectedItem)
			{
				case "Book":
				{
					Book book = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					PropetiesRandom(book);
					return;
				}
				case "Thesis":
				{
					Thesis thesis = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					PropetiesRandom(thesis);
					return;
				}
				case "Collection":
				{
					Collection collection = new Collection("A", "A", "A", "A", "100", "1997");
					PropetiesRandom(collection);
					return;
				}
				case "Magazine":
				{
					Magazine magazine = new Magazine("A", "A", "A", "A", "A", "1", "1");
					PropetiesRandom(magazine);
					return;
				}
			}
		}
    }
}
