using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.FooterCenterDtos;
using ZayShop_Dapper_Api.Repositories.FooterCenterRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterCenterController : ControllerBase
	{
		private readonly IFooterCenterRepository _footerCenterRepository;

		public FooterCenterController(IFooterCenterRepository footerCenterRepository)
		{
			_footerCenterRepository = footerCenterRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _footerCenterRepository.GetAllFooterCenter();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var value = await _footerCenterRepository.GetFooterCenterById(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFooterCenter(CreateFooterCenterDto createFooterCenter)
		{
			_footerCenterRepository.CreateFooterCenter(createFooterCenter);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFooterCenter(UpdateFooterCenterDto updateFooterCenter)
		{
			_footerCenterRepository.UpdateFooterCenter(updateFooterCenter);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFooterCenter(int id)
		{
			_footerCenterRepository.DeleteFooterCenter(id);
			return Ok();
		}
	}
}
