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
using System.Xml.Serialization;

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
			FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		/// <summary>
		/// Заполнение листбокса с информацией об изданиях
		/// </summary>
		private void FillingEditionListBox()
		{
			EditionListBox.Items.Clear();
			foreach (EditionBase edition in _editionList)
			{
				EditionListBox.Items.Add(edition);
				//TODO: nameof
				EditionListBox.DisplayMember = "Info";
			}
		}

		/// <summary>
		/// Нажатие на кнопку открытия файла
		/// </summary>
		private void OpenFileButton_Click(object sender, EventArgs e)
		{
			if (MainOpenFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}	
			string filename = MainOpenFileDialog.FileName;

			try
			{
				_editionList = Serializer.OpenFile(filename);
				FillingEditionListBox();
				MessageBox.Show("File opened");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message + "Incorrect file format");
			}
		}

		/// <summary>
		/// Нажатие на на кнопку добавления объекта
		/// </summary>
		private void AddObjectButton_Click(object sender, EventArgs e)
		{	
			AddObjectForm addObjectForm = new AddObjectForm();

			if (addObjectForm.ShowDialog() == DialogResult.OK)
			{
				_editionList.Add(addObjectForm.Edition);
				FillingEditionListBox();
			}
		}

		/// <summary>
		/// Нажатие на кнопку сохранения в файл
		/// </summary>
		private void SaveFileButton_Click(object sender, EventArgs e)
		{
			if (MainSaveFileDialog.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}
			string filename = MainSaveFileDialog.FileName;

			try
			{
				Serializer.SaveFile(filename, _editionList);
				MessageBox.Show("File saved");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message + "Please do it again");
			}
		}

		/// <summary>
		/// Удаление издания через Листбокс при назатии на кнопку Remove
		/// </summary>
		private void RemoveObjectButton_Click(object sender, EventArgs e)
		{
			if (EditionListBox.SelectedIndex == -1)
			{
				return;
			}
			_editionList.Remove((EditionBase)EditionListBox.SelectedItem);
			FillingEditionListBox();
		}

		/// <summary>
		/// Нажатие на кнопку поиска
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			SearchDataForm searchDataForm = new SearchDataForm();

			if (searchDataForm.ShowDialog() == DialogResult.OK)
			{
				if (searchDataForm.SearchWorlds.Count == 0)
				{
					searchDataForm.Close();
					return;
				}
				EditionListBox.Items.Clear();

				foreach (EditionBase edition in _editionList)
				{
					foreach (var searchWorld in searchDataForm.SearchWorlds)
					{
						if (!edition.Info.Contains(searchWorld)) continue;

						EditionListBox.Items.Add(edition);
						//TODO: nameof
						EditionListBox.DisplayMember = "Info";
					}
				}
			}
			searchDataForm.Close();
		}

		/// <summary>
		/// Нажатие на кнопку cброса поиска
		/// </summary>
		private void SkipSearchButton_Click(object sender, EventArgs e)
        {
			FillingEditionListBox();
		}
    }
}

