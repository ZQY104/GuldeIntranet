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
    public partial class CreateDrawing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //以下为将页面中的textbox2的输入值写入数据库表的语句;
            string SQLString = ConfigurationManager.ConnectionStrings["GuldeERP_TestConnectionString"].ToString();
            //数据库连接语句设定为SQLString，该语句连接的是名为GuldeERP_Test的数据库;
            SqlConnection conn = new SqlConnection(SQLString);
            //建立一个名为conn的新连接，其语句为SQLString;
            conn.Open();
            //打开连接；
            string link = @"\\10.165.4.37\CMT\Personal Folders\Mamie Ma\DWG_Search\All Drawing PDF_UPDATE\"; // 此处为保存图纸路径的主体部分,后续会加上图号和版本号;
            SqlCommand cmd = new SqlCommand("insert into GuldeDwgSystem (Drawing_Number,Fisher_Number,First_Name,Last_Name,Description,Status_ID,Predecessor,Project_ID,Pattern_ID,Revision,Version,Page_Number,Total_Pages,Creator,Checker,Approver,Create_Date,DrawingLink) values (upper ('" + TextBox1.Text.Trim() + "'),upper ('" + TextBox2.Text.Trim() + "'),upper ('" + TextBox3.Text.Trim() + "'),upper ('" + TextBox4.Text.Trim() + "'),upper ('" + TextBox5.Text.Trim() + "'),upper ('" + DropDownList1.Text.Trim() + "'),upper ('" + TextBox7.Text.Trim() + "'),upper ('" + DropDownList2.Text.Trim() + "'),upper ('" + DropDownList3.Text.Trim() + "'),upper ('" + DropDownList4.Text.Trim() + "'),upper ('" + DropDownList5.Text.Trim() + "'),upper ('" + DropDownList6.Text.Trim() + "'),upper ('" + DropDownList7.Text.Trim() + "'),upper ('" + DropDownList8.Text.Trim() + "'),upper ('" + DropDownList9.Text.Trim() + "'),upper ('" + DropDownList10.Text.Trim() + "'),getdate(),('" + link + "' + upper ('" + TextBox1.Text.Trim() + "')+ '_'+ upper ('" + DropDownList4.Text.Trim() + "')+'.pdf'))", conn);
            //以上为数据表插入语句，upper('abc')为将小写转换成大写的函数;
            cmd.ExecuteNonQuery();
            //执行按钮命令;
            conn.Close();
            //关闭连接;

            this.Label1.Text = "创建成功";
            //在lable1中显示上传成功;

        }
    }
}