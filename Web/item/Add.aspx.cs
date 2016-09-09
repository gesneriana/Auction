﻿using System;
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
namespace Auction.Web.item
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtitem_name.Text.Trim().Length==0)
			{
				strErr+="item_name不能为空！\\n";	
			}
			if(this.txtitem_remark.Text.Trim().Length==0)
			{
				strErr+="item_remark不能为空！\\n";	
			}
			if(this.txtitem_desc.Text.Trim().Length==0)
			{
				strErr+="item_desc不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtkind_id.Text))
			{
				strErr+="kind_id格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtaddtime.Text))
			{
				strErr+="addtime格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtendtime.Text))
			{
				strErr+="endtime格式错误！\\n";	
			}
			if(this.txtinit_price.Text.Trim().Length==0)
			{
				strErr+="init_price不能为空！\\n";	
			}
			if(this.txtmax_price.Text.Trim().Length==0)
			{
				strErr+="max_price不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtowner_id.Text))
			{
				strErr+="owner_id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtwiner_id.Text))
			{
				strErr+="winer_id格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtstate_id.Text))
			{
				strErr+="state_id格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string item_name=this.txtitem_name.Text;
			string item_remark=this.txtitem_remark.Text;
			string item_desc=this.txtitem_desc.Text;
			int kind_id=int.Parse(this.txtkind_id.Text);
			DateTime addtime=DateTime.Parse(this.txtaddtime.Text);
			DateTime endtime=DateTime.Parse(this.txtendtime.Text);
			string init_price=this.txtinit_price.Text;
			string max_price=this.txtmax_price.Text;
			int owner_id=int.Parse(this.txtowner_id.Text);
			int winer_id=int.Parse(this.txtwiner_id.Text);
			int state_id=int.Parse(this.txtstate_id.Text);

			Auction.Model.item model=new Auction.Model.item();
			model.item_name=item_name;
			model.item_remark=item_remark;
			model.item_desc=item_desc;
			model.kind_id=kind_id;
			model.addtime=addtime;
			model.endtime=endtime;
			model.init_price=init_price;
			model.max_price=max_price;
			model.owner_id=owner_id;
			model.winer_id=winer_id;
			model.state_id=state_id;

			Auction.BLL.item bll=new Auction.BLL.item();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
