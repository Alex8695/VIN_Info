using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VIN_Info.Control
{
	class VIN_Regex
	{
		private static readonly Regex regexVinInfo = new Regex(vinRegex);
		private const string vinRegex = @"(?'VIN'(?'Type'\b\w{3})(?'Series'\w{1})(?'Engine'\w{1})(?'SRS'\w{1})(?'Model'\w{2})(?'PlaceHolder'\w{1})(?'MY'\w{1})(?'Factory'\w{1})(?'Serial'\d{6}\b))";
		private const string id_VIN = "VIN";
		private const string id_Type_VIN123 = "Type";
		private const string id_Series_VIN4 = "Series";
		private const string id_Engine_VIN5 = "Engine";
		private const string id_SRS_VIN6 = "SRS";
		private const string id_Model_VIN78 = "Model";
		private const string id_ModelYear_VIN10 = "MY";
		private const string id_Factory_VIN11 = "Factory";
		private const string id_Serial_VIN12to17 = "Serial";

		internal static bool Try_Get_VIN(string in_text,out char[] vin)
		{
			Match _match = Match.Empty;
			bool _out = false;

			vin =
				new char[17];

			try
			{
				_match =
					 regexVinInfo.Match(
						 input: in_text);

				if (_match.Success)
				{
					vin =
						_match.Groups[id_VIN].Value
						.ToCharArray();

					_out = 
						true;			
				}
			}
			catch (Exception)
			{
				Debugger.Break();
			}

			return _out;	 
		}


	}
}
