using ZayShop_Dapper_Api.Dtos.IndexCarouselDtos;

namespace ZayShop_Dapper_Api.Repositories.IndexCarouselRepository
{
	public interface IIndexCarouselRepository
	{
		Task<List<ResultIndexCarouselDto>> GetAllIndexCarouselAsync();
		void CreateIndexCarousel(CreateIndexCarouselDto createIndexCarouselDto);
		void DeleteIndexCarousel(int id);
		void UpdateIndexCarousel(UpdateIndexCarouselDto updateIndexCarouselDto);
		Task<GetByIdIndexCarouselDto> GetIndexCarousel(int id);
	}
}
