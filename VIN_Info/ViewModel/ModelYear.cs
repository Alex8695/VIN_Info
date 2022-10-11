using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_Info.Model
{
	public class ModelYear
	{
		public char As_Char {
			get {
				return (this.isValid)
					? this.modelYear	
					: ' ';
			}
		}

		public string As_String {
			get {
				return (this.isValid)
					? this.modelYear.ToString()
					: string.Empty;
			}
		}


		private char modelYear;
		private bool isValid;


		internal ModelYear(char model_year,out bool is_valid)
		{
			this.isValid = 
				char.IsLetterOrDigit(model_year);

			is_valid = this.isValid;

			this.modelYear = model_year;


		}
	}
}
