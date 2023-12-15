namespace ZayShop_Dapper_Api.Dtos.FooterRightDtos
{
	public class UpdateFooterRightDto
	{
		public int FooterRightId { get; set; }
		public string FooterRightText { get; set; }
		public string FooterRightLinkController { get; set; }
		public string FooterRightLinkAction { get; set; }
	}
}
