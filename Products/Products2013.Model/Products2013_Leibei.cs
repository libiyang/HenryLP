using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products2013.Model
{
    [Serializable]
    public partial class Products2013_Leibei
    {
        public Products2013_Leibei()
        { }
        #region Model
        private int _id;
        private string _leibeiname = "";
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
        public string LeibeiName
        {
            set { _leibeiname = value; }
            get { return _leibeiname; }
        }
        #endregion Model

    }
}
