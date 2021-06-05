﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма для ввода данных для поиска
    /// </summary>
    public partial class SearchDataForm : Form
    {
        /// <summary>
        /// Список со словами для поиска
        /// </summary>
        public List<string> SearchWorlds { get; private set; }

        /// <summary>
        /// При инициализации формы
        /// </summary>
        public SearchDataForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// При нажатии кнопки поиска
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchWorlds == null)
            {
                SearchWorlds = new List<string>();
            }
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && control.Text != "")
                {
                    SearchWorlds.Add(control.Text);
                }
            }
        }

        /// <summary>
        /// При нажатии кнопки отмены
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
