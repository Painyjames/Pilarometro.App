using System;
using System.Collections.Generic;
using Pilarometro.App.Portable.DTOs;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public interface IUserInfo
	{
		string Name { get; set; }
		string Email { get; set; }
		string Picture { get; set; }
		List<PointOfInterestDto> PointsOfInterest{ get; }
	}
}

