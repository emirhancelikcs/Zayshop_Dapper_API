using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.CartDtos;
using ZayShop_Dapper_Api.Repositories.CartRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartRepository _cartRepository;

		public CartController(ICartRepository cartRepository)
		{
			_cartRepository = cartRepository;
		}

		[HttpPost]
		public async Task<IActionResult> AddCart(AddCartDto addCartDto)
		{
			_cartRepository.AddCart(addCartDto);
			return Ok();
		}

		[HttpGet("{UserId}")]
		public async Task<IActionResult> GetCart(string UserId)
		{
			var values = await _cartRepository.GetCartItems(UserId);
			return Ok(values);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteCartItem(int ProductId, string UserId)
		{
			_cartRepository.DeleteCartItem(ProductId, UserId);
			return Ok();
		}
	}
}
