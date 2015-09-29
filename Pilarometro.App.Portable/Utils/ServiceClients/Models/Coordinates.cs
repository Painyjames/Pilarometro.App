using System;
using Newtonsoft.Json;

namespace Pilarometro.App.Portable.Utils.ServiceClients.Models
{
	public class Coordinates
	{
		[JsonProperty(PropertyName = "lat")]
		public double? Latitude { get; set; }
		[JsonProperty(PropertyName = "lon")]
		public double? Longitude { get; set; }
	}
}

