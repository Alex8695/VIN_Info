using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VIN_Info;
using System.Diagnostics;
using System.Text;

namespace UnitTestVin
{
	[TestClass]
	public class UnitTestVin
	{
		private string[] getValidVinList()
		{

			return new string[]
			{

				"WA1BVAF10KD123456"
				,"WA1FVAF19LD123456"
				,"WA1EVAF14MD123456"
				,"WA1EVBF1XND123456"
				,"WA18NAF47HA123456"
				,"WA18NAF44JA123456"
				,"WA1LAAF79HD123456"
				,"WA1LHAF72JD123456"
				,"WA1AHAF7XKD123456"
				,"WA1VXAF70LD123456"
				,"WA1LXAF72MD123456"
				,"WA1LXBF74ND123456"
				,"WA1VXBF7XPD123456"
				,"WA1DKAFP0BA123456"
				,"WA1JCCFS7HR123456"
				,"WA1ANAFY7J2123456"
				,"WA1BNAFY5K2123456"
				,"WA1BNAFY6L2123456"
				,"WA1AAAFY9M2123456"
				,"WA1GAAFY9N2123456"
				,"WAUDF98E56A123456"
				,"WAUV2AF28KN123456"
				,"WAU72BF24LN123456"
				,"WAUPFBF28MN123456"
				,"WAUPFBF22NN123456"
				,"WAUANAF42HN123456"
				,"WAUKMAF44JA123456"
				,"WAUB4AF42LA123456"
				,"WAUEAAF46MA123456"
				,"WAUFAAF44NN123456"
				,"WAUCNCF51JA123456"
				,"WAUENCF50KA123456"
				,"WAUCBCF58MA123456"
				,"WAU2AGF57NN123456"
				,"WAU8DAF84KN123456"
				,"WAU8EAF81LN123456"
				,"WAU8EAF81MN123456"
				,"WAUAJGFFXF1123456"
				,"WAUB8GFF4G1123456"
				,"WAUB8GFF0H1123456"
				,"WAUB8GFF1J1123456"
				,"WAUBEGFF0LA123456"
				,"WAUGUDGY5NA123456"
				,"WU1ARBF15LD123456"
				,"WU1ARBF14MD123456"
				,"WU1ARBF16ND123456"
				,"WUA1CBF21MN123456"
				,"WUA1CBF2XNN123456"
				,"WUABWGFFXLA123456"
			};
		}
		[TestMethod]
		public void TestBulk_IsOK()
		{

			string[] _input = getValidVinList();

			bool OK = true;

			for (int i = 0; i < _input.Length; i++)
			{
				VinInfo vin = new VinInfo(_input[i]);

				if (vin.ToString() != _input[i])
				{
					OK = false;

					Debug.WriteLine($"{vin.ToString()} != {_input[i]}");
				}

			}
			Assert.IsTrue(OK);

		}

		[TestMethod]
		public void TestBreakout()
		{

			string[] _input = getValidVinList();

			bool OK = true;

			for (int i = 0; i < _input.Length; i++)
			{
				VinInfo vin = new VinInfo(_input[i]);

				if (!vin.Equals(_input[i]))
				{
					OK = false;

					Debug.WriteLine($"{vin.ToString()} != {_input[i]}");
				}

			}
			Assert.IsTrue(OK);

		}


		[TestMethod]
		public void Test_SerialNumber_AsInt()
		{
			string testVin = "WA1LHAF72JD123456";

			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.SerialNumber.As_Int == 123456;

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.SerialNumber.As_Int}");
									  
			Assert.IsTrue(OK);

		}

		[TestMethod]
		public void Test_SerialNumber_AsString()
		{
			string testVin = "WA1LHAF72JD123456";

			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.SerialNumber.As_String == "123456";

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.SerialNumber.As_String}");

			Assert.IsTrue(OK);

		}

		[TestMethod]
		public void Test_Model_V78_AsString()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.Model == "F7";

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.Model}");

			Assert.IsTrue(OK);

		}

		[TestMethod]
		public void Test_Year_V10_AsChar()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.ModelYear.As_Char == 'J';

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.ModelYear.As_Char}");

			Assert.IsTrue(OK);

		}
		[TestMethod]
		public void Test_Year_V10_AsString()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.ModelYear.As_String == "J";

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.ModelYear.As_String}");

			Assert.IsTrue(OK);

		}



		[TestMethod]
		public void Test_Factory_V10()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.AsemblyPlant == "D";

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.AsemblyPlant}");

			Assert.IsTrue(OK);

		}


		[TestMethod]
		public void Test_Engine_V5()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.Engine == "H";

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.Engine}");

			Assert.IsTrue(OK);

		}



		[TestMethod]
		public void Test_Make_V123()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.Make == "WA1";

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.Make}");

			Assert.IsTrue(OK);

		}

		[TestMethod]
		public void Test_VIN_All()
		{
			string testVin = "WA1LHAF72JD123456";
			VinInfo _vi = new VinInfo(testVin);
			bool OK = _vi.VIN == testVin;

			Debug.WriteLine($"Given: {testVin}"
				+ $"\n\t {_vi.VIN}");

			Assert.IsTrue(OK);

		}



	}
}
