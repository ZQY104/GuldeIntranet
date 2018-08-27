using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace GuldeDwgSystem
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //以下为将页面中的textbox2的输入值写入数据库表的语句；
            string SQLString = ConfigurationManager.ConnectionStrings["GuldeERP_TestConnectionString"].ToString();
            //数据库连接语句设定为SQLString，该语句连接的是名为GuldeERP_Test的数据库；
            SqlConnection conn = new SqlConnection(SQLString);
            //建立一个名为conn的新连接，其语句为SQLString;
            conn.Open();
            //打开连接；
            string sql = "select * from [View_GuldeDwgSystem] where (Drawing_Number like ('%" + TextBox1.Text.Trim() + "%')) and (isnull(Fisher_Number,'') like ('%" + TextBox2.Text.Trim() + "%')) and (isnull(First_Name,'')like ('%" + TextBox3.Text.Trim() + "%'))and (isnull(Last_Name,'')like ('%" + TextBox4.Text.Trim() + "%'))and (isnull(Description,'')like ('%" + TextBox5.Text.Trim() + "%'))and (isnull(Predecessor,'')like ('%" + TextBox6.Text.Trim() + "%')) and (isnull(Pattern_ID,'')like ('%" + TextBox7.Text.Trim() + "%'))and (isnull(Status_ID,'')like ('%" + DropDownList1.Text.Trim() + "%')) and (isnull(Project_ID,'')like ('%" + DropDownList2.Text.Trim() + "%'))";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();

        }
    }
}