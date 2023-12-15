using ZayShop_Dapper_Api.Dtos.ProductDtos;

namespace ZayShop_Dapper_Api.Repositories.ProductRepository
{
	public interface IProductRepository
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
		void CreateProduct(CreateProductDto createProductDto);
		void DeleteProduct(int id);
		Task<ResultProductDto> GetProductById(int id);
		void UpdateProduct(UpdateProductDto updateProductDto);
	}
}
