using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Upload2英冠
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
                dsData = DbHelperOleDb.Query("select SCID,Productid,DesChn,[Size],Unit,Ccurrency,SellPrice,qty,PhotoPath,ProductTypeDesc from SalesFooter");
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
                DalProducts dalProducts = new DalProducts();

                foreach (DataRow row in dsData.Tables[0].Rows)
                {
                    try
                    {
                        ModelProducts model = dalProducts.GetModel(row["Productid"].ToString());
                        if (model == null)
                        {
                            string strPhotoPath = row["PhotoPath"].ToString();
                            if (strPhotoPath.LastIndexOf("\\") > -1)
                            {
                                strPhotoPath = strPhotoPath.Substring(strPhotoPath.LastIndexOf("\\") + 1);
                            }

                            ModelProducts mProduct = new ModelProducts();
                            mProduct.HuoHao = row["Productid"].ToString();
                            mProduct.LeiBei = row["ProductTypeDesc"].ToString();
                            mProduct.pic = "SalesFooter/" + strPhotoPath;
                            mProduct.PriceFactory = (decimal)row["SellPrice"] * 6.6m;
                            mProduct.PriceSell = mProduct.PriceFactory * 1.2m * 3.5m;
                            mProduct.ProductName = row["DesChn"].ToString();
                            mProduct.Size = row["Size"].ToString();
                            mProduct.AmountXM += int.Parse(row["qty"].ToString());
                            mProduct.UpdateOn = DateTime.Now;
                            mProduct.Weight = 0;
                            dalProducts.Add(mProduct);
                        }
                        else
                        {
                            model.AmountXM += int.Parse(row["qty"].ToString());
                            dalProducts.UpdateAmountXM(model);
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
