using LTM.DAL.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Context
{
    public class MongoContext
    {
		protected readonly IMongoDatabase _database = null;

		public MongoContext(string conn, string db)
		{
			var client = new MongoClient(conn);
			if (client != null)
				_database = client.GetDatabase(db);
			MongoConfiguration.EfetuarConfiguracao();
		}

		public IMongoDatabase GetDatabase()
		{
			return _database;
		}
	}
}
