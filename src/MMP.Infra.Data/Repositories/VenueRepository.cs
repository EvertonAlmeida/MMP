using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Infra.Data.Context;

namespace MMP.Infra.Data.Repositories
{
    public class VenueRepository : Repository<Venue>, IVenueRepository
    {
        public VenueRepository(MmpDbContext db) : base(db) { }
    }
}