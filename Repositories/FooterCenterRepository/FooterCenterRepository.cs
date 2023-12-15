using Dapper;
using ZayShop_Dapper_Api.Dtos.FooterCenterDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.FooterCenterRepository
{
	public class FooterCenterRepository : IFooterCenterRepository
	{
		private readonly Context _context;

		public FooterCenterRepository(Context context)
		{
			_context = context;
		}

		public async void CreateFooterCenter(CreateFooterCenterDto createFooterCenter)
		{
			string query = "Insert Into FooterCenter (FooterCenterText, FooterCenterLinkController, FooterCenterLinkAction) Values (@footerCenterText, @footerCenterLinkController, @footerCenterLinkAction)";
			var parameters = new DynamicParameters();
			parameters.Add("footerCenterText", createFooterCenter.FooterCenterText);
			parameters.Add("footerCenterLinkController", createFooterCenter.FooterCenterLinkController);
			parameters.Add("footerCenterLinkAction", createFooterCenter.FooterCenterLinkAction);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteFooterCenter(int id)
		{
			string query = "Delete From FooterCenter Where FooterCenterId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultFooterCenterDto>> GetAllFooterCenter()
		{
			string query = "Select * From FooterCenter";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultFooterCenterDto>(query);
				return values.ToList();
			}
		}

		public async Task<ResultFooterCenterDto> GetFooterCenterById(int id)
		{
			string query = "Select * From FooterCenter Where FooterCenterId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<ResultFooterCenterDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateFooterCenter(UpdateFooterCenterDto updateFooterCenter)
		{
			string query = "Update FooterCenter Set FooterCenterText=@text, FooterCenterLinkController=@controller, FooterCenterLinkAction=@action Where FooterCenterId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", updateFooterCenter.FooterCenterId);
			parameters.Add("@text", updateFooterCenter.FooterCenterText);
			parameters.Add("@controller", updateFooterCenter.FooterCenterLinkController);
			parameters.Add("@action", updateFooterCenter.FooterCenterLinkAction);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
