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
namespace Auction.Web.kind
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
					int kind_id=(Convert.ToInt32(strid));
					ShowInfo(kind_id);
				}
			}
		}
		
	private void ShowInfo(int kind_id)
	{
		Auction.BLL.kind bll=new Auction.BLL.kind();
		Auction.Model.kind model=bll.GetModel(kind_id);
		this.lblkind_id.Text=model.kind_id.ToString();
		this.lblkind_name.Text=model.kind_name;
		this.lblkind_desc.Text=model.kind_desc;

	}


    }
}
