using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.privilage;
using Dynamo.Context.Identity;
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
        

        protected readonly DBContext Context;
        public PrivilageRepository(DBContext context) : base(context)
        {
            Context = context;
        }
            
        public async void fill_Privilage()
        {
            await Context.Database.ExecuteSqlRawAsync("EXEC fill_Privilage");
            //  await Context.fill_Privilage();
        }

        public async Task<bool> CheckAuth(long PrivilageTypeId,long jobid,long screenid)
        {
            IQueryable<Privilage> query = DbSet.AsQueryable();
            query = query.Where(x => x.PrivilageTypeId == PrivilageTypeId && x.JobId == jobid );//&& x.ScreensId==screenid
            var x = (await query.ToListAsync());
            var xx = x.FirstOrDefault().State;
            return ( xx !=Core.Other.PrivilageStateEnum.Deny);
        }

        public async Task<bool> CheckAuthByName(long jobid, string screenName,string PrivilageTypeName)
        {
            string newPrivilageTypeName = PrivilageTypeName.Trim().ToLower();
            string newscreenName = screenName.Trim().ToLower();
            
            long screenid = Context.Set<Screens>().Where(a =>  (a.NameAr.Contains(newscreenName) || a.NameEn.Contains(newscreenName))).ToList().FirstOrDefault().ScreenId;
            long PrivilageTypeId = Context.Set<PrivilageType>().Where(a => a.ScreensId == screenid && (a.NameAr.Contains(newPrivilageTypeName) || a.NameEn.Contains(newPrivilageTypeName))).ToList().FirstOrDefault().PrivilageTypeId;

            IQueryable<Privilage> query = DbSet.AsQueryable();
            query = query.Where(x => x.PrivilageTypeId == PrivilageTypeId && x.JobId == jobid && x.ScreensId == screenid);//&& 
            var x = (await query.ToListAsync());
            var xx = x.FirstOrDefault().State;
            return (xx != Core.Other.PrivilageStateEnum.Deny);
        }

    }
}
