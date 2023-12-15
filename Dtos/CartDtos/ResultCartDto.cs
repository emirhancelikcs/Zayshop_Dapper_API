namespace ZayShop_Dapper_Api.Dtos.CartDtos
{
	public class ResultCartDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int ProductPrice{ get; set; }
		public string ProductImageUrl{ get; set; }
	}
}
