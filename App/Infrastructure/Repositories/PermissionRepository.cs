using Core.Repositories.Auth;
using Dynamo.Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {


        public PermissionRepository(DBContext context) : base(context)
        {

        }

    }
}
