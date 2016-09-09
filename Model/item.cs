using System;
namespace Auction.Model
{
	/// <summary>
	/// item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class item
	{
		public item()
		{}
		#region Model
		private int _item_id;
		private string _item_name;
		private string _item_remark;
		private string _item_desc;
		private int _kind_id;
		private DateTime _addtime;
		private DateTime _endtime;
		private double _init_price;
		private double _max_price;
		private int _owner_id;
		private int? _winer_id;
		private int _state_id;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int item_id
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string item_name
		{
			set{ _item_name=value;}
			get{return _item_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string item_remark
		{
			set{ _item_remark=value;}
			get{return _item_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string item_desc
		{
			set{ _item_desc=value;}
			get{return _item_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int kind_id
		{
			set{ _kind_id=value;}
			get{return _kind_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double init_price
		{
			set{ _init_price=value;}
			get{return _init_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public double max_price
		{
			set{ _max_price=value;}
			get{return _max_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int owner_id
		{
			set{ _owner_id=value;}
			get{return _owner_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? winer_id
		{
			set{ _winer_id=value;}
			get{return _winer_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int state_id
		{
			set{ _state_id=value;}
			get{return _state_id;}
		}
		#endregion Model

	}
}

