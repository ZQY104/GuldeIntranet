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
    public partial class Contact : Page
    {
        public string ECRN_Number { get; private set; }
        public string Affected_PN { get; private set; }
        public string Affected_DWG { get; private set; }

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
            //string sql = "select * from View_GuldeECRN where (ECRN_Number like ('%" + TextBox1.Text.Trim() + "%')) and (Affected_PN like ('%" + TextBox2.Text.Trim() + "%') or Affected_PN IS NULL)and (Affected_DWG like IFNULL(NULL,('%" + TextBox3.Text.Trim() + "%')))";
            string sql = "select * from View_GuldeECRN where (ECRN_Number like ('%" + TextBox1.Text.Trim() + "%')) and (isnull(Affected_PN,'') like ('%" + TextBox2.Text.Trim() + "%')) and (isnull(Affected_DWG,'') like('%" + TextBox3.Text.Trim() + "%'))";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            this.GridView1.DataSource = ds;
            this.GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}