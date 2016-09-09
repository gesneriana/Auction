using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Auction.DAL
{
	/// <summary>
	/// 数据访问类:item
	/// </summary>
	public partial class item
	{
		public item()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("item_id", "item"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int item_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from item");
			strSql.Append(" where item_id=@item_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@item_id", MySqlDbType.Int32)
			};
			parameters[0].Value = item_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Auction.Model.item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into item(");
			strSql.Append("item_name,item_remark,item_desc,kind_id,addtime,endtime,init_price,max_price,owner_id,winer_id,state_id)");
			strSql.Append(" values (");
			strSql.Append("@item_name,@item_remark,@item_desc,@kind_id,@addtime,@endtime,@init_price,@max_price,@owner_id,@winer_id,@state_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@item_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@item_remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@item_desc", MySqlDbType.VarChar,255),
					new MySqlParameter("@kind_id", MySqlDbType.Int32,11),
					new MySqlParameter("@addtime", MySqlDbType.Date),
					new MySqlParameter("@endtime", MySqlDbType.Date),
					new MySqlParameter("@init_price", MySqlDbType.Double),
					new MySqlParameter("@max_price", MySqlDbType.Double),
					new MySqlParameter("@owner_id", MySqlDbType.Int32,11),
					new MySqlParameter("@winer_id", MySqlDbType.Int32,11),
					new MySqlParameter("@state_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.item_name;
			parameters[1].Value = model.item_remark;
			parameters[2].Value = model.item_desc;
			parameters[3].Value = model.kind_id;
			parameters[4].Value = model.addtime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.init_price;
			parameters[7].Value = model.max_price;
			parameters[8].Value = model.owner_id;
            parameters[9].Value = model.winer_id == 0 ? null : model.winer_id;
			parameters[10].Value = model.state_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Auction.Model.item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update item set ");
			strSql.Append("item_name=@item_name,");
			strSql.Append("item_remark=@item_remark,");
			strSql.Append("item_desc=@item_desc,");
			strSql.Append("kind_id=@kind_id,");
			strSql.Append("addtime=@addtime,");
			strSql.Append("endtime=@endtime,");
			strSql.Append("init_price=@init_price,");
			strSql.Append("max_price=@max_price,");
			strSql.Append("owner_id=@owner_id,");
			strSql.Append("winer_id=@winer_id,");
			strSql.Append("state_id=@state_id");
			strSql.Append(" where item_id=@item_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@item_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@item_remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@item_desc", MySqlDbType.VarChar,255),
					new MySqlParameter("@kind_id", MySqlDbType.Int32,11),
					new MySqlParameter("@addtime", MySqlDbType.Date),
					new MySqlParameter("@endtime", MySqlDbType.Date),
					new MySqlParameter("@init_price", MySqlDbType.Double),
					new MySqlParameter("@max_price", MySqlDbType.Double),
					new MySqlParameter("@owner_id", MySqlDbType.Int32,11),
					new MySqlParameter("@winer_id", MySqlDbType.Int32,11),
					new MySqlParameter("@state_id", MySqlDbType.Int32,11),
					new MySqlParameter("@item_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.item_name;
			parameters[1].Value = model.item_remark;
			parameters[2].Value = model.item_desc;
			parameters[3].Value = model.kind_id;
			parameters[4].Value = model.addtime;
			parameters[5].Value = model.EndTime;
			parameters[6].Value = model.init_price;
			parameters[7].Value = model.max_price;
			parameters[8].Value = model.owner_id;
			parameters[9].Value = model.winer_id;
			parameters[10].Value = model.state_id;
			parameters[11].Value = model.item_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int item_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from item ");
			strSql.Append(" where item_id=@item_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@item_id", MySqlDbType.Int32)
			};
			parameters[0].Value = item_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string item_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from item ");
			strSql.Append(" where item_id in ("+item_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Auction.Model.item GetModel(int item_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select item_id,item_name,item_remark,item_desc,kind_id,addtime,endtime,init_price,max_price,owner_id,winer_id,state_id from item ");
			strSql.Append(" where item_id=@item_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@item_id", MySqlDbType.Int32)
			};
			parameters[0].Value = item_id;

			Auction.Model.item model=new Auction.Model.item();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Auction.Model.item DataRowToModel(DataRow row)
        {
            Auction.Model.item model = new Auction.Model.item();
            if (row != null)
            {
                if (row["item_id"] != null && row["item_id"].ToString() != "")
                {
                    model.item_id = int.Parse(row["item_id"].ToString());
                }
                if (row["item_name"] != null)
                {
                    model.item_name = row["item_name"].ToString();
                }
                if (row["item_remark"] != null)
                {
                    model.item_remark = row["item_remark"].ToString();
                }
                if (row["item_desc"] != null)
                {
                    model.item_desc = row["item_desc"].ToString();
                }
                if (row["kind_id"] != null && row["kind_id"].ToString() != "")
                {
                    model.kind_id = int.Parse(row["kind_id"].ToString());
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["endtime"] != null && row["endtime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(row["endtime"].ToString());
                }
                model.init_price = row["init_price"] == null || "".Equals(row["init_price"].ToString()) ? 0 : (double)row["init_price"];
                model.max_price = row["max_price"] == null || "".Equals(row["max_price"].ToString()) ? 0 : (double)row["max_price"];
                if (row["owner_id"] != null && row["owner_id"].ToString() != "")
                {
                    model.owner_id = int.Parse(row["owner_id"].ToString());
                }
                if (row["winer_id"] != null && row["winer_id"].ToString() != "")
                {
                    model.winer_id = int.Parse(row["winer_id"].ToString());
                }
                if (row["state_id"] != null && row["state_id"].ToString() != "")
                {
                    model.state_id = int.Parse(row["state_id"].ToString());
                }
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select item_id,item_name,item_remark,item_desc,kind_id,addtime,endtime,init_price,max_price,owner_id,winer_id,state_id ");
			strSql.Append(" FROM item ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM item ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.item_id desc");
			}
			strSql.Append(")AS Row, T.*  from item T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "item";
			parameters[1].Value = "item_id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

