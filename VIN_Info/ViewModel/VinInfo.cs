using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MY = VIN_Info.Model.ModelYear;
using SN = VIN_Info.Model.SerialNumber;


namespace VIN_Info
{
	[DebuggerDisplay("{VIN.PadLeft(17,' ')} Valid: {isValid}")]
	public class VinInfo
	{



		#region OBJECT PUBLIC

		public bool Is_Valid { get { return isValid; } }
		public string VIN { get { return new string(vin); } }

		/// <summary>
		/// Vehicle Make
		/// Digits 1,2,3
		/// </summary>
		public string Make { get { return new string(vin, 0, 3); } }

		/// <summary>
		/// Vehicle Series
		/// Digits 4
		/// </summary>
		public string Series { get { return new string(vin, 3, 1); } }

		/// <summary>
		/// Vehicle Engine
		/// Digits 5
		/// </summary>
		public string Engine { get { return new string(vin, 4, 1); } }

		/// <summary>
		/// Vehicle Restraint System
		/// Digits 6
		/// </summary>
		public string RestraintSystem { get { return new string(vin, 5, 1); } }

		/// <summary>
		/// Vehicle Model
		/// Digits 7,8
		/// </summary>
		public string Model { get { return new string(vin, 6, 2); } }

		/// <summary>
		/// Check Digit
		/// Digits 9
		/// </summary>
		public string CheckDigit { get { return new string(vin, 8, 1); } }

		/// <summary>
		/// Vehicle Year
		/// Digits 10
		/// </summary>
		/// 
		public MY ModelYear { get { return modelYear; } }

		/// <summary>
		/// Vehicle Assembly Plant
		/// Digits 11
		/// </summary>
		public string AsemblyPlant { get { return new string(vin, 10, 1); } }

		/// <summary>
		/// Vehicle Serial Number
		/// Digits 12,13,14,15,16,17
		/// </summary>
		public SN SerialNumber { get { return serialNumber; } }


		#endregion

		#region OBJECT INTERNAL


		#endregion

		#region OBJECT PROTECTED


		#endregion

		#region OBJECT PRIVATE

		private char[] vin;
		private bool isValid;
		private MY modelYear;
		private SN serialNumber;



		#endregion

		#region METHOOD PRIVATE

		private void on_input(string input)
		{
			bool _isModelYearValid = false;
			bool _isSerialNumberValid = false;
			this.vin =
				Control.Parse_Input.Get_VIN_Chars(
					in_text: input);

			this.modelYear =
				new MY(
					model_year: vin[9]
					, is_valid: out _isModelYearValid);

			this.serialNumber =
				new SN(
					serial_str: new string(
						value: vin
						, startIndex: 11
						, length: 6)
						,is_valid: out _isSerialNumberValid
						);

			this.isValid =
				_isSerialNumberValid && _isModelYearValid;

			if(!this.isValid)
			{
				vin = 
					Enumerable.Repeat(
						element:'*', 
						count: 17)
						.ToArray();			 
			}


		}



		#endregion

		#region METHOOD PROTECTED


		#endregion

		#region METHOOD INTERNAL


		#endregion

		#region METHOOD PUBLIC

		public VinInfo()
		{
			on_input(null);
		}
		public VinInfo(string vin_text)
		{
			on_input(vin_text);
		}

		public override bool Equals(object obj)
		{
			bool _out = false;

			if (obj != null)
			{
				if (obj.GetType() == typeof(VIN_Info.VinInfo))
				{

					if (((VIN_Info.VinInfo)obj).isValid)
					{
						_out =
							((VIN_Info.VinInfo)obj).VIN == this.VIN;
					}
				}
				else if (obj.GetType() == typeof(string))
				{
					_out = ((string)obj) == this.VIN;
				}
						
			}
			return _out;
		}

		public override string ToString()
		{

			if (isValid)
			{
				return VIN;

			}

			return "NO VIN";

		}

		#endregion

	}

}