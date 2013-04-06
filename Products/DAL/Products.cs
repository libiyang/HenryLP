using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HenryLP.DAL
{
    public class Products
    {
        public Products()
        { }
        #region  Method

        public bool Exists(string HuoHao)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products");
            strSql.Append(" where HuoHao=@HuoHao ");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30)};
            parameters[0].Value = HuoHao;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HenryLP.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Products(");
            strSql.Append("HuoHao,LeiBei,ProductName,Agent,AgentIds,PriceFactory,PriceSell,AmountKc,AmountOut,Size,Remark,pic,UpdateOn,Weight,AmountXM,AmountHZ)");
            strSql.Append(" values (");
            strSql.Append("@HuoHao,@LeiBei,@ProductName,@Agent,@AgentIds,@PriceFactory,@PriceSell,@AmountKc,@AmountOut,@Size,@Remark,@pic,@UpdateOn,@Weight,@AmountXM,@AmountHZ)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@Agent", SqlDbType.NVarChar,400),
					new SqlParameter("@AgentIds", SqlDbType.NVarChar,100),
					new SqlParameter("@PriceFactory", SqlDbType.Decimal,9),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@AmountKc", SqlDbType.Int,4),
					new SqlParameter("@AmountOut", SqlDbType.Int,4),
					new SqlParameter("@Size", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,250),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@UpdateOn", SqlDbType.DateTime),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@AmountXM", SqlDbType.Int,4),
					new SqlParameter("@AmountHZ", SqlDbType.Int,4)};
            parameters[0].Value = model.HuoHao;
            parameters[1].Value = model.LeiBei;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Agent;
            parameters[4].Value = model.AgentIds;
            parameters[5].Value = model.PriceFactory;
            parameters[6].Value = model.PriceSell;
            parameters[7].Value = model.AmountKc;
            parameters[8].Value = model.AmountOut;
            parameters[9].Value = model.Size;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.pic;
            parameters[12].Value = model.UpdateOn;
            parameters[13].Value = model.Weight;
            parameters[14].Value = model.AmountXM;
            parameters[15].Value = model.AmountHZ;

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
        public bool Update(HenryLP.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("HuoHao=@HuoHao,");
            strSql.Append("LeiBei=@LeiBei,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Agent=@Agent,");
            strSql.Append("AgentIds=@AgentIds,");
            strSql.Append("PriceFactory=@PriceFactory,");
            strSql.Append("PriceSell=@PriceSell,");
            strSql.Append("AmountKc=@AmountKc,");
            strSql.Append("AmountOut=@AmountOut,");
            strSql.Append("Size=@Size,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("pic=@pic,");
            strSql.Append("UpdateOn=@UpdateOn,");
            strSql.Append("Weight=@Weight,");
            strSql.Append("AmountXM=@AmountXM,");
            strSql.Append("AmountHZ=@AmountHZ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@HuoHao", SqlDbType.NVarChar,30),
					new SqlParameter("@LeiBei", SqlDbType.NVarChar,30),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,30),
					new SqlParameter("@Agent", SqlDbType.NVarChar,400),
					new SqlParameter("@AgentIds", SqlDbType.NVarChar,100),
					new SqlParameter("@PriceFactory", SqlDbType.Decimal,9),
					new SqlParameter("@PriceSell", SqlDbType.Decimal,9),
					new SqlParameter("@AmountKc", SqlDbType.Int,4),
					new SqlParameter("@AmountOut", SqlDbType.Int,4),
					new SqlParameter("@Size", SqlDbType.NVarChar,100),
					new SqlParameter("@Remark", SqlDbType.NVarChar,250),
					new SqlParameter("@pic", SqlDbType.NVarChar,1000),
					new SqlParameter("@UpdateOn", SqlDbType.DateTime),
					new SqlParameter("@Weight", SqlDbType.Decimal,9),
					new SqlParameter("@AmountXM", SqlDbType.Int,4),
					new SqlParameter("@AmountHZ", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.HuoHao;
            parameters[1].Value = model.LeiBei;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Agent;
            parameters[4].Value = model.AgentIds;
            parameters[5].Value = model.PriceFactory;
            parameters[6].Value = model.PriceSell;
            parameters[7].Value = model.AmountKc;
            parameters[8].Value = model.AmountOut;
            parameters[9].Value = model.Size;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.pic;
            parameters[12].Value = model.UpdateOn;
            parameters[13].Value = model.Weight;
            parameters[14].Value = model.AmountXM;
            parameters[15].Value = model.AmountHZ;
            parameters[16].Value = model.Id;

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

        public bool UpdateAmountXM(HenryLP.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("AmountXM=@AmountXM");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@AmountXM", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.AmountXM;
            parameters[1].Value = model.Id;

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
        public bool UpdateAmountHZ(HenryLP.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("AmountHZ=@AmountHZ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@AmountHZ", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.AmountHZ;
            parameters[1].Value = model.Id;

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

        public bool UpdateAmountOut(HenryLP.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            strSql.Append("AmountOut=@AmountOut");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@AmountOut", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.AmountOut;
            parameters[1].Value = model.Id;

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
            strSql.Append("delete from Products ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
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
            strSql.Append("delete from Products ");
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
        public HenryLP.Model.Products GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Products ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
            parameters[0].Value = Id;

            HenryLP.Model.Products model = new HenryLP.Model.Products();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.HuoHao = ds.Tables[0].Rows[0]["HuoHao"].ToString();
                model.LeiBei = ds.Tables[0].Rows[0]["LeiBei"].ToString();
                model.ProductName = ds.Tables[0].Rows[0]["ProductName"].ToString();
                model.Agent = ds.Tables[0].Rows[0]["Agent"].ToString();
                model.AgentIds = ds.Tables[0].Rows[0]["AgentIds"].ToString();
                if (ds.Tables[0].Rows[0]["PriceFactory"].ToString() != "")
                {
                    model.PriceFactory = decimal.Parse(ds.Tables[0].Rows[0]["PriceFactory"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceSell"].ToString() != "")
                {
                    model.PriceSell = decimal.Parse(ds.Tables[0].Rows[0]["PriceSell"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountKc"].ToString() != "")
                {
                    model.AmountKc = int.Parse(ds.Tables[0].Rows[0]["AmountKc"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountOut"].ToString() != "")
                {
                    model.AmountOut = int.Parse(ds.Tables[0].Rows[0]["AmountOut"].ToString());
                }
                model.Size = ds.Tables[0].Rows[0]["Size"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.pic = ds.Tables[0].Rows[0]["pic"].ToString();
                if (ds.Tables[0].Rows[0]["UpdateOn"].ToString() != "")
                {
                    model.UpdateOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountXM"].ToString() != "")
                {
                    model.AmountXM = int.Parse(ds.Tables[0].Rows[0]["AmountXM"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AmountHZ"].ToString() != "")
                {
                    model.AmountHZ = int.Parse(ds.Tables[0].Rows[0]["AmountHZ"].ToString());
                }
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Products(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UpdateOn desc ");

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
            strSql.Append(" FROM Products ");
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
            parameters[0].Value = "Products";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
