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
namespace Auction.Web.auction_user
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
					int user_id=(Convert.ToInt32(strid));
					ShowInfo(user_id);
				}
			}
		}
		
	private void ShowInfo(int user_id)
	{
		Auction.BLL.auction_user bll=new Auction.BLL.auction_user();
		Auction.Model.auction_user model=bll.GetModel(user_id);
		this.lbluser_id.Text=model.user_id.ToString();
		this.lblusername.Text=model.username;
		this.lbluserpass.Text=model.userpass;
		this.lblemail.Text=model.email;

	}


    }
}
