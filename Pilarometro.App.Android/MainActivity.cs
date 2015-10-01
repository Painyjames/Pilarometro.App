using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Threading;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;
using System.IO;
using Pilarometro.App.Portable;
using Xamarin.Forms;
using Xamarin;
using Xamarin.Forms.Platform.Android;

namespace Pilarometro.App.Android
{
	[Activity (Label = "Pilarometro", MainLauncher = true)]
	public class MainActivity : FormsApplicationActivity, ILocationListener
	{

		private LocationManager _locationManager;

		public void UnhandledExceptionLocal(object sender, UnhandledExceptionEventArgs e){
			Console.WriteLine (((Exception)e.ExceptionObject).Message);
		}
		void HandleAndroidException(object sender, RaiseThrowableEventArgs e)
		{
			e.Handled = true;
			Console.Write ("HANDLED EXCEPTION:"+e.Exception.Message);
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionLocal;
			AndroidEnvironment.UnhandledExceptionRaiser +=  HandleAndroidException;
			Xamarin.Forms.Forms.Init (this, bundle);

			Forms.Init(this, bundle);
			FormsMaps.Init(this, bundle);

			_locationManager = GetSystemService (Context.LocationService) as LocationManager;
			Criteria locationCriteria = new Criteria();
			locationCriteria.Accuracy = Accuracy.Coarse;
			locationCriteria.PowerRequirement = Power.Medium;
			var locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
			if(locationProvider != null)
			{
				_locationManager.RequestLocationUpdates (locationProvider, 500, 1, this);
			}

			var pclApp = App.Portable.App.Instance;
			var setup = new AppSetup () {
				CreateConnectionPool = this.CreateConnnectionPool,
				DbPath = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal),"RF12G5td864.db3")
			};
			pclApp.Setup (setup);
			#if DEBUG
			//pclApp.DeleteUser ();
			#endif
			LoadApplication (pclApp);
		}

		public SQLiteConnectionPool CreateConnnectionPool(){
			return new SQLiteConnectionPool (new SQLitePlatformAndroid ());
		}

		public void OnLocationChanged (Location location)
		{
			App.Portable.App.Instance.Latitude = location.Latitude;
			App.Portable.App.Instance.Longitude = location.Longitude;
		}

		protected override void OnPause ()
		{
			base.OnPause ();
			_locationManager.RemoveUpdates (this);
		}

		public void OnProviderEnabled (string provider)
		{
		}

		public void OnProviderDisabled (string provider)
		{
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
		}
	}
}


