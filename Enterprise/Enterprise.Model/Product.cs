using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
	/// <summary>
	/// 类Product。
	/// </summary>
	[Serializable]
	public partial class Product
	{
		public Product()
		{}
		#region Model
		private int _productid;
		private int _categoryid=0;
		private string _name="";
		private string _brand="";
		private string _type="";
		private string _description="";
		private string _content="";
		private string _imgurl="";
		private string _thumburl="";
		private int _status=1;
		private int? _click=0;
		private int _sortindex=0;
		private int _createuserid=0;
		private DateTime _createdate= DateTime.Now;
		private int _updateuserid=0;
		private DateTime _updatedate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 分类编号
		/// </summary>
		public int CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 产品名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 产品品牌
		/// </summary>
		public string Brand
		{
			set{ _brand=value;}
			get{return _brand;}
		}
		/// <summary>
		/// 产品型号
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 产品描述
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 产品介绍
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 产品图片路径
		/// </summary>
		public string ImgUrl
		{
			set{ _imgurl=value;}
			get{return _imgurl;}
		}
		/// <summary>
		/// 产品缩略图路径
		/// </summary>
		public string ThumbUrl
		{
			set{ _thumburl=value;}
			get{return _thumburl;}
		}
		/// <summary>
		/// 状态 0不显示 1显示
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 点击次数
		/// </summary>
		public int? Click
		{
			set{ _click=value;}
			get{return _click;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int SortIndex
		{
			set{ _sortindex=value;}
			get{return _sortindex;}
		}
		/// <summary>
		/// 创建用户编号
		/// </summary>
		public int CreateUserId
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 更新用户编号
		/// </summary>
		public int UpdateUserId
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 更新日期
		/// </summary>
		public DateTime UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model


	}
}

