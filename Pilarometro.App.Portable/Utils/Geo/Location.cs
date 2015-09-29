using System;

namespace Pilarometro.App.Portable.Utils.Geo
{
	public class Location
	{
		public static double Distance(double longitude, double latitude, double longitude2, double latitude2, char unit = 'K'){
			var theta = longitude - longitude2;
			var dist = Math.Sin(Deg2Rad(latitude)) * Math.Sin(Deg2Rad(latitude2)) + Math.Cos(Deg2Rad(latitude)) * Math.Cos(Deg2Rad(latitude2)) * Math.Cos(Deg2Rad(theta));
			dist = Math.Acos(dist);
			dist = Rad2Deg(dist);
			if (unit == 'K') {
				dist = dist * 1.609344;
			} else if (unit == 'N') {
				dist = dist * 0.8684;
			} else {
				dist = dist * 60 * 1.1515;
			}
			return (dist);
		}

		private static double Deg2Rad(double deg) {
			return (deg * Math.PI / 180.0);
		}

		private static double Rad2Deg(double radian) {
			return (radian / Math.PI * 180.0);
		}
	}
}
