using ZayShop_Dapper_Api.Dtos.InfosDtos;

namespace ZayShop_Dapper_Api.Repositories.InfosRepository
{
	public interface IInfosRepository
	{
		Task<ResultInfosDto> GetInfosAsync();
		void UpdateInfo (UpdateInfosDto infosDto);
	}
}
