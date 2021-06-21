using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Infra.Data.Context;

namespace MMP.Infra.Data.Repositories
{
    public class ClassTypeRepository : Repository<ClassType>, IClassTypeRepository
    {
        public ClassTypeRepository(MmpDbContext db) : base(db) { }
    }
}