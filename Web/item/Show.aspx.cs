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
namespace Auction.Web.item
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
					int item_id=(Convert.ToInt32(strid));
					ShowInfo(item_id);
				}
			}
		}
		
	private void ShowInfo(int item_id)
	{
		Auction.BLL.item bll=new Auction.BLL.item();
		Auction.Model.item model=bll.GetModel(item_id);
		this.lblitem_id.Text=model.item_id.ToString();
		this.lblitem_name.Text=model.item_name;
		this.lblitem_remark.Text=model.item_remark;
		this.lblitem_desc.Text=model.item_desc;
		this.lblkind_id.Text=model.kind_id.ToString();
		this.lbladdtime.Text=model.addtime.ToString();
		this.lblendtime.Text=model.endtime.ToString();
		this.lblinit_price.Text=model.init_price;
		this.lblmax_price.Text=model.max_price;
		this.lblowner_id.Text=model.owner_id.ToString();
		this.lblwiner_id.Text=model.winer_id.ToString();
		this.lblstate_id.Text=model.state_id.ToString();

	}


    }
}
