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
namespace Auction.Web.state
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
					int state_id=(Convert.ToInt32(strid));
					ShowInfo(state_id);
				}
			}
		}
		
	private void ShowInfo(int state_id)
	{
		Auction.BLL.state bll=new Auction.BLL.state();
		Auction.Model.state model=bll.GetModel(state_id);
		this.lblstate_id.Text=model.state_id.ToString();
		this.lblstate_name.Text=model.state_name;

	}


    }
}
