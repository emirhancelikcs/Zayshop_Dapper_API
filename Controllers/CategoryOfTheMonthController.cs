using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.CategoryOfTheMonthDtos;
using ZayShop_Dapper_Api.Repositories.CategoryOfTheMonthRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class CategoryOfTheMonthController : ControllerBase
	{
		private readonly ICategoryOfTheMonthRepository _categoryOfTheMonthRepository;

		public CategoryOfTheMonthController(ICategoryOfTheMonthRepository categoryOfTheMonthRepository)
		{
			_categoryOfTheMonthRepository = categoryOfTheMonthRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategoryOfTheMonth()
		{
			var value = await _categoryOfTheMonthRepository.GetCategoryOfTheMonthAsync();
			return Ok(value);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryOfTheMonthById(int id)
		{
			var value = await _categoryOfTheMonthRepository.GetCategoryOFTheMonthById(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategoryOfTheMonth(CreateCategoryOfTheMonthDto createCategoryOfTheMonthDto)
		{
			_categoryOfTheMonthRepository.CreateCategoryOfTheMonth(createCategoryOfTheMonthDto);
			return Ok("Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCategoryOfTheMonth(int id)
		{
			_categoryOfTheMonthRepository.DeleteCategoryOfTheMonth(id);
			return Ok("Başarılı bir şekilde silindi!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategoryOfTheMonth(UpdateCategoryOfTheMonthDto updateCategoryOfTheMonthDto)
		{
			_categoryOfTheMonthRepository.UpdateCategoryOfTheMonth(updateCategoryOfTheMonthDto);
			return Ok("Güncelleme başarılı");
		}
	}
}
