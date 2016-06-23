using BanHang.Models.ServiceModel.Base;

namespace BanHang.Models.ServiceModel
{
	public class CustomerGroup : StoreModel
	{ 
		public string Note { get; set; }

		public int DiscountPercent { get; set; }
	}
}