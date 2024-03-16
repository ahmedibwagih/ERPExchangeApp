using Core.Entities.LookUps;
using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.LookUps;
using Core.Repositories.privilage;
using Dynamo.Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class JobsRepository : BaseRepository<Jobs>, IJobsRepository
    {

        DBContext context;
        public JobsRepository(DBContext context) : base(context)
        {
            this.context = context;
        }

        public override Task<Jobs> AddAsync(Jobs entity)
        {
             
            var x = base.AddAsync(entity);
            context.Database.ExecuteSqlRawAsync("EXEC fill_Privilage");
            return x;
        }
    }
}
