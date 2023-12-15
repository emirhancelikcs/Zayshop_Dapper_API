using ZayShop_Dapper_Api.Dtos.CategoryDtos;

namespace ZayShop_Dapper_Api.Repositories.CategoryRepository
{
	public interface ICategoryRepository
	{
		Task<List<ResultCategoryDto>> GetAllCategoryAsync();
		void CreateCategory(CreateCategoryDto categoryDto);
		void DeleteCategory(int id);
		void UpdateCategory(UpdateCategoryDto categoryDto);
		Task<GetByIdCategoryDto> GetCategory(int id);
	}
}
