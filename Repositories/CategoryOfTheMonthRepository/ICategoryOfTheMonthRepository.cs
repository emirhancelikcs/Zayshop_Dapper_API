using ZayShop_Dapper_Api.Dtos.CategoriesOfTheMonthDtos;
using ZayShop_Dapper_Api.Dtos.CategoryDtos;
using ZayShop_Dapper_Api.Dtos.CategoryOfTheMonthDtos;

namespace ZayShop_Dapper_Api.Repositories.CategoryOfTheMonthRepository
{
	public interface ICategoryOfTheMonthRepository
	{
		//Task<List<ResultCategoryOfTheMonthDto>> GetAllCategoryAsync();
		void CreateCategoryOfTheMonth(CreateCategoryOfTheMonthDto categoryOfTheMonthDto);
		void DeleteCategoryOfTheMonth(int id);
		void UpdateCategoryOfTheMonth(UpdateCategoryOfTheMonthDto categoryOfTheMonthDto);
		Task<List<ResultCategoryOfTheMonthDto>> GetCategoryOfTheMonthAsync();
		Task<ResultCategoryOfTheMonthDto> GetCategoryOFTheMonthById(int id);
	}
}
