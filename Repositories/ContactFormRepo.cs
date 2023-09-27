using Crito.Contexts;
using Crito.Models.Entities;

namespace Crito.Repositories
{
    public class ContactFormRepo : Repo<ContactFormEntity>
    {
        public ContactFormRepo(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
