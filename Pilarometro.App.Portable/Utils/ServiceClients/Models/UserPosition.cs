using System;
using Newtonsoft.Json;

namespace Pilarometro.App.Portable.Utils.ServiceClients.Models
{
	public class UserPosition
	{
		[JsonProperty(PropertyName = "user")]
		public User User { get; set; }
		[JsonProperty(PropertyName = "coordinates")]
		public Coordinates Coordinates { get; set; }
	}
}

