using Microsoft.AspNetCore.Mvc;
using TEST.Core.Entities;
using TEST.Infrastructure.Interfaces;

namespace TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var projects = await _projectRepository.GetAllAsync();
                return Ok(projects);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
            return Ok(project);
        }
    }
}
