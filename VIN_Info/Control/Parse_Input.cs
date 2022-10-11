using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VIN_Info.Control
{
	class Parse_Input
	{


		internal static char[] Get_VIN_Chars(string in_text)
		{
			string _input;
			char[] _out;

			_input =
				(in_text == null)
				? string.Empty
				: in_text.ToUpper();

			if (!VIN_Regex.Try_Get_VIN(in_text: _input, vin: out _out))
			{
				_out =
				   new char[17];
			}

			return _out;

		} 
	}
}
