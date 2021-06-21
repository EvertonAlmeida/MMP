using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Infra.Data.Context;

namespace MMP.Infra.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(MmpDbContext db) : base(db) { }
    }
}