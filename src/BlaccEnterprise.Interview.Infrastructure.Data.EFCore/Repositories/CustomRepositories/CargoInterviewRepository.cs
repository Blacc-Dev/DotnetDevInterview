using System.Collections.Generic;
using System.Linq;

using BlaccEnterprise.Interview.Domain.CargoInterview;
using BlaccEnterprise.Interview.Domain.CargoInterview.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories.CustomRepositories
{
    public class CargoInterviewRepository : GenericRepository<CargoInterview, AppEFCoreContext>, ICargoInterviewRepository
    {
        public CargoInterviewRepository(AppEFCoreContext context) : base(context) { }
    }
}