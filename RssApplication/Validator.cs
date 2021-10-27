using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssApplication
{
	public class Validator { 

		public static bool TextBoxIsPresent(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				textBox.Focus();
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
