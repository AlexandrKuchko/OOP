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

namespace View
{
	/// <summary>
	/// Главная форма
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Список с изданиями
		/// </summary>
		private List<EditionBase> _editionList = new List<EditionBase>();

		/// <summary>
		/// При инициализации формы
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Нажатие на на кнопку открытия файла
		/// </summary>
		private void OpenFile_Click(object sender, EventArgs e)
		{
			/*
			List<EditionBase> editionListSer = new List<EditionBase>();
			editionListSer.Add(new Book("A", "A", "A", "A", "A", "A", "1998", "100", "A"));
			editionListSer.Add(new Collection("A", "A", "A", "A", "100", "1997"));
			editionListSer.Add(new Thesis("A", "A", "A", "A", "A", "A", "100", "1997"));
			editionListSer.Add(new Magazine("A", "A", "A", "A", "A", "100", "1977"));
			
			try
			{
				using (Stream stream = File.Open(@"C:\Users\sasha\iCloudDrive\Магистратура флешка\4 семестр\ООП\OOP\LR3\Doc3.xml", FileMode.Create))
				{
					BinaryFormatter bin = new BinaryFormatter();
					bin.Serialize(stream, editionListSer);
					editionListSer.Clear();
				}
			}
			catch (IOException)
			{
			}
			*/

			if (MainOpenFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}	
			string filename = MainOpenFileDialog.FileName;

			try
			{
				using (Stream stream = File.Open(filename, FileMode.Open))
				{
					BinaryFormatter bin = new BinaryFormatter();
					_editionList = (List<EditionBase>)bin.Deserialize(stream);
				}
			}
			catch (IOException)
			{
			}
			EditionListBox.Items.Clear();
			foreach (EditionBase edition in _editionList)
			{
				EditionListBox.Items.Add(edition.Info());
			}
			MessageBox.Show("Файл открыт");

			/*
			var writer = new
			System.Xml.Serialization.XmlSerializer(typeof(List<EditionBase>), new Type[] { typeof(Book), 
				typeof(Collection), typeof(Thesis), typeof(Magazine) });
			using (var file = System.IO.File.Create(@"C:\Users\sasha\iCloudDrive\Магистратура флешка\4 семестр\ООП\OOP\LR3\Doc2.xml"))
			{
				writer.Serialize(file, editionList);
				file.Close();
			}
			*/

			/*
			var reader = new System.Xml.Serialization.XmlSerializer(typeof(EditionBase), 
				new Type[] { typeof(Book), typeof(Collection), typeof(Thesis), typeof(Magazine) });
			var file = new System.IO.StreamReader(filename);
			editionList = (List<EditionBase>)reader.Deserialize(file);
			
			
			foreach(EditionBase edition in editionList)
			{
				EditionListBox.Items.Add(edition.Info());
			}
			*/
		}

		private void AddObjectButton_Click(object sender, EventArgs e)
		{	
			AddObjectForm addObjectForm = new AddObjectForm();

			if (addObjectForm.ShowDialog() == DialogResult.OK)
			{
				_editionList.Add(addObjectForm.ReturnList[0]);

				EditionListBox.Items.Clear();
				foreach (EditionBase edition in _editionList)
				{
					EditionListBox.Items.Add(edition.Info());
				}
			}
			addObjectForm.Close();
		}
	}
}

