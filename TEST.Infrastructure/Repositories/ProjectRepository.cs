using Microsoft.EntityFrameworkCore;
using TEST.Core;
using TEST.Core.Entities;
using TEST.Infrastructure.Interfaces;

namespace TEST.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly TestContext _context;

        public ProjectRepository(TestContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Project?> GetProjectWithDetailsAsync(int id)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
