using Core.Entities.LookUps;
using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.LookUps;
using Core.Repositories.privilage;
using Dynamo.Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BanksRepository : BaseRepository<Banks>, IBanksRepository
    {


        public BanksRepository(DBContext context) : base(context)
        {

        }

    }
}
