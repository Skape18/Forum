using AutoMapper;
using DAL.Interfaces;

namespace BLL.Infrastructure.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
