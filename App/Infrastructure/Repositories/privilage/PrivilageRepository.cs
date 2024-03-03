using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.privilage;
using Dynamo.Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PrivilageRepository : BaseRepository<Privilage>, IPrivilageRepository
    {


        public PrivilageRepository(DBContext context) : base(context)
        {

        }

    }
}
