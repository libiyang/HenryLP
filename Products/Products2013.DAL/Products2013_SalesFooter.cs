using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Products2013.DAL
{
    public class Products2013_SalesFooter
    {
		public Products2013_SalesFooter()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Products2013_SalesFooter");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Products2013_SalesFooter model)
		{
			StringBuilder strSql=new StringBuilder();
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

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Model.Products2013_SalesFooter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Products2013_SalesFooter set ");
			strSql.Append("SCID=@SCID,");
			strSql.Append("Productid=@Productid,");
			strSql.Append("DesChn=@DesChn,");
			strSql.Append("Size=@Size,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Ccurrency=@Ccurrency,");
			strSql.Append("SellPrice=@SellPrice,");
			strSql.Append("PhotoPath=@PhotoPath");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@SCID", SqlDbType.NVarChar,50),
					new SqlParameter("@Productid", SqlDbType.NVarChar,50),
					new SqlParameter("@DesChn", SqlDbType.NVarChar,100),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Ccurrency", SqlDbType.NVarChar,50),
					new SqlParameter("@SellPrice", SqlDbType.Decimal,9),
					new SqlParameter("@PhotoPath", SqlDbType.NVarChar,500),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.SCID;
			parameters[1].Value = model.Productid;
			parameters[2].Value = model.DesChn;
			parameters[3].Value = model.Size;
			parameters[4].Value = model.Unit;
			parameters[5].Value = model.Ccurrency;
			parameters[6].Value = model.SellPrice;
			parameters[7].Value = model.PhotoPath;
			parameters[8].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Products2013_SalesFooter ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Products2013_SalesFooter ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Model.Products2013_SalesFooter GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,SCID,Productid,DesChn,Size,Unit,Ccurrency,SellPrice,PhotoPath from Products2013_SalesFooter ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Model.Products2013_SalesFooter model=new Model.Products2013_SalesFooter();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Products2013_SalesFooter DataRowToModel(DataRow row)
		{
			Model.Products2013_SalesFooter model=new Model.Products2013_SalesFooter();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["SCID"]!=null)
				{
					model.SCID=row["SCID"].ToString();
				}
				if(row["Productid"]!=null)
				{
					model.Productid=row["Productid"].ToString();
				}
				if(row["DesChn"]!=null)
				{
					model.DesChn=row["DesChn"].ToString();
				}
				if(row["Size"]!=null)
				{
					model.Size=row["Size"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["Ccurrency"]!=null)
				{
					model.Ccurrency=row["Ccurrency"].ToString();
				}
				if(row["SellPrice"]!=null && row["SellPrice"].ToString()!="")
				{
					model.SellPrice=decimal.Parse(row["SellPrice"].ToString());
				}
				if(row["PhotoPath"]!=null)
				{
					model.PhotoPath=row["PhotoPath"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,SCID,Productid,DesChn,Size,Unit,Ccurrency,SellPrice,PhotoPath ");
			strSql.Append(" FROM Products2013_SalesFooter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
            }
            strSql.Append(" order by id desc ");
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,SCID,Productid,DesChn,Size,Unit,Ccurrency,SellPrice,PhotoPath ");
			strSql.Append(" FROM Products2013_SalesFooter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Products2013_SalesFooter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Products2013_SalesFooter T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
    }
}
