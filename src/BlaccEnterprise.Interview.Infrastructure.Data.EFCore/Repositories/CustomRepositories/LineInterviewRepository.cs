using System.Collections.Generic;
using System.Linq;

using BlaccEnterprise.Interview.Domain.LineInterview;
using BlaccEnterprise.Interview.Domain.LineInterview.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BlaccEnterprise.Interview.Infrastructure.Data.EFCore.Repositories.CustomRepositories
{
    public class LineInterviewRepository : GenericRepository<LineInterview, AppEFCoreContext>, ILineInterviewRepository
    {
        public LineInterviewRepository(AppEFCoreContext context) : base(context) { }
    }
}