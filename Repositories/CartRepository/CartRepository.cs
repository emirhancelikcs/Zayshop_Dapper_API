using Dapper;
using ZayShop_Dapper_Api.Dtos.CartDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.CartRepository
{
	public class CartRepository : ICartRepository
	{
		private readonly Context _context;

		public CartRepository(Context context)
		{
			_context = context;
		}

		public async void AddCart(AddCartDto addCartDto)
		{
			string query = "Insert Into Cart (ProductId, UserId) Values (@productId, @userId)";
			var parameters = new DynamicParameters();
			parameters.Add("@productId", addCartDto.ProductId);
			parameters.Add("@userId", addCartDto.UserId);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteCartItem(int ProductId, string UserId)
		{
			string query = "Delete From Cart Where ProductId=@productId and UserId=@userId";
			var parameters = new DynamicParameters();
			parameters.Add("@productId", ProductId);
			parameters.Add("@userId", UserId);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultCartDto>> GetCartItems(string UserId)
		{
			string query = "Select Product.ProductId, ProductName, ProductPrice, ProductImageUrl From Product Inner Join Cart On Product.ProductId = Cart.ProductId Inner Join AspNetUsers On AspNetUsers.Id=@userID Where Cart.UserId=@userId";

			var parameters = new DynamicParameters();
			parameters.Add("@userId", UserId);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryAsync<ResultCartDto>(query, parameters);
				return value.ToList();
			}
		}
	}
}
