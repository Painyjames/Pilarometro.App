﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilarometro.App.Portable.DTOs
{
    public class UserDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public List<PointOfInterestDto> PointsOfInterest { get; set; }
	}
}
