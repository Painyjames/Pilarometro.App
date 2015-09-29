using System;
using System.IO;
using PCLStorage;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net;

namespace Pilarometro.App.Portable.Utils.DataAccess
{

	public delegate SQLiteConnectionPool CreateConnectionPool();

	public abstract class DataAccess
	{
		public static CreateConnectionPool GetConnectionPool { get; set; }
		private static SQLiteConnectionPool _connectionPool;

		public virtual string DbPath { get; set; }

		public SQLiteConnection GetConnection(){
			var connectionString = new SQLiteConnectionString (DbPath, true);
			if (_connectionPool == null)
				_connectionPool = GetConnectionPool ();
			return _connectionPool.GetConnection (connectionString);
		}

	}
}

