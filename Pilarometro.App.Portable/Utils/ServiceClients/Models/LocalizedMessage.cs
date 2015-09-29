using System;
using Newtonsoft.Json;
using Pilarometro.App.Portable.Utils.ServiceClients.Converters;

namespace Pilarometro.App.Portable.Utils.ServiceClients.Models
{
	public class LocalizedMessage
	{
		[JsonProperty(PropertyName = "uuid")]
		public string Uuid { get; set; }
		[JsonProperty(PropertyName = "coordinates")]
		public Coordinates Coordinates { get; set; }
		[JsonProperty(PropertyName = "messageContent")]
		public string MessageContent { get; set; }
		[JsonProperty(PropertyName = "user")]
		public User User { get; set; }
		[JsonProperty(PropertyName = "timestamp")]
		[JsonConverter(typeof(CustomDateTimeJsonConverter))]
		public DateTime? Timestamp{ get; set; }
	}
}

