using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Repositories;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : ControllerBase
	{
		private readonly DepartmentRepository _departmentRepository;

		public DepartmentsController(DepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _departmentRepository.GetAllAsync());
		}
	}
}
