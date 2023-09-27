using Crito.Contexts;
using Crito.Models.Entities;

namespace Crito.Repositories
{
    public class SubscriberRepo : Repo<SubscriberEntity>
    {
        public SubscriberRepo(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
