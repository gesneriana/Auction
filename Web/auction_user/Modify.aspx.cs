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
namespace Auction.Web.auction_user
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int user_id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(user_id);
				}
			}
		}
			
	private void ShowInfo(int user_id)
	{
		Auction.BLL.auction_user bll=new Auction.BLL.auction_user();
		Auction.Model.auction_user model=bll.GetModel(user_id);
		this.lbluser_id.Text=model.user_id.ToString();
		this.txtusername.Text=model.username;
		this.txtuserpass.Text=model.userpass;
		this.txtemail.Text=model.email;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="username不能为空！\\n";	
			}
			if(this.txtuserpass.Text.Trim().Length==0)
			{
				strErr+="userpass不能为空！\\n";	
			}
			if(this.txtemail.Text.Trim().Length==0)
			{
				strErr+="email不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int user_id=int.Parse(this.lbluser_id.Text);
			string username=this.txtusername.Text;
			string userpass=this.txtuserpass.Text;
			string email=this.txtemail.Text;


			Auction.Model.auction_user model=new Auction.Model.auction_user();
			model.user_id=user_id;
			model.username=username;
			model.userpass=userpass;
			model.email=email;

			Auction.BLL.auction_user bll=new Auction.BLL.auction_user();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
