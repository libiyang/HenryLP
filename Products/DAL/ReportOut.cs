using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HenryLP.DAL
{
    public class ReportOut
    {
        public ReportOut()
        { }
        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public int Exists(int ReportId, DateTime ReportDate)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select top 1 ID from ReportOut");
        //    strSql.Append(" where ReportDate=@ReportDate and ProductId=@ProductId ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ReportDate", SqlDbType.SmallDateTime),
        //            new SqlParameter("@ProductId", SqlDbType.Int,4)};
        //    parameters[0].Value = ReportDate;
        //    parameters[1].Value = ReportId;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HenryLP.Model.ReportOut model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReportOut(");
            strSql.Append("ProductId,HuoHao,ProductName,ReportDate,AmountOut,AmountFee,PriceSell,AgentId,AgentName,LeiBei,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ProductId,@HuoHao,@ProductName,@ReportDate,@AmountOut,@AmountFee,@PriceSell,@AgentId,@AgentName,@LeiBei,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@ReportDate", SqlDbType.DateTime),
					new SqlParameter("@AmountOut", SqlDbType.Int,4),
					new SqlParameter("@AmountFee", SqlDbType.Decimal,9),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,50),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@Remark", SqlDbType.NVarChar)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.HuoHao;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.ReportDate;
            parameters[4].Value = model.AmountOut;
            parameters[5].Value = model.AmountFee;
            parameters[6].Value = model.PriceSell;
            parameters[7].Value = model.AgentId;
            parameters[8].Value = model.AgentName;
            parameters[9].Value = model.LeiBei;
            parameters[10].Value = model.Remark;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HenryLP.Model.ReportOut model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReportOut set ");
            strSql.Append("AmountOut=@AmountOut,");
            strSql.Append("AmountFee=@AmountFee,");
            strSql.Append("PriceSell=@PriceSell,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@AmountOut", SqlDbType.Int,4),
                    new SqlParameter("@AmountFee", SqlDbType.Decimal,9),
                    new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.AmountOut;
            parameters[1].Value = model.AmountFee;
            parameters[2].Value = model.PriceSell;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReportOut ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ReportOut ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HenryLP.Model.ReportOut GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from ReportOut ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            HenryLP.Model.ReportOut model = new HenryLP.Model.ReportOut();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductId"].ToString() != "")
                {
                    model.ProductId = int.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
                }
                model.HuoHao = ds.Tables[0].Rows[0]["HuoHao"].ToString();
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                if (ds.Tables[0].Rows[0]["ReportDate"].ToString() != "")
                {
                    model.ReportDate = DateTime.Parse(ds.Tables[0].Rows[0]["ReportDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountOut"].ToString() != "")
                {
                    model.AmountOut = int.Parse(ds.Tables[0].Rows[0]["AmountOut"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountFee"].ToString() != "")
                {
                    model.AmountFee = decimal.Parse(ds.Tables[0].Rows[0]["AmountFee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceSell"].ToString() != "")
                {
                    model.PriceSell = decimal.Parse(ds.Tables[0].Rows[0]["PriceSell"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(ds.Tables[0].Rows[0]["AgentId"].ToString());
                }
                model.AgentName = ds.Tables[0].Rows[0]["AgentName"].ToString();
                model.LeiBei = ds.Tables[0].Rows[0]["LeiBei"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithProducts(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ReportOut.* , Products.Pic");
            strSql.Append(" FROM ReportOut left join Products on ReportOut.ProductId=Products.Id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ReportOut ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM ReportOut ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "ReportOut";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
    }
}
