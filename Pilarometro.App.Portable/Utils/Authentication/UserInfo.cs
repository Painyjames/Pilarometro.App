using System;
using System.Collections.Generic;
using Pilarometro.App.Portable.DTOs;
using System.Linq;

namespace Pilarometro.App.Portable.Utils.Authentication
{
	public class UserInfo
	{
		public virtual string Name { get; set; }
		public virtual string Email { get; set; }
		public virtual string Picture {  get; set; }

		private List<PointOfInterestDto> _pointsOfInterest;
		public List<PointOfInterestDto> GetPointsOfInterest(){
			if (_pointsOfInterest == null)
				_pointsOfInterest = new List<PointOfInterestDto> ();
			return _pointsOfInterest;
		}
		public void SetPointsOfInterest(List<PointOfInterestDto> pointsOfInterest){
			_pointsOfInterest = pointsOfInterest;
		}

		public int GetScore(){
			return (int)_pointsOfInterest.Sum(p => p.Rating * 50);
		}
	}
}

