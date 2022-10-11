using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_Info.Model
{
	public class SerialNumber
	{
		public string As_String {
			get {
				return (isValid)
					? this.chars.ToString()
					: string.Empty;
			}
		}
		public int As_Int {
			get {
				return (isValid) 
					? int.Parse(chars.ToString()) 
					: 0; } }

		private char[] chars;
		private bool isValid = false;

		internal SerialNumber(string serial_str, out bool is_valid)
		{
			is_valid = (serial_str == null) 
				? false 
				: serial_str.Length == 6;

			if (isValid)
			{
				chars =
					serial_str
					.ToCharArray();

				for (int i = 0; i < chars.Length; i++)
				{
					if (!char.IsDigit(chars[i]))
					{
						is_valid = false;
					}
				}
			}
			this.isValid = is_valid;		
		}
	}
}
