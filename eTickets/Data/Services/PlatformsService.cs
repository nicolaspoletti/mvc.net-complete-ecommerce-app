using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class PlatformsService: EntityBaseRepository<Platform>, IPlatformsService
    {

        public PlatformsService(AppDbContext context) : base(context)
        {

        }
    }
}
