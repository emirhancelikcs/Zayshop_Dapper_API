using Dapper;
using ZayShop_Dapper_Api.Dtos.FooterRightDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.FooterRightRepository
{
	public class FooterRightRepository : IFooterRightRepository
	{
		private readonly Context _context;

		public FooterRightRepository(Context context)
		{
			_context = context;
		}

		public async void CreateFooterRight(CreateFooterRightDto createFooterRight)
		{
			string query = "Insert Into FooterRight (FooterRightText, FooterRightLinkController, FooterRightLinkAction) Values (@footerRightText, @footerRightLinkController, @footerRightLinkAction)";
			var parameters = new DynamicParameters();
			parameters.Add("footerRightText", createFooterRight.FooterRightText);
			parameters.Add("footerRightLinkController", createFooterRight.FooterRightLinkController);
			parameters.Add("FooterRightLinkAction", createFooterRight.FooterRightLinkAction);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteFooterRight(int id)
		{
			string query = "Delete From FooterRight Where FooterRightId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultFooterRightDto>> GetAllFooterRight()
		{
			string query = "Select * From FooterRight";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultFooterRightDto>(query);
				return values.ToList();
			}
		}

		public async Task<ResultFooterRightDto> GetFooterRightByID(int id)
		{
			string query = "Select * From FooterRight Where FooterRightId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<ResultFooterRightDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateFooterRight(UpdateFooterRightDto updateFooterRight)
		{
			string query = "Update FooterRight Set FooterRightText=@text, FooterRightLinkController=@controller, FooterRightLinkAction=@action Where FooterRightId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", updateFooterRight.FooterRightId);
			parameters.Add("@text", updateFooterRight.FooterRightText);
			parameters.Add("@controller", updateFooterRight.FooterRightLinkController);
			parameters.Add("@action", updateFooterRight.FooterRightLinkAction);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
