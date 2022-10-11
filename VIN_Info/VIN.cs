using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	class VIN:VIN_Info.VinInfo
	{

	public VIN():base(){}
	public VIN(string text) : base(vin_text: text) { }
	}

