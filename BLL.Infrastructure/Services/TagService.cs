using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Domain.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Infrastructure.Services
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {
        }
        
        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await UnitOfWork.Tags.GetDbSet().ToListAsync();
        }
    }
}