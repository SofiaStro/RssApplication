using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Models.Exceptions;

namespace RssApplication
{
	public class Validator
	{

		public static bool TextBoxIsPresent(TextBox textBox, string textBoxName)
		{
			if (textBox.Text == "")
			{
				string msg = textBoxName + " måste anges";
				throw new ValidatorException(msg);
			}
			return true;
		}
		public static bool ComboBoxIsPresent(ComboBox comboBox)
		{
			if (comboBox.Text == "")
			{
				comboBox.Focus();
			}
			return true;
		}

		public static bool IsValidRSS(string url)
		{
            try
            {
                new XmlDocument().Load(url);

                return true;
            }
            catch (Exception)
            {
                string msg = url + " är inte giltig";
                throw new ValidatorException(msg);
            }
		}
	}
}
