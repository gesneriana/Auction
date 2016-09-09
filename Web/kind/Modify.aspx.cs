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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int kind_id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(kind_id);
				}
			}
		}
			
	private void ShowInfo(int kind_id)
	{
		Auction.BLL.kind bll=new Auction.BLL.kind();
		Auction.Model.kind model=bll.GetModel(kind_id);
		this.lblkind_id.Text=model.kind_id.ToString();
		this.txtkind_name.Text=model.kind_name;
		this.txtkind_desc.Text=model.kind_desc;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int kind_id=int.Parse(this.lblkind_id.Text);
			string kind_name=this.txtkind_name.Text;
			string kind_desc=this.txtkind_desc.Text;


			Auction.Model.kind model=new Auction.Model.kind();
			model.kind_id=kind_id;
			model.kind_name=kind_name;
			model.kind_desc=kind_desc;

			Auction.BLL.kind bll=new Auction.BLL.kind();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
