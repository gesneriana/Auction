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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			int user_id=int.Parse(this.txtuser_id.Text);
			int item_id=int.Parse(this.txtitem_id.Text);
			string bid_price=this.txtbid_price.Text;
			DateTime bid_date=DateTime.Parse(this.txtbid_date.Text);

			Auction.Model.bid model=new Auction.Model.bid();
			model.user_id=user_id;
			model.item_id=item_id;
			model.bid_price=bid_price;
			model.bid_date=bid_date;

			Auction.BLL.bid bll=new Auction.BLL.bid();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
