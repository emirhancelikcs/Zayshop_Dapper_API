using ZayShop_Dapper_Api.Dtos.FooterLeft;
using ZayShop_Dapper_Api.Dtos.FooterLeftDtos;

namespace ZayShop_Dapper_Api.Repositories.FooterLeftRepository
{
	public interface IFooterLeftRepository
	{
		Task<List<ResultFooterLeftDto>> GetAllFooterLeft();
		Task<ResultFooterLeftDto> GetFooterLeftById(int id);
		void CreateFooterLeft(CreateFooterLeftDto createFooterLeft);
		void DeleteFooterLeft(int id);
		void UpdateFooterLeft(UpdateFooterLeftDto updateFooterLeft);
	}
}
