using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.InfosDtos;
using ZayShop_Dapper_Api.Repositories.InfosRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class InfosController : ControllerBase
	{
		private readonly IInfosRepository _infosRepository;

		public InfosController(IInfosRepository infosRepository)
		{
			_infosRepository = infosRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetInfos()
		{
			var value = await _infosRepository.GetInfosAsync();
			return Ok(value);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateInfo(UpdateInfosDto updateInfosDto)
		{
			_infosRepository.UpdateInfo(updateInfosDto);
			return Ok();
		}
	}
}
