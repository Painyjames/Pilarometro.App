using System;
using Pilarometro.App.Portable.Utils.Authentication;

namespace Pilarometro.App.Portable.Utils.DataAccess
{
	public interface IUserDataAccess
	{
		IUserInfo GetUser();
		void SaveUser(IUserInfo user);
		void DeleteAll();
		string DbPath { get; set; }
	}
}

