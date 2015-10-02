using System;
using System.Linq;
using Pilarometro.App.Portable.Utils.Authentication;

namespace Pilarometro.App.Portable.Utils.DataAccess
{
	public class UserDataAccess : DataAccess, IUserDataAccess
	{

		public UserInfo GetUser ()
		{
			return (from u in GetConnection().Table<UserInfo>() select u).FirstOrDefault();
		}

		public void SaveUser (UserInfo user)
		{
			GetConnection().Insert(user, typeof(UserInfo));
		}

		public void DeleteAll ()
		{
			GetConnection ().DeleteAll<UserInfo>();
		}

	}
}

