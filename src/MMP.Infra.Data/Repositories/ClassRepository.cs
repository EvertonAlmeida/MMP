using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMP.Domain.Models.Classes;
using MMP.Domain.Models.Classes.Repository;
using MMP.Infra.Data.Context;

namespace MMP.Infra.Data.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(MmpDbContext db) : base(db) { }

        public async Task<Class> GetClassByClassTypeId(Guid classTypeId)
        {
            return await Db.Classes.AsNoTracking()
                .Include(c => c.ClassType)
                .FirstOrDefaultAsync(c => c.ClassTypeId == classTypeId);
        }
    }
}