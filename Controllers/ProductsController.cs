using Microsoft.AspNetCore.Mvc;
using ZayShop_Dapper_Api.Dtos.ProductDtos;
using ZayShop_Dapper_Api.Repositories.ProductRepository;

namespace ZayShop_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductsController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var values = await _productRepository.GetAllProductAsync();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var value = await _productRepository.GetProductById(id);
			return Ok(value);
		}

		[HttpGet("ProductListWithCategory")]
		public async Task<IActionResult> ProductListWithCategory()
		{
			var values = await _productRepository.GetAllProductWithCategoryAsync();
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			_productRepository.CreateProduct(createProductDto);
			return Ok("başarılı");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			_productRepository.DeleteProduct(id);
			return Ok("Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			_productRepository.UpdateProduct(updateProductDto);
			return Ok("başarılı");
		}
	}
}
