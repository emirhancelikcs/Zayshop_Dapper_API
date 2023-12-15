using Dapper;
using ZayShop_Dapper_Api.Dtos.IndexCarouselDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.IndexCarouselRepository
{
	public class IndexCarouselRepository : IIndexCarouselRepository
	{
		private readonly Context _context;

		public IndexCarouselRepository(Context context)
		{
			_context = context;
		}

		public async void CreateIndexCarousel(CreateIndexCarouselDto createIndexCarouselDto)
		{
			string query = "Insert Into IndexCarousel (Header, Title, Description, ImageName) Values (@header, @title, @description, @image)";
			var parameters = new DynamicParameters();
			parameters.Add("@header", createIndexCarouselDto.Header);
			parameters.Add("@title", createIndexCarouselDto.Title);
			parameters.Add("@description", createIndexCarouselDto.Description);
			parameters.Add("@image", createIndexCarouselDto.ImageName);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteIndexCarousel(int id)
		{
			string query = "Delete From IndexCarousel Where IndexCarouselId=@indexCarouselId";
			var parameters = new DynamicParameters();
			parameters.Add("@indexCarouselId", id);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultIndexCarouselDto>> GetAllIndexCarouselAsync()
		{
			string query = "Select * From IndexCarousel";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultIndexCarouselDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdIndexCarouselDto> GetIndexCarousel(int id)
		{
			string query = "Select * From IndexCarousel Where IndexCarouselId=@indexCarouselId";
			var parameters = new DynamicParameters();
			parameters.Add("@indexCarouselId", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<GetByIdIndexCarouselDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateIndexCarousel(UpdateIndexCarouselDto updateIndexCarouselDto)
		{
			string query = "Update IndexCarousel Set Header=@header, Title=@title, Description=@description, ImageName=@image Where IndexCarouselId=@indexCarouselId";

			var parameters = new DynamicParameters();
			parameters.Add("@indexCarouselId", updateIndexCarouselDto.IndexCarouselId);
			parameters.Add("@header", updateIndexCarouselDto.Header);
			parameters.Add("@title", updateIndexCarouselDto.Title);
			parameters.Add("@description", updateIndexCarouselDto.Description);
			parameters.Add("@image", updateIndexCarouselDto.ImageName);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
