using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pilarometro.App.Portable.DTOs;

namespace Pilarometro.App.Portable.Requests
{
	public class UpdateUserPointsOfInterestRequest
	{
		public UserDto User { get; set; }
	}
}
