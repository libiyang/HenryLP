using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HenryLP.DAL
{
    public class ReportIn
    {
        public ReportIn()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HenryLP.Model.ReportIn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ReportIn(");
            strSql.Append("ProductId,HuoHao,ProductName,ReportDate,AmountIn,AgentId,AgentName,LeiBei,Remark)");
            strSql.Append(" values (");
            strSql.Append("@ProductId,@HuoHao,@ProductName,@ReportDate,@AmountIn,@AgentId,@AgentName,@LeiBei,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@ReportDate", SqlDbType.DateTime),
					new SqlParameter("@AmountIn", SqlDbType.Int,4),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,50),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@Remark", SqlDbType.NVarChar)};
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.HuoHao;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.ReportDate;
            parameters[4].Value = model.AmountIn;
            parameters[5].Value = model.AgentId;
            parameters[6].Value = model.AgentName;
            parameters[7].Value = model.LeiBei;
            parameters[8].Value = model.Remark;

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
        public bool Update(HenryLP.Model.ReportIn model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ReportIn set ");
            strSql.Append("AmountIn=@AmountIn,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@AmountIn", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.AmountIn;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.Id;

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
            strSql.Append("delete from ReportIn ");
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
            strSql.Append("delete from ReportIn ");
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
        public HenryLP.Model.ReportIn GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from ReportIn ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            HenryLP.Model.ReportIn model = new HenryLP.Model.ReportIn();
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
                if (ds.Tables[0].Rows[0]["AmountIn"].ToString() != "")
                {
                    model.AmountIn = int.Parse(ds.Tables[0].Rows[0]["AmountIn"].ToString());
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
            strSql.Append("select ReportIn.*, Products.Pic");
            strSql.Append(" FROM ReportIn left join Products on ReportIn.ProductId=Products.Id");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" FROM ReportIn ");
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
            strSql.Append(" FROM ReportIn ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
