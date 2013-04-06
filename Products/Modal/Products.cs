using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryLP.Model
{
    public class Products
    {
        public Products()
        { }
        #region Model
        private int _id;
        private string _huohao = "";
        private string _leibei = "";
        private string _productname = "";
        private string _agent = "";
        private string _agentids = "";
        private decimal _pricefactory = 0;
        private decimal _pricesell = 0;
        private decimal _Weight = 0;
        private int _amountkc = 0;
        private int _amountout = 0;
        private int _amountxm = 0;
        private int _amounthz = 0;
        private string _size = "";
        private string _remark = "";
        private string _pic = "";
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
        public string Agent
        {
            set { _agent = value; }
            get { return _agent; }
        }
        public string AgentIds
        {
            set { _agentids = value; }
            get { return _agentids; }
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
        public decimal Weight
        {
            set { _Weight = value; }
            get { return _Weight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AmountKc
        {
            set { _amountkc = value; }
            get { return _amountkc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AmountOut
        {
            set { _amountout = value; }
            get { return _amountout; }
        }
        /// <summary>
        /// 厦门英冠库存
        /// </summary>
        public int AmountXM
        {
            set { _amountxm = value; }
            get { return _amountxm; }
        }
        /// <summary>
        /// 黄总库存
        /// </summary>
        public int AmountHZ
        {
            set { _amounthz = value; }
            get { return _amounthz; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
