﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHospitalMS.Views.Labroterians
{
    public partial class LabTest : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowTest();
        }
        private void ShowTest()
        {
            string Query = "Select * from  LabTestTbl";
            LabTestGV.DataSource = Con.GetDatas(Query);
            LabTestGV.DataBind();
        }
        //Add This Ovrriden Method.
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TestName = LabNameTb.Value;
                string TestCost = TestCostTb.Value;

                string Query = "insert into LabTestTbl values('{0}','{1}','{2}')";
                Query = string.Format(Query, TestName , TestCost, Session["uid"]);
                Con.SetDates(Query);
                ShowTest();
                ErrMsg.InnerText = "Test Added !!!";
                LabNameTb.Value = "";
                TestCostTb.Value = "";
               

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
       
       
       
        int Key = 0;
        protected void LabTestGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabNameTb.Value = LabTestGV.SelectedRow.Cells[2].Text;
            TestCostTb.Value = LabTestGV.SelectedRow.Cells[3].Text;
          
            if (LabNameTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LabTestGV.SelectedRow.Cells[1].Text);
            }
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TestName = LabNameTb.Value;
                string TestCost = TestCostTb.Value;



                string Query = "update  LabTestTbl  set TestName = '{0}',TestCost = '{1}'where TestId = {2}";
                Query = string.Format(Query, TestName,TestCost, LabTestGV.SelectedRow.Cells[1].Text);
                Con.SetDates(Query);
                ShowTest();
                ErrMsg.InnerText = "Test Updated !!!";
                LabNameTb.Value = "";
                TestCostTb.Value = "";
               

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LabNameTb.Value == "")
                {
                    ErrMsg.InnerText = "select a Test !!!";
                }
                else
                {
                    string Query = "delete from LabTestTbl where TestId={0}";
                    Query = string.Format(Query, LabTestGV.SelectedRow.Cells[1].Text);
                    Con.SetDates(Query);
                    ShowTest();
                    ErrMsg.InnerText = " Lab Test Deleted !!!";
                    Key = 0;
                    LabNameTb.Value = "";
                    TestCostTb.Value = "";
                   
                }

            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
    }
