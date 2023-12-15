using ZayShop_Dapper_Api.Dtos.FooterRightDtos;

namespace ZayShop_Dapper_Api.Repositories.FooterRightRepository
{
	public interface IFooterRightRepository
	{
		Task<List<ResultFooterRightDto>> GetAllFooterRight();
		void CreateFooterRight(CreateFooterRightDto createFooterRight);
		void UpdateFooterRight(UpdateFooterRightDto updateFooterRight);
		void DeleteFooterRight(int id);
		Task<ResultFooterRightDto> GetFooterRightByID(int id);
	}
}
