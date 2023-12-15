using ZayShop_Dapper_Api.Dtos.CartDtos;

namespace ZayShop_Dapper_Api.Repositories.CartRepository
{
	public interface ICartRepository
	{
		void AddCart(AddCartDto addCartDto);
		void DeleteCartItem(int ProductId, string UserId);
		Task<List<ResultCartDto>> GetCartItems(string UserId);
	}
}
