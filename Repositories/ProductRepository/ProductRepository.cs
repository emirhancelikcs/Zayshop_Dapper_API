using Dapper;
using ZayShop_Dapper_Api.Dtos.ProductDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.ProductRepository
{
	public class ProductRepository : IProductRepository
	{
		private readonly Context _context;

		public ProductRepository(Context context)
		{
			_context = context;
		}

		public async void CreateProduct(CreateProductDto createProductDto)
		{
			string query = "Insert Into Product (ProductName, ProductPrice, ProductDescription, ProductBrand, ProductImageUrl, ProductCategory) Values (@productName, @productPrice, @productDescription, @productBrand, @productImageUrl, @productCategory)";
			var parameters = new DynamicParameters();
			parameters.Add("@productName", createProductDto.ProductName);
			parameters.Add("@productPrice", createProductDto.ProductPrice);
			parameters.Add("@productDescription", createProductDto.ProductDescription);
			parameters.Add("@productBrand", createProductDto.ProductBrand);
			parameters.Add("@productImageUrl", createProductDto.ProductImageUrl);
			parameters.Add("@productCategory", createProductDto.ProductCategory);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async  void DeleteProduct(int id)
		{
			string query = "Delete From Product Where ProductId=@productId";
			var parameters = new DynamicParameters();
			parameters.Add("@productId", id);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultProductDto>> GetAllProductAsync()
		{
			string query = "Select * From Product";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductDto>(query);
				return values.ToList();
			}
		}

		public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
		{
			string query = "Select ProductId, ProductName, ProductPrice, ProductDescription, ProductRating, ProductBrand, ProductImageUrl, CategoryName From Product Inner Join Category On Category.CategoryId=Product.ProductCategory";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
				return values.ToList();
			}
		}

		public async Task<ResultProductDto> GetProductById(int id)
		{
			string query = "Select * From Product Where ProductId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<ResultProductDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateProduct(UpdateProductDto updateProductDto)
		{
			string query = "Update Product Set ProductName=@name, ProductPrice=@price, ProductDescription=@desc, ProductBrand=@brand, ProductImageUrl=@url, ProductCategory=@category Where ProductId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", updateProductDto.ProductId);
			parameters.Add("@name", updateProductDto.ProductName);
			parameters.Add("@price", updateProductDto.ProductPrice);
			parameters.Add("@desc", updateProductDto.ProductDescription);
			parameters.Add("@brand", updateProductDto.ProductBrand);
			parameters.Add("@url", updateProductDto.ProductImageUrl);
			parameters.Add("@category", updateProductDto.ProductCategory);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
