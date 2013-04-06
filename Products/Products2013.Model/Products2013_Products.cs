using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products2013.Model
{
    [Serializable]
    public partial class Products2013_Products
    {
        public Products2013_Products()
        { }
        #region Model
        private int _id;
        private string _huohao = "";
        private string _leibei = "";
        private string _productname = "";
        private decimal _pricefactory;
        private decimal _pricesell;
        private string _size = "";
        private string _pic = "";
        private decimal _weight = 0M;
        private DateTime _updateon = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HuoHao
        {
            set { _huohao = value; }
            get { return _huohao; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LeiBei
        {
            set { _leibei = value; }
            get { return _leibei; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PriceFactory
        {
            set { _pricefactory = value; }
            get { return _pricefactory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PriceSell
        {
            set { _pricesell = value; }
            get { return _pricesell; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateOn
        {
            set { _updateon = value; }
            get { return _updateon; }
        }
        #endregion Model
    }
}
