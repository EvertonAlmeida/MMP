using System;
using System.Threading.Tasks;
using MMP.Domain.Interfaces;

namespace MMP.Domain.Models.Classes.Repository
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<Class> GetClassByClassTypeId(Guid classTypeId);
    }
}