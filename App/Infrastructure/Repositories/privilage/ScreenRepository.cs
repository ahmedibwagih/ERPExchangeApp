using Core.Entities.privilege;
using Core.Repositories.Auth;
using Core.Repositories.privilage;
using Dynamo.Core.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ScreenRepository : BaseRepository<Screens>, IScreenRepository
    {


        public ScreenRepository(DBContext context) : base(context)
        {

        }

    }
}
