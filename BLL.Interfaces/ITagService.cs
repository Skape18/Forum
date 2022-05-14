using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Domain.Entities;

namespace BLL.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}