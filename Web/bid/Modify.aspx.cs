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
namespace Auction.Web.bid
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int bid_id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(bid_id);
				}
			}
		}
			
	private void ShowInfo(int bid_id)
	{
		Auction.BLL.bid bll=new Auction.BLL.bid();
		Auction.Model.bid model=bll.GetModel(bid_id);
		this.lblbid_id.Text=model.bid_id.ToString();
		this.txtuser_id.Text=model.user_id.ToString();
		this.txtitem_id.Text=model.item_id.ToString();
		this.txtbid_price.Text=model.bid_price;
		this.txtbid_date.Text=model.bid_date.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtuser_id.Text))
			{
				strErr+="user_id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtitem_id.Text))
			{
				strErr+="item_id格式错误！\\n";	
			}
			if(this.txtbid_price.Text.Trim().Length==0)
			{
				strErr+="bid_price不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtbid_date.Text))
			{
				strErr+="bid_date格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int bid_id=int.Parse(this.lblbid_id.Text);
			int user_id=int.Parse(this.txtuser_id.Text);
			int item_id=int.Parse(this.txtitem_id.Text);
			string bid_price=this.txtbid_price.Text;
			DateTime bid_date=DateTime.Parse(this.txtbid_date.Text);


			Auction.Model.bid model=new Auction.Model.bid();
			model.bid_id=bid_id;
			model.user_id=user_id;
			model.item_id=item_id;
			model.bid_price=bid_price;
			model.bid_date=bid_date;

			Auction.BLL.bid bll=new Auction.BLL.bid();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
