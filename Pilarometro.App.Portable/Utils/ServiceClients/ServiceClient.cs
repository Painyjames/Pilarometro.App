﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Pilarometro.App.Portable.Requests;
using System.Diagnostics;
using Pilarometro.App.Portable.Responses;

namespace Pilarometro.App.Portable.Utils.ServiceClients
{
	public class ServiceClient
	{
		private static readonly string Url = "http://cascomio.ddns.net:5000/api/";

		public async Task<FindPointsOfInterestResponse> GetPointsOfInterest(FindPointsOfInterestRequest request){
			try
			{
				using (var httpClient = new HttpClient ()) {
					httpClient.BaseAddress = new Uri(Url);
					var path = string.Format("PointsOfInterest?Latitude={0}&Longitude={1}&PageNumber={2}&PageSize={3}",request.Latitude,request.Longitude,request.PageNumber,request.PageSize);
					return await httpClient.GetAsync (path)
					.ContinueWith(c => {
						var result = c.Result;
						result.EnsureSuccessStatusCode();
						var json = result.Content.ReadAsStringAsync().Result;
						return JsonConvert.DeserializeObject<FindPointsOfInterestResponse>(json);
					});
				}
			}catch(Exception ex){
				Debug.WriteLine (ex.Message);
				throw;
			}
		}

		public async Task<FindPointOfInterestResponse> GetPointOfInterest(FindPointOfInterestRequest request){
			try
			{
				using (var httpClient = new HttpClient ()) {
					httpClient.BaseAddress = new Uri(Url);
					return await httpClient.GetAsync (string.Format("PointsOfInterest/{0}",request.Id))
					.ContinueWith(c => {
						var result = c.Result;
						result.EnsureSuccessStatusCode();
						var json = result.Content.ReadAsStringAsync().Result;
						return JsonConvert.DeserializeObject<FindPointOfInterestResponse>(json);
					});
				}
			}catch(Exception ex){
				Debug.WriteLine (ex.Message);
				throw;
			}
		}

		public async Task GetUser(FindUserPointsOfInterestRequest request){
			try
			{
				using (var httpClient = new HttpClient ()) {
					httpClient.BaseAddress = new Uri(Url);
					var response = await httpClient.GetAsync (string.Format("User/{0}/PointsOfInterest",request.Id));
					response.EnsureSuccessStatusCode ();
				}
			}catch(Exception ex){
				Debug.WriteLine (ex.Message);
				throw;
			}
		}

		public async Task<UpdateUserPointsOfInterestResponse> UpdateUser (UpdateUserPointsOfInterestRequest request){
			try
			{
				using (var httpClient = new HttpClient ()) {
					httpClient.BaseAddress = new Uri(Url);
					var json = JsonConvert.SerializeObject(request);
					var content = new StringContent (json, Encoding.UTF8, "application/json");
					return await httpClient.PutAsync (string.Format("User/{0}/PointsOfInterest",request.User.Id), content)
					.ContinueWith(c => {
						var result = c.Result;
						result.EnsureSuccessStatusCode();
						var jsonResult = result.Content.ReadAsStringAsync().Result;
						return JsonConvert.DeserializeObject<UpdateUserPointsOfInterestResponse>(jsonResult);
					});
				}
			}catch(Exception ex){
				Debug.WriteLine (ex.Message);
				throw;
			}
		}

	}
}

