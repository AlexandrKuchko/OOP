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
    /// Класс для сериализции
    /// </summary>
    public static class Serializer
    {
        // <summary>
        /// Сериализатор
        /// </summary>
        private static readonly XmlSerializer _xmlSerializer = 
            new XmlSerializer(typeof(List<EditionBase>), 
                new[] 
                {
                    typeof(Book),
                    typeof(Thesis),
                    typeof(Collection), 
                    typeof(Magazine)
                });

		/// <summary>
		/// Cохранение в файл
		/// </summary>
		public static void SaveFile(string path, List<EditionBase> editionList)
		{
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				_xmlSerializer.Serialize(fs, editionList);
			}
		}

		/// <summary>
		/// Открытие файла
		/// </summary>
		public static List<EditionBase> OpenFile(string path)
		{
			List<EditionBase> editionList = new List<EditionBase>();
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				editionList = (List<EditionBase>)_xmlSerializer.Deserialize(fs);
			}
			return editionList;
		}
	}
}
