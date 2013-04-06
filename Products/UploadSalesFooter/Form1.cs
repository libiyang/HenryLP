using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UploadSalesFooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet dsData = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dsData = DbHelperOleDb.Query("select SCID,Productid,DesChn,[Size],Unit,Ccurrency,SellPrice,PhotoPath,ProductTypeDesc from SalesFooter");
                dataGridView1.DataSource = dsData.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DalSalesFooter dal = new DalSalesFooter();
                DalProducts dalProducts = new DalProducts();

                foreach (DataRow row in dsData.Tables[0].Rows)
                {
                    try
                    {
                        ModelSalesFooter model = new ModelSalesFooter();
                        model.Ccurrency = row["Ccurrency"].ToString();
                        model.DesChn = row["DesChn"].ToString();
                        model.Productid = row["Productid"].ToString();
                        model.SCID = row["SCID"].ToString();
                        model.SellPrice = (decimal)row["SellPrice"];
                        model.Size = row["Size"].ToString();
                        model.Unit = row["Unit"].ToString();
                        model.PhotoPath = row["PhotoPath"].ToString();
                        if (model.PhotoPath.LastIndexOf("\\") > -1)
                        {
                            model.PhotoPath = model.PhotoPath.Substring(model.PhotoPath.LastIndexOf("\\") + 1);
                        }
                        dal.Add(model);

                        if (!dalProducts.Exists(row["Productid"].ToString()))
                        {
                            ModelProducts mProduct = new ModelProducts();
                            mProduct.HuoHao = row["Productid"].ToString();
                            mProduct.LeiBei = row["ProductTypeDesc"].ToString().Replace("类", "").Replace("铁件", "纯铁").Replace("木作", "纯木");
                            mProduct.pic = "SalesFooter/" + model.PhotoPath;
                            mProduct.PriceFactory = (decimal)row["SellPrice"];
                            mProduct.PriceSell = mProduct.PriceFactory * 6.6m * 1.2m * 3.5m;
                            mProduct.ProductName = row["DesChn"].ToString();
                            mProduct.Size = row["Size"].ToString();
                            mProduct.UpdateOn = DateTime.Now;
                            mProduct.Weight = 0;
                            dalProducts.Add(mProduct);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                MessageBox.Show("上传完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
