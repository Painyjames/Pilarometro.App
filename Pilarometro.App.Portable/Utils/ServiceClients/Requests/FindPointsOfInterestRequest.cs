using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilarometro.App.Portable.Requests
{
	public class FindPointsOfInterestRequest : QueryRequest
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
