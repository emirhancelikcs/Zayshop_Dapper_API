using ZayShop_Dapper_Api.Dtos.NavbarLinkDtos;

namespace ZayShop_Dapper_Api.Repositories.NavbarLinkRepository
{
	public interface INavbarLinkRepository
	{
		void DeleteNavbarLink(int navbarLinkId);
		void CreateNavbarLink(CreateNavbarLinkDto createNavbarLinkDto);
		void UpdateNavbarLink(UpdateNavbarLinkDto updateNavbarLinkDto);
		Task<List<ResultNavbarLinkDto>> GetAllNavbarLink();
		Task<ResultNavbarLinkDto> GetNavbarLinkById(int id);
	}
}
