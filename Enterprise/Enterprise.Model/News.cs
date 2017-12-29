using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Enterprise.Model
{
    /// <summary>
    /// 类News。
    /// </summary>
    [Serializable]
    public partial class News
    {
        public News()
        { }
        #region Model
        private int _newsid;
        private int _categoryid = 0;
        private string _title = "";
        private string _content = "";
        private int _status = 1;
        private int _click = 0;
        private int _createuserid = 0;
        private DateTime _createdate = DateTime.Now;
        private int _updateuserid = 0;
        private DateTime _updatedate = DateTime.Now;

        /// <summary>
        /// 新闻编号
        /// </summary>
        public int NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 状态 0不显示 1显示
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int Click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 创建用户编号
        /// </summary>
        public int CreateUserId
        {
            set { _createuserid = value; }
            get { return _createuserid; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 更新用户编号
        /// </summary>
        public int UpdateUserId
        {
            set { _updateuserid = value; }
            get { return _updateuserid; }
        }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

        #region Extension Property
        public string StatusName { get; set; }

        public string CategoryName { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        #endregion
    }
}

