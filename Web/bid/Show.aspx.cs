using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace Auction.Web.bid
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int bid_id=(Convert.ToInt32(strid));
					ShowInfo(bid_id);
				}
			}
		}
		
	private void ShowInfo(int bid_id)
	{
		Auction.BLL.bid bll=new Auction.BLL.bid();
		Auction.Model.bid model=bll.GetModel(bid_id);
		this.lblbid_id.Text=model.bid_id.ToString();
		this.lbluser_id.Text=model.user_id.ToString();
		this.lblitem_id.Text=model.item_id.ToString();
		this.lblbid_price.Text=model.bid_price;
		this.lblbid_date.Text=model.bid_date.ToString();

	}


    }
}
