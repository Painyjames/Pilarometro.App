using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Pilarometro.App.Portable.Utils.ServiceClients.Models;

namespace Pilarometro.App.Portable.Utils.ServiceClients
{
	public class ServiceClient
	{
		private static readonly string UrlEchoing = "http://cascomio.ddns.net:8083/echoing/rest/";

		public async Task PostMessage(LocalizedMessage localizedMessage){
			try
			{
				using (var httpClient = new HttpClient ()) {
					httpClient.BaseAddress = new Uri(UrlEchoing);
					var json = JsonConvert.SerializeObject(localizedMessage);
					var content = new StringContent (json, Encoding.UTF8, "application/json");
					var response = await httpClient.PostAsync ("Message", content);
					response.EnsureSuccessStatusCode ();
				}
			}catch(Exception ex){
				throw;
			}
		}

		public async Task<IList<LocalizedMessage>> GetMessages(UserPosition userPosition){
			try
			{
				using (var httpClient = new HttpClient ()) {
					httpClient.BaseAddress = new Uri(UrlEchoing);
					var json = JsonConvert.SerializeObject(userPosition);
					var content = new StringContent (json, Encoding.UTF8, "application/json");
					var response = await httpClient.PostAsync ("PositionedMessages", content);

					response.EnsureSuccessStatusCode ();

					var resultJson = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<List<LocalizedMessage>> (resultJson);
				}
			}catch(Exception ex){
				throw;
			}
		}
	}
}

