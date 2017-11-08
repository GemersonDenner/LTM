using LTM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Repository
{
    public abstract class IMongoRepository
    {
		public MongoContext _context;
		public IMongoRepository(MongoContext context)
		{
			_context = context;
		}
	}
}
