using Dapper;
using ZayShop_Dapper_Api.Dtos.NavbarLinkDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.NavbarLinkRepository
{
	public class NavbarLinkRepository : INavbarLinkRepository
	{
		private readonly Context _context;

		public NavbarLinkRepository(Context context)
		{
			_context = context;
		}

		public async void CreateNavbarLink(CreateNavbarLinkDto createNavbarLinkDto)
		{
			string query = "Insert Into NavbarLink (NavbarLinkText, NavbarLinkController, NavbarLinkAction) Values (@navbarLinkText, @navbarLinkController, @navbarLinkAction)";
			var parameters = new DynamicParameters();
			parameters.Add("@navbarLinkText", createNavbarLinkDto.NavbarLinkText);
			parameters.Add("@navbarLinkController", createNavbarLinkDto.NavbarLinkController);
			parameters.Add("@navbarLinkAction", createNavbarLinkDto.NavbarLinkAction);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async void DeleteNavbarLink(int navbarLinkId)
		{
			string query = "Delete From NavbarLink Where NavbarLinkId=@navbarLinkId";
			var parameters = new DynamicParameters();
			parameters.Add("@navbarLinkId", navbarLinkId);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}

		public async Task<List<ResultNavbarLinkDto>> GetAllNavbarLink()
		{
			string query = "Select * From NavbarLink";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultNavbarLinkDto>(query);
				return values.ToList();
			}
		}

		public async Task<ResultNavbarLinkDto> GetNavbarLinkById(int id)
		{
			string query = "Select * From NavbarLink Where NavbarLinkId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);

			using (var connection = _context.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<ResultNavbarLinkDto>(query, parameters);
				return value;
			}
		}

		public async void UpdateNavbarLink(UpdateNavbarLinkDto updateNavbarLinkDto)
		{
			string query = "Update NavbarLink Set NavbarLinkText=@text, NavbarLinkController=@controller, NavbarLinkAction=@action Where NavbarLinkId=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", updateNavbarLinkDto.NavbarLinkId);
			parameters.Add("@text", updateNavbarLinkDto.NavbarLinkText);
			parameters.Add("@controller", updateNavbarLinkDto.NavbarLinkController);
			parameters.Add("@action", updateNavbarLinkDto.NavbarLinkAction);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
