using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HenryLP.Model
{
    public class Leibei
    {
        public Leibei()
        { }

        private int _id;
        private string _leibeiname = "";

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
    }
}
