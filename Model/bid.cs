using System;
namespace Auction.Model
{
	/// <summary>
	/// bid:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class bid
	{
		public bid()
		{}
		#region Model
		private int _bid_id;
		private int _user_id;
		private int _item_id;
		private double _bid_price;
		private DateTime _bid_date;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int bid_id
		{
			set{ _bid_id=value;}
			get{return _bid_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int item_id
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double bid_price
		{
			set{ _bid_price=value;}
			get{return _bid_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime bid_date
		{
			set{ _bid_date=value;}
			get{return _bid_date;}
		}
		#endregion Model

	}
}

