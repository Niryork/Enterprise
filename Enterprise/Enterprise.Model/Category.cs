using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Enterprise.Model
{
	/// <summary>
	/// 类Category。
	/// </summary>
	[Serializable]
	public partial class Category
	{
		public Category()
		{}
		#region Model
		private int _categoryid;
		private string _name="";
		private int _type=1;
		private int _parentid=0;
		private int _status=1;
		private int _sortindex=0;
		private string _url="";
		private string _content="";
		private string _idpath="";
		private int _depth=1;
		private int _haschildren=0;
		/// <summary>
		/// 分类编号
		/// </summary>
		public int CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 分类类型 1链接 2内容页 3新闻列表 4产品列表
		/// </summary>
		public int Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 父级分类编号
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		/// 排序
		/// </summary>
		public int SortIndex
		{
			set{ _sortindex=value;}
			get{return _sortindex;}
		}
		/// <summary>
		/// 跳转链接
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 分类编号路径
		/// </summary>
		public string IdPath
		{
			set{ _idpath=value;}
			get{return _idpath;}
		}
		/// <summary>
		/// 分类深度
		/// </summary>
		public int Depth
		{
			set{ _depth=value;}
			get{return _depth;}
		}
		/// <summary>
		/// 是否有子分类 0否 1是
		/// </summary>
		public int HasChildren
		{
			set{ _haschildren=value;}
			get{return _haschildren;}
		}
		#endregion Model

	}
}

