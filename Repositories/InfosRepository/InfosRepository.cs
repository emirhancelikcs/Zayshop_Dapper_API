using Dapper;
using ZayShop_Dapper_Api.Dtos.InfosDtos;
using ZayShop_Dapper_Api.Models.DapperContext;

namespace ZayShop_Dapper_Api.Repositories.InfosRepository
{
	public class InfosRepository : IInfosRepository
	{
		private readonly Context _context;

		public InfosRepository(Context context)
		{
			_context = context;
		}

		public async Task<ResultInfosDto> GetInfosAsync()
		{
			string query = "Select * From Infos";

			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<ResultInfosDto>(query);
				return values;
			}
		}

		public async void UpdateInfo(UpdateInfosDto infosDto)
		{
			string query = "Update Infos Set InfosEmail=@email, InfosPhone=@phone, InfosFacebookAddress=@fb, InfosInstagramAddress=@ig, InfosTwitterAddress=@tw, InfosLinkedinAddress=@li Where InfosId=1";
			var parameters = new DynamicParameters();
			parameters.Add("@email", infosDto.InfosEmail);
			parameters.Add("@phone", infosDto.InfosPhone);
			parameters.Add("@fb", infosDto.InfosFacebookAddress);
			parameters.Add("@ig", infosDto.InfosInstagramAddress);
			parameters.Add("@tw", infosDto.InfosTwitterAddress);
			parameters.Add("@li", infosDto.InfosLinkedinAddress);

			using (var connection = _context.CreateConnection())
				await connection.ExecuteAsync(query, parameters);
		}
	}
}
