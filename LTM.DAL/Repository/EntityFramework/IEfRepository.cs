using LTM.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Repository
{
    public abstract class IEfRepository
    {
		public EFContext _context;
		public IEfRepository(EFContext context)
		{
			_context = context;
		}
	}
}
