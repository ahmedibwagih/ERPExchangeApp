using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.privilage;
using Dynamo.Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PrivilageTypeRepository : BaseRepository<PrivilageType>, IPrivilageTypeRepository
    {


        public PrivilageTypeRepository(DBContext context) : base(context)
        {

        }

    }
}
