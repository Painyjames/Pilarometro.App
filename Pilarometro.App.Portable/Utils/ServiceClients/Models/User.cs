using System;
using Newtonsoft.Json;

namespace Pilarometro.App.Portable.Utils.ServiceClients.Models
{
	public class User
	{
		[JsonProperty(PropertyName = "userId")]
		public long? UserId { get; set; }
		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }
	}
}

