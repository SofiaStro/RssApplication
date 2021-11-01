using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Models.Exceptions;

namespace RssApplication
{
	public class Validator
	{

		public static bool TextBoxIsPresent(TextBox textBox, string msg)
		{
			if (textBox.Text == "")
			{
				textBox.Focus();
				throw new ValidatorException(msg);
			}
			return true;
		}
		public static bool ComboBoxIsPresent(ComboBox comboBox, string msg)
		{
			if (comboBox.Text == "")
			{
				comboBox.Focus();
				throw new ValidatorException(msg);
			}
			return true;
		}

		public static bool IsSelected(ListBox listBox, string msg)
        {
			if (listBox.SelectedIndex == -1)
			{
				throw new ValidatorException(msg);
			}
			return true;
        }

		public static bool IsSelected(ListView listView, string msg)
		{
			if(listView.SelectedItems.Count  == 0)
            {
				throw new ValidatorException(msg);
            }
			return true;
		}

		public static bool IsValidUrl(string url)
		{
            try
            {
                new XmlDocument().Load(url);

                return true;
            }
            catch (Exception)
            {
                string msg = "Angiven URL är inte giltig, vänligen ange en RSS-url.";
                throw new ValidatorException(msg);
            }
		}

		public static bool FileNameExist(string fileName)
        {
            if(fileName == "")
            {
				string msg = "Ett fel har inträffat, vänligen kontakta support.";
				throw new ValidatorException(msg);
			}
			return true;
        }

		public static bool CategoryNotExist(List<string> list, string input)
        {
			string msg = "Denna kategori finns redan.";
			foreach (string categoryName in list)
			{
				if (categoryName.Equals(input))
				{
					throw new ValidatorException(msg);
				}
			}
			return true;
		}
	}
}
