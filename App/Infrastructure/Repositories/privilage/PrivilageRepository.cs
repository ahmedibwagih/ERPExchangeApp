using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.privilage;
using Dynamo.Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PrivilageRepository : BaseRepository<Privilage>, IPrivilageRepository
    {
        DBContext _context;

        public PrivilageRepository(DBContext context) : base(context)
        {
          
        }

        public async Task<bool> CheckAuth(long PrivilageTypeId,long jobid,long screenid)
        {
            IQueryable<Privilage> query = DbSet.AsQueryable();
            query = query.Where(x => x.PrivilageTypeId == PrivilageTypeId && x.JobId == jobid );//&& x.ScreensId==screenid
            var x = (await query.ToListAsync());
            var xx = x.FirstOrDefault().State;
            return ( xx ==Core.Other.PrivilageStateEnum.Allow);
        }

    }
}
