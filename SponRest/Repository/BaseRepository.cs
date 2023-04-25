using System;
using SponRest.Context;

namespace SponRest.Repository
{
	public class BaseRepository
	{
        protected readonly DapperContext _context;

        public BaseRepository(DapperContext context)
        {
            _context = context;
        }
    }
}

