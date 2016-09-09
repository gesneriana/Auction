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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Auction.Web.state
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int state_id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(state_id);
				}
			}
		}
			
	private void ShowInfo(int state_id)
	{
		Auction.BLL.state bll=new Auction.BLL.state();
		Auction.Model.state model=bll.GetModel(state_id);
		this.lblstate_id.Text=model.state_id.ToString();
		this.txtstate_name.Text=model.state_name;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtstate_name.Text.Trim().Length==0)
			{
				strErr+="state_name不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int state_id=int.Parse(this.lblstate_id.Text);
			string state_name=this.txtstate_name.Text;


			Auction.Model.state model=new Auction.Model.state();
			model.state_id=state_id;
			model.state_name=state_name;

			Auction.BLL.state bll=new Auction.BLL.state();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
