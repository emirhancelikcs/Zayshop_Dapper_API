using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.FooterCenterDtos;
using ZayShop_Dapper_Api.Dtos.FooterRightDtos;
using ZayShop_Dapper_Api.Repositories.FooterRightRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterRightController : ControllerBase
	{
		private readonly IFooterRightRepository _footerRightRepository;

		public FooterRightController(IFooterRightRepository footerRightRepository)
		{
			_footerRightRepository = footerRightRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var values = await _footerRightRepository.GetAllFooterRight();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var value = await _footerRightRepository.GetFooterRightByID(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFooterRight(CreateFooterRightDto createFooterRight)
		{
			_footerRightRepository.CreateFooterRight(createFooterRight);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFooterRight(UpdateFooterRightDto updateFooterRight)
		{
			_footerRightRepository.UpdateFooterRight(updateFooterRight);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFooterRight(int id)
		{
			_footerRightRepository.DeleteFooterRight(id);
			return Ok();
		}
	}
}
