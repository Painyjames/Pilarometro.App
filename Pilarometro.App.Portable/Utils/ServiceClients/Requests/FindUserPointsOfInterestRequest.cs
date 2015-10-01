using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilarometro.App.Portable.Requests
{
    public class FindUserPointsOfInterestRequest : QueryRequest
	{
		public string Id { get; set; }
    }
}
