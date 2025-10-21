using TEST.Core.Entities;

namespace TEST.Infrastructure.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project?> GetProjectWithDetailsAsync(int id);
    }
}
