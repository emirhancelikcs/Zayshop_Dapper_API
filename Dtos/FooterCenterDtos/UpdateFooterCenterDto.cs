namespace ZayShop_Dapper_Api.Dtos.FooterCenterDtos
{
	public class UpdateFooterCenterDto
	{
		public int FooterCenterId { get; set; }
		public string FooterCenterText { get; set; }
		public string FooterCenterLinkController { get; set; }
		public string FooterCenterLinkAction { get; set; }
	}
}
