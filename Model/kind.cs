using System;
namespace Auction.Model
{
	/// <summary>
	/// kind:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class kind
	{
		public kind()
		{}
		#region Model
		private int _kind_id;
		private string _kind_name;
		private string _kind_desc;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int kind_id
		{
			set{ _kind_id=value;}
			get{return _kind_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kind_name
		{
			set{ _kind_name=value;}
			get{return _kind_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kind_desc
		{
			set{ _kind_desc=value;}
			get{return _kind_desc;}
		}
		#endregion Model

	}
}

