using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models.Exceptions;

namespace RssApplication
{
	public class Validator { 

		public static bool TextBoxIsPresent(TextBox textBox, string textBoxName)
		{
			if (textBox.Text == "")
			{
				string msg = textBoxName + " måste anges";
				//throw new ValidatorException(msg);
				return false;
			}
			return true;
		}
		public static bool ComboBoxIsPresent(ComboBox comboBox)
		{
			if (comboBox.Text == "")
			{
				comboBox.Focus();
				return false;
			}
			return true;
		}
	}
}
