using Dapper;
using ZayShop_Dapper_Api.Dtos.CategoriesOfTheMonthDtos;
using ZayShop_Dapper_Api.Dtos.CategoryOfTheMonthDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.CategoryOfTheMonthRepository
{
	public class CategoryOfTheMonthRepository : ICategoryOfTheMonthRepository
	{
		private readonly Context _context;

		public CategoryOfTheMonthRepository(Context context)
		{
			_context = context;
		}

		public async void CreateCategoryOfTheMonth(CreateCategoryOfTheMonthDto categoryOfTheMonthDto)
		{
			string query = "Insert Into CategoryOfTheMonth (CategoryOfTheMonthHeader, CategoryOfTheMonthTitle) Values (@categoryOfTheMonthHeader, @categoryOfTheMonthTitle)";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryOfTheMonthHeader", categoryOfTheMonthDto.CategoryOfTheMonthHeader);
			parameters.Add("@categoryOfTheMonthTitle", categoryOfTheMonthDto.CategoryOfTheMonthTitle);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteCategoryOfTheMonth(int id)
		{
			string query = "Delete From CategoryOfTheMonth Where CategoryOfTheMonthId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("id", id);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultCategoryOfTheMonthDto>> GetCategoryOfTheMonthAsync()
		{
			string query = "Select * From CategoryOfTheMonth";

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryAsync<ResultCategoryOfTheMonthDto>(query);
				return value.ToList();
			}
		}

		public async Task<ResultCategoryOfTheMonthDto> GetCategoryOFTheMonthById(int id)
		{
			string query = "Select * From CategoryOfTheMonth Where CategoryOfTheMonthId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("id", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<ResultCategoryOfTheMonthDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateCategoryOfTheMonth(UpdateCategoryOfTheMonthDto categoryOfTheMonthDto)
		{
			string query = "Update CategoryOfTheMonth Set CategoryOfTheMonthHeader=@categoryOfTheMonthHeader, CategoryOfTheMonthTitle=@categoryOfTheMonthTitle Where CategoryOfTheMonthId=@categoryOfTheMonthId";
			var parameters = new DynamicParameters();
			parameters.Add("@categoryOfTheMonthHeader", categoryOfTheMonthDto.CategoryOfTheMonthHeader);
			parameters.Add("@CategoryOfTheMonthTitle", categoryOfTheMonthDto.CategoryOfTheMonthTitle);
			parameters.Add("@categoryOfTheMonthId", categoryOfTheMonthDto.CategoryOfTheMonthId);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
