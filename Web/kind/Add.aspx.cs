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
namespace Auction.Web.kind
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtkind_name.Text.Trim().Length==0)
			{
				strErr+="kind_name不能为空！\\n";	
			}
			if(this.txtkind_desc.Text.Trim().Length==0)
			{
				strErr+="kind_desc不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string kind_name=this.txtkind_name.Text;
			string kind_desc=this.txtkind_desc.Text;

			Auction.Model.kind model=new Auction.Model.kind();
			model.kind_name=kind_name;
			model.kind_desc=kind_desc;

			Auction.BLL.kind bll=new Auction.BLL.kind();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
