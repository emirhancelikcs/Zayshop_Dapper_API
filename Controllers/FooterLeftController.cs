using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.FooterLeft;
using ZayShop_Dapper_Api.Dtos.FooterLeftDtos;
using ZayShop_Dapper_Api.Repositories.FooterLeftRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterLeftController : ControllerBase
	{
		private readonly IFooterLeftRepository _footerLeftRepository;

		public FooterLeftController(IFooterLeftRepository footerLeftRepository)
		{
			_footerLeftRepository = footerLeftRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllFooterLeft()
		{
			var values = await _footerLeftRepository.GetAllFooterLeft();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFooterLeftById(int id)
		{
			var value = await _footerLeftRepository.GetFooterLeftById(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateFooterLeft(CreateFooterLeftDto createFooterLeft)
		{
			_footerLeftRepository.CreateFooterLeft(createFooterLeft);
			return Ok("Başarılı!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteFooterLeft(int id)
		{
			_footerLeftRepository.DeleteFooterLeft(id);
			return Ok("Silindi!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFooterLeft(UpdateFooterLeftDto updateFooterLeftDto)
		{
			_footerLeftRepository.UpdateFooterLeft(updateFooterLeftDto);
			return Ok("Başaruılı");
		}
	}
}
