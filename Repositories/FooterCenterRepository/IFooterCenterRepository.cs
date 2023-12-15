using ZayShop_Dapper_Api.Dtos.FooterCenterDtos;

namespace ZayShop_Dapper_Api.Repositories.FooterCenterRepository
{
	public interface IFooterCenterRepository
	{
		Task<List<ResultFooterCenterDto>> GetAllFooterCenter();
		void CreateFooterCenter(CreateFooterCenterDto createFooterCenter);
		void UpdateFooterCenter(UpdateFooterCenterDto updateFooterCenter);
		void DeleteFooterCenter(int id);
		Task<ResultFooterCenterDto> GetFooterCenterById(int id);
	}
}
