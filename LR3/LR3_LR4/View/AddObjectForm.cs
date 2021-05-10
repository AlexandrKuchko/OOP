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
				_properties[i].Text = "";
				_properties[i].Location = new System.Drawing.Point(50, 70 + i * (_height+10));
				_properties[i].Size = new System.Drawing.Size(_width, _height);
				_properties[i].Visible = false;
				this.Controls.Add(_properties[i]);

				_propertiesLabel[i] = new Label();
				_propertiesLabel[i].Text = "";
				_propertiesLabel[i].Location = new System.Drawing.Point(175, 74 + i * (_height+10));
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
					Clear_Propeties();
					Book book = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");

					for (int i = 0; i < book.GetType().GetProperties().Length; i++)
					{
						//Порядок табуляции
						// _properties[i].TabIndex = i + 1;
						_properties[i].Visible = true;
						_propertiesLabel[i].Text = book.GetType().GetProperties()[i].Name;
						_propertiesLabel[i].Visible = true;
					}
					return;
				}
				case "Thesis":
				{
					Clear_Propeties();
					Thesis thesis = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");

					for (int i = 0; i < thesis.GetType().GetProperties().Length; i++)
					{
						//Порядок табуляции
						// _properties[i].TabIndex = i + 1;
						_properties[i].Visible = true;
						_propertiesLabel[i].Text = thesis.GetType().GetProperties()[i].Name;
						_propertiesLabel[i].Visible = true;
					}
					return;
				}
				case "Collection":
				{
					Clear_Propeties();
					Collection collection = new Collection("A", "A", "A", "A", "100", "1997");

					for (int i = 0; i < collection.GetType().GetProperties().Length; i++)
					{
						//Порядок табуляции
						// _properties[i].TabIndex = i + 1;
						_properties[i].Visible = true;
						_propertiesLabel[i].Text = collection.GetType().GetProperties()[i].Name;
						_propertiesLabel[i].Visible = true;
					}
					return;
				}
				case "Magazine":
				{
					Clear_Propeties();
					Magazine magazine = new Magazine("A", "A", "A", "A", "A", "1", "1");

					for (int i = 0; i < magazine.GetType().GetProperties().Length; i++)
					{
						//Порядок табуляции
						// _properties[i].TabIndex = i + 1;
						_properties[i].Visible = true;
						_propertiesLabel[i].Text = magazine.GetType().GetProperties()[i].Name;
						_propertiesLabel[i].Visible = true;
					}
					return;
				}
			}
		}

		/// <summary>
		/// При нажатии кнопки ОК
		/// </summary>
		private void OkButton_Click(object sender, EventArgs e)
		{
			switch ((string)EditionComboBox.SelectedItem)
			{
				case "Book":
				{
					Book book = new Book("A", "A", "A", "A", "A", "A", "1", "1", "A");
					book.MainAuthor = _properties[0].Text;
					book.Type = _properties[1].Text;
					book.SecondAuthor = _properties[2].Text;
					book.Publisher = _properties[3].Text;
					book.AdditionalInformation = _properties[4].Text;
					book.Name = _properties[5].Text;
					book.Place = _properties[6].Text;
					book.Year = _properties[7].Text;
					book.PageLimits = _properties[8].Text;
					ReturnList.Add(book);
					return;
				}
				case "Thesis":
				{
					Thesis thesis = new Thesis("A", "A", "A", "A", "A", "A", "1", "1");
					thesis.Author = _properties[0].Text;
					thesis.Type = _properties[1].Text;
					thesis.Specialization = _properties[2].Text;
					thesis.University = _properties[3].Text;
					thesis.Name = _properties[4].Text;
					thesis.Place = _properties[5].Text;
					thesis.Year = _properties[6].Text;
					thesis.PageLimits = _properties[7].Text;
					ReturnList.Add(thesis);
					return;
				}
				case "Collection":
				{
					Collection collection = new Collection("A", "A", "A", "A", "100", "1997");
					collection.Publisher = _properties[0].Text;
					collection.NameOfConference = _properties[1].Text;
					collection.Name = _properties[2].Text;
					collection.Place = _properties[3].Text;
					collection.Year = _properties[4].Text;
					collection.PageLimits = _properties[5].Text;
					ReturnList.Add(collection);
					return;
				}
				case "Magazine":
				{
					Magazine magazine = new Magazine("A", "A", "A", "A", "A", "1", "1");
					magazine.Founder = _properties[0].Text;
					magazine.Type = _properties[1].Text;
					magazine.MainEditor = _properties[2].Text;
					magazine.Name = _properties[3].Text;
					magazine.Place = _properties[4].Text;
					magazine.Year = _properties[5].Text;
					magazine.PageLimits = _properties[6].Text;
					ReturnList.Add(magazine);
					return;
				}
			}
		}

		/// <summary>
		/// Закрытие формы
		/// </summary>
		private void CancelButton_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}
