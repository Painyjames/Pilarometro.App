using System;
using Xamarin.Forms;
using SQLite.Net.Interop;
using Pilarometro.App.Portable.Utils.Authentication;
using Pilarometro.App.Portable.Utils.DataAccess;
using Pilarometro.App.Portable.Pages;
using Pilarometro.App.Portable.Utils.Geo;
using Pilarometro.App.Portable.Utils.ServiceClients;
using Pilarometro.App.Portable.Requests;
using Pilarometro.App.Portable.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Pilarometro.App.Portable
{
	public delegate void PositionChangedEventHandler(object sender, EventArgs e);

	public class App : Application
	{
		private static readonly Lazy<App> lazy =
			new Lazy<App>(() => Build());
		public static App Instance { get { return lazy.Value; } }
		private App(){}

		private static App Build(){
			var app = new App () {
				UserDataAccess = new UserDataAccess()
			};

			return app;
		}

		public bool IsLoggedIn {
			get { return User != null; }
		}

		private UserInfo _user;
		public UserInfo User { 
			get{ 
				if (_user == null) {
					_user = UserDataAccess.GetUser ();
					new ServiceClient ().UpdateUser (new UpdateUserPointsOfInterestRequest {
						User = new UserDto {
							Id = _user.Email,
							Email = _user.Email,
							Name = _user.Name
						}
					})
					.ContinueWith(c => {
						_user.SetPointsOfInterest(c.Result.User.PointsOfInterest);
					});					
				}
				return _user;
			} 
		}

		public IUserDataAccess UserDataAccess { get; set; }

		public void SaveUser(object user)
		{
			_user = user as UserInfo;
			UserDataAccess.SaveUser(_user);
		}

		public void DeleteUser(){
			UserDataAccess.DeleteAll ();
			MainPage.Navigation.PushModalAsync(new LoginPage ());
		}

		public Action SuccessfulLoginAction
		{
			get {
				return new Action (() => {
					if(!(MainPage is RootPage)){
						var rootPage = new RootPage();
						Instance.PositionChanged += (object sender, EventArgs e) => 
						{
							rootPage.PositionChanged();
							Instance.CheckIfVisited();
						};
						MainPage = rootPage;
						OnPositionChanged();
					}
					else
						MainPage.Navigation.PopModalAsync();
				});
			}
		}

		//TODO: put it somewhere else
		public void CheckIfVisited(){
			var newPointsVisited = App.Instance.PointsOfInterest
				.Where (p => Location.Distance(p.Coordinates.Lon.Value, p.Coordinates.Lat.Value, Longitude.Value, Latitude.Value) < 0.05
					& !_user.GetPointsOfInterest().Any(up => up.Id == p.Id));
			if (newPointsVisited.Any ()) {
				_user.GetPointsOfInterest ().AddRange (newPointsVisited);
				new ServiceClient ().UpdateUser (new UpdateUserPointsOfInterestRequest {
					User = new UserDto {
						Email = _user.Email,
						Id = _user.Email,
						Name = _user.Name,
						PointsOfInterest = _user.GetPointsOfInterest()
					}
				});
			}
		}

		public event PositionChangedEventHandler PositionChanged;

		private double? _longitude;
		public double? Longitude { 
			get{ return _longitude; } 
			set
			{ 
				double? oldLongitude = _longitude??0;
				_longitude = value;
				if (_latitude.HasValue) {
					var distance = Math.Abs(Location.Distance(oldLongitude.Value, _latitude.Value, _longitude.Value, _latitude.Value)); 
					if(distance > 0.003)
						OnPositionChanged ();
				}
			} 
		}

		private double? _latitude;
		public double? Latitude { 
			get{ return _latitude; } 
			set
			{ 
				double? oldLatitude = _latitude??0;
				_latitude = value;
				if (_longitude.HasValue) {
					var distance = Math.Abs(Location.Distance(_longitude.Value, oldLatitude.Value, _longitude.Value, _latitude.Value)); 
					if(distance > 0.003)
						OnPositionChanged ();
				}
			} 
		}

		public List<PointOfInterestDto> PointsOfInterest { get; set; }

		protected void OnPositionChanged()
		{
			PositionChangedEventHandler handler = PositionChanged;
			if (handler != null)
			{
				handler(this, null);
			}
		}

		//TODO: move all database stuff to a session object or factory or something similar
		public void Setup(AppSetup setup){
			var connectionPool = setup.CreateConnectionPool;
			var connectionString = new SQLite.Net.SQLiteConnectionString (setup.DbPath, true);
			using (var connection = connectionPool ().GetConnection (connectionString)) {
				connection.CreateTable<UserInfo> ();
				connection.Commit ();
			}
			//Setup the connection Pool
			DataAccess.GetConnectionPool = connectionPool;
			UserDataAccess.DbPath = setup.DbPath;

			if (IsLoggedIn) {
				if (!(MainPage is RootPage)) {
					var rootPage = new RootPage ();
					Instance.PositionChanged += (object sender, EventArgs e) => rootPage.PositionChanged ();
					MainPage = rootPage;
				}
			} else {
				MainPage = new LoginPage ();
			}
		}

	}

	public class AppSetup{
		public string DbPath { get; set; }
		public CreateConnectionPool CreateConnectionPool { get; set; } 
	}
}


