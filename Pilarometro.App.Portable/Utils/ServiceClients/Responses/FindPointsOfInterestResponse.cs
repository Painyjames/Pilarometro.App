using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pilarometro.App.Portable.DTOs;

namespace Pilarometro.App.Portable.Responses
{
    public class FindPointsOfInterestResponse
	{
		public List<PointOfInterestDto> PointsOfInterest { get; set; }
	}
}
