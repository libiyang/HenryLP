using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UploadSalesFooter
{
    public class DalSalesFooter
    {
        public DalSalesFooter()
		{}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ModelSalesFooter model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products2013_SalesFooter(");
            strSql.Append("SCID,Productid,DesChn,Size,Unit,Ccurrency,SellPrice,PhotoPath)");
            strSql.Append(" values (");
            strSql.Append("@SCID,@Productid,@DesChn,@Size,@Unit,@Ccurrency,@SellPrice,@PhotoPath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SCID", SqlDbType.NVarChar,50),
					new SqlParameter("@Productid", SqlDbType.NVarChar,50),
					new SqlParameter("@DesChn", SqlDbType.NVarChar,100),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Ccurrency", SqlDbType.NVarChar,50),
					new SqlParameter("@SellPrice", SqlDbType.Decimal,9),
					new SqlParameter("@PhotoPath", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.SCID;
            parameters[1].Value = model.Productid;
            parameters[2].Value = model.DesChn;
            parameters[3].Value = model.Size;
            parameters[4].Value = model.Unit;
            parameters[5].Value = model.Ccurrency;
            parameters[6].Value = model.SellPrice;
            parameters[7].Value = model.PhotoPath;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
    }
}
