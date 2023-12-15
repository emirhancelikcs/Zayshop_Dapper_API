using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.NavbarLinkDtos;
using ZayShop_Dapper_Api.Repositories.NavbarLinkRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NavbarLinkController : ControllerBase
	{
		private readonly INavbarLinkRepository _navbarLinkRepository;

		public NavbarLinkController(INavbarLinkRepository navbarLinkRepository)
		{
			_navbarLinkRepository = navbarLinkRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetLinks()
		{
			var links = await _navbarLinkRepository.GetAllNavbarLink();
			return Ok(links);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetLinkById(int id)
		{
			var value = await _navbarLinkRepository.GetNavbarLinkById(id);
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateNavbarLink(CreateNavbarLinkDto createNavbarLinkDto)
		{
			_navbarLinkRepository.CreateNavbarLink(createNavbarLinkDto);
			return Ok("Başarılı!");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteNavbarLink(int navbarLinkId)
		{
			_navbarLinkRepository.DeleteNavbarLink(navbarLinkId);
			return Ok("Silindi!");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateNavbarLink(UpdateNavbarLinkDto updateNavbarLinkDto)
		{
			_navbarLinkRepository.UpdateNavbarLink(updateNavbarLinkDto);
			return Ok();
		}
	}
}
