using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.IndexCarouselDtos;
using ZayShop_Dapper_Api.Repositories.IndexCarouselRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IndexCarouselController : ControllerBase
	{
		private readonly IIndexCarouselRepository _indexCarouselRepository;

		public IndexCarouselController(IIndexCarouselRepository indexCarouselRepository)
		{
			_indexCarouselRepository = indexCarouselRepository;
		}

		[HttpGet]
		public async Task<IActionResult> IndexCarouselList()
		{
			var values = await _indexCarouselRepository.GetAllIndexCarouselAsync();
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateIndexCarousel(CreateIndexCarouselDto createIndexCarouselDto)
		{
			_indexCarouselRepository.CreateIndexCarousel(createIndexCarouselDto);
			return Ok("Başlık Başarılı Bir Şekilde Eklendi!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteIndexCarousel(int id)
		{
			_indexCarouselRepository.DeleteIndexCarousel(id);
			return Ok("Başlık Başarılı Bir Şekilde Silindi!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateIndexCarouselDto updateIndexCarouselDto)
		{
			_indexCarouselRepository.UpdateIndexCarousel(updateIndexCarouselDto);
			return Ok("Başlık Başarılı Bir Şekilde Güncellendi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var value = await _indexCarouselRepository.GetIndexCarousel(id);
			return Ok(value);
		}
	}
}
