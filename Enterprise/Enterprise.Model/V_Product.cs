using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
	/// <summary>
	/// 类V_Product。
	/// </summary>
	[Serializable]
	public partial class V_Product
	{
		public V_Product()
		{}
		#region Model
		private int _productid;
		private int _categoryid;
		private string _name;
		private string _brand;
		private string _type;
		private string _description;
		private string _content;
		private string _imgurl;
		private string _thumburl;
		private int _status;
		private int _click;
		private int _sortindex;
		private int _createuserid;
		private DateTime _createdate;
		private int _updateuserid;
		private DateTime _updatedate;
		private string _categoryname;
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Brand
		{
			set{ _brand=value;}
			get{return _brand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ThumbUrl
		{
			set{ _thumburl=value;}
			get{return _thumburl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SortIndex
		{
			set{ _sortindex=value;}
			get{return _sortindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CreateUserId
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UpdateUserId
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CategoryName
		{
			set{ _categoryname=value;}
			get{return _categoryname;}
		}
		#endregion Model


        #region 扩展属性
        public string StatusName { get; set; }

        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion

    }
}

