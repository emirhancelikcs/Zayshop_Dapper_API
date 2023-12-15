using Dapper;
using ZayShop_Dapper_Api.Dtos.FooterLeft;
using ZayShop_Dapper_Api.Dtos.FooterLeftDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.FooterLeftRepository
{
	public class FooterLeftRepository : IFooterLeftRepository
	{
		private readonly Context _context;

		public FooterLeftRepository(Context context)
		{
			_context = context;
		}

		public async void CreateFooterLeft(CreateFooterLeftDto createFooterLeft)
		{
			string query = "Insert Into FooterLeft (FooterLeftIcon, FooterLeftText, FooterLeftLinkUrl) Values (@footerLeftIcon, @footerLeftText, @footerLeftLinkUrl)";
			var parameters = new DynamicParameters();
			parameters.Add("footerLeftIcon", createFooterLeft.FooterLeftIcon);
			parameters.Add("footerLeftText", createFooterLeft.FooterLeftText);
			parameters.Add("footerLeftLinkUrl", createFooterLeft.FooterLeftLinkUrl);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteFooterLeft(int id)
		{
			string query = "Delete From FooterLeft Where FooterLeftId=@footerLeftId";
			var parameters = new DynamicParameters();
			parameters.Add("footerLeftId", id);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultFooterLeftDto>> GetAllFooterLeft()
		{
			string query = "Select * From FooterLeft";
			
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultFooterLeftDto>(query);
				return values.ToList();
			}
		}

		public async Task<ResultFooterLeftDto> GetFooterLeftById(int id)
		{
			string query = "Select * From FooterLeft Where FooterLeftId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<ResultFooterLeftDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateFooterLeft(UpdateFooterLeftDto updateFooterLeft)
		{
			string query = "Update FooterLeft Set FooterLeftIcon=@icon, FooterLeftText=@text, FooterLeftLinkUrl=@url Where FooterLeftId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", updateFooterLeft.FooterLeftId);
			parameters.Add("@icon", updateFooterLeft.FooterLeftIcon);
			parameters.Add("@text", updateFooterLeft.FooterLeftText);
			parameters.Add("@url", updateFooterLeft.FooterLeftLinkUrl);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
