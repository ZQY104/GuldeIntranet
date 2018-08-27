using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel; //由于需要导出EXCEL, 需要增加此名称空间;
using System.Text;

namespace GuldeDwgSystem //名称空间需与项目名称一致，见Solution Exploer;
{
    public partial class _5400Bom : System.Web.UI.Page //导入UI， 这是VS自动带入的；
    {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e) //这是VS自动带入；
        {

        }
        #endregion

        #region Button1_Serch BOM & EM String
        ///思路；
        ///1. 连接数据库；
        ///2. 执行查询；
        ///3. 将查询结果注入一个dataset；
        ///4. 将dataset结果传给gridview；
        protected void Button1_Click(object sender, EventArgs e)
        {
            //SQL数据库连接语句;
            string SQLString = ConfigurationManager.ConnectionStrings["GuldeERP_TestConnectionString"].ToString();//数据库连接语句设定为SQLString，该语句连接的是名为GuldeERP_Test的数据库；
            SqlConnection conn = new SqlConnection(SQLString);//建立一个名为conn的新连接，其语句为SQLString;
            conn.Open();//打开连接；
            //

            //查询em string并注入到GridView1中;
            string sql = "SELECT * FROM view_40bomquote where [Bom #] like ('%" + TextBox1.Text.Trim().ToUpper() + "%') and [EM] like ('%" + TextBox2.Text.Trim().ToUpper() + "%') and [Description] like ('%" + TextBox3.Text.Trim().ToUpper() + "%')";
            SqlCommand cmd = new SqlCommand(sql, conn);//实例化一个SQL查询命令;
            SqlDataAdapter da = new SqlDataAdapter();//实例化一个dataadapter;
            DataSet ds = new DataSet();//实例化一个dataset;
            da.SelectCommand = cmd;//执行sql查询命令,并将查询结果注入到dataadapter;
            da.Fill(ds);//将dataset ds注入到dataadapter da中;
            this.GridView1.DataSource = ds;//将dataset ds注入到gridview;
            this.GridView1.DataBind();//对gridview进行数据绑定;
        }
        #endregion

        #region mouse color
        ///思路
        ///1. 令绑定的GridView实现鼠标滑行变色；
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //首先判断是否是数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //当鼠标停留时更改背景色
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                //当鼠标移开时还原背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }
        //
        #endregion

        /* protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)//激活分页视图时显示第一页，页码是数字0
         {
             MultiView1.ActiveViewIndex = 0;
         }*/

        #region Button2,Export for Engineer
        //
        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0; //由于本页面设置了两个view, 此语句作用是按下Button1后，直接跳到View1,其index = 0;
            DateTime dt = DateTime.Now; //获取server当前时间;
            Export("application/ms-excel", "BOM List" + dt.ToString() + ".xls");//将导出的文件名命名为BOM LIST(当前时间).xls;
        }
        private void Export(string FileType, string FileName)
        {
            Response.Charset = "GB2312";//避免文件名为乱码 
            Response.ContentEncoding = System.Text.Encoding.UTF8; //不知道干啥的，修改这行UTF8到7就出现乱码，最好别加了。
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            Response.ContentType = FileType;
            this.EnableViewState = false;
            StringWriter tw = new StringWriter(); //实例化StringWriter;
            HtmlTextWriter hw = new HtmlTextWriter(tw); //实例化HtmlTextWriter;
            //GridView1.Columns[7].Visible = false; //**!!!!**将第7列，也就是按钮列隐藏,否则无法导出来;
            GridView3.RenderControl(hw);
            GridView2.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        //
        #endregion

        #region Button3,Em string查询；
        protected void Button3_Click(object sender, EventArgs e)
        {

            //数据库连接语句;
            string SQLString = ConfigurationManager.ConnectionStrings["GuldeERP_TestConnectionString"].ToString();//数据库连接语句设定为SQLString，该语句连接的是名为GuldeERP_Test的数据库；
            SqlConnection conn = new SqlConnection(SQLString);//建立一个名为conn的新连接，其语句为SQLString;
            conn.Open();//打开连接；

            string Emstring = ((Button)sender).CommandArgument.ToString(); //将Button3对应的EMstring赋值给 Emstring, 例如：string Emstring = "5400X15-AG1-B20-C526-E17-F26-G4-H65-9A7-9D17-9E40"; 
            string[] Empick = Regex.Split(Emstring, "-", RegexOptions.IgnoreCase);//字符串Emstring被打散;
            string endstr = "";//新建空字符串endstr,未来该字符串将包含除Emstring的第一个字符串外的所有字符串，例如Emstring为"5400X15-AG1-B42-C526",则endstr为"AG1,B42,C526";
            for (int i = 1; i < Empick.Length; i++)
            {
                string str = "'" + Empick[i] + "'";  //在每个元素前后加上我们想要的格式，效果例如：  // " 'AG1' " 
                if (i < Empick.Length - 1)  //根据数组元素的个数来判断应该加多少个逗号 
                {
                    str += ",";
                }
                endstr += str;//将str累加的字符串赋值给endstr;这样就得到字符串为endstr = "'AG1','B42','C526'";
            }

            #region GridView2查询
            //查询em string并注入到GridView中, GridView2显示BOM#,EM string,以及BOM# description等等;
            string sql1 = "Select * from View_40structure where Em = '" + Empick[0] + "' and Empick in (" + endstr + ") order by Empick";//指定范围查询并排序,*******精华部分*****;
            SqlCommand cmd1 = new SqlCommand(sql1, conn);//建立一个SQL查询命令;
            SqlDataAdapter da1 = new SqlDataAdapter();  //实例化一个dataadapter;             
            DataSet ds1 = new DataSet();//实例化一个dataset;
            da1.SelectCommand = cmd1;//执行sql查询命令,并将查询结果注入到dataadapter;
            da1.Fill(ds1);//将查询结果注入到dataset中;
            this.GridView2.DataSource = ds1;//将dataset结果注入到gridview;  
            this.GridView2.DataBind();//对gridview进行数据绑定;
            #endregion;

            #region Gridview3查询
            //查询em string并注入到GridView3中;GridView3显示EM pick, Part Number,Material等等信息；
            string sql = "SELECT * FROM view_40bomquote where [EM] = '" + Emstring + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);//建立一个SQL查询命令；
            SqlDataAdapter da = new SqlDataAdapter();//建立一个dataadapter；
            DataSet ds = new DataSet();//建立一个dataset;
            da.SelectCommand = cmd;//执行sql查询命令,并将查询结果注入到dataadapter；
            da.Fill(ds);//将查询结果注入到dataset中；
            this.GridView3.DataSource = ds;//将dataset结果注入到gridview；
            this.GridView3.DataBind();//对gridview进行数据绑定；
            //  
            #endregion

            #region GridView4查询;
            this.GridView4.DataSource = ds; //GridView4和GridView3内容完全相同，只是不在同一个View上,因此其dataset相同；
            this.GridView4.DataBind();
            #endregion

            #region GridView5查询；
            //查询em string并注入到GridView3中;GridView3显示EM pick, Part Number,Material等等信息；
            string sql_GridView5 = "Select * from View_41structure where Em = '" + Empick[0] + "' and Empick in (" + endstr + ") order by Empick";//指定范围查询并排序,*******精华部分*****;
            SqlCommand cmd_GridView5 = new SqlCommand(sql_GridView5, conn);//实例化一个SQL查询命令；
            SqlDataAdapter da_GridView5 = new SqlDataAdapter();//实例化一个dataadapter；
            DataSet ds_GridView5 = new DataSet();//实例化一个dataset;
            da_GridView5.SelectCommand = cmd_GridView5;//执行sql查询命令,并将查询结果注入到dataadapter；
            da_GridView5.Fill(ds_GridView5);//将查询结果注入到dataset中；
            this.GridView5.DataSource = ds_GridView5;//将dataset结果注入到gridview；
            this.GridView5.DataBind();//对gridview进行数据绑定；
            // 
            #endregion

            MultiView1.ActiveViewIndex = 1; //由于本页面设置了两个view, 此语句作用是按下Button1后，直接跳到View1,其index = 0;
        }
        #endregion

        #region Button4 Bom List查询；
        protected void Button4_Click(object sender, EventArgs e)
        {

            //数据库连接语句;
            string SQLString = ConfigurationManager.ConnectionStrings["GuldeERP_TestConnectionString"].ToString();//数据库连接语句设定为SQLString，该语句连接的是名为GuldeERP_Test的数据库；
            SqlConnection conn = new SqlConnection(SQLString);//建立一个名为conn的新连接，其语句为SQLString;
            conn.Open();//打开连接；
            //

            #region Gridview3查询
            string Bomnumber = ((Button)sender).CommandArgument.ToString();//将按钮对应的字符串传过来，
            //查询em string并注入到GridView3中;
            string sql = "SELECT * FROM view_40bomquote where [Bom #] = ('" + Bomnumber + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);//建立一个SQL查询命令;
            SqlDataAdapter da = new SqlDataAdapter();//建立一个dataadapter;
            DataSet ds = new DataSet();//建立一个dataset;
            da.SelectCommand = cmd;//执行sql查询命令,并将查询结果注入到dataadapter;
            da.Fill(ds);//将查询结果注入到dataset中;
            this.GridView3.DataSource = ds;//将dataset结果注入到gridview;
            this.GridView3.DataBind();//对gridview进行数据绑定;
            #endregion

            #region GridView2查询
            string emstring = "";
            DataSet ds1 = new DataSet();//建立一个dataset;
            for (int n = 0; n < ds.Tables[0].Rows.Count; n++)
            {
                emstring = Convert.ToString((ds.Tables[0]).Rows[n][1].ToString());//将ds的第n行第2列赋值给emstring;
                string Emstring = emstring;
                //string Emstring = "5400X15-AG1-B20-C526-E17-F26-G4-H65-9A7-9D17-9E40";

                string[] Empick = Regex.Split(Emstring, "-", RegexOptions.IgnoreCase);//字符串Emstring被打散;

                string endstr = "";//新建字符串endstr,该字符串将包含除Emstring的第一个字符串外的所有字符串，例如Emstring为"5400X15-AG1-B42-C526",则endstr为"AG1,B42,C526";
                for (int i = 1; i < Empick.Length; i++)
                {
                    string str = "'" + Empick[i] + "'";  //在每个元素前后加上我们想要的格式，效果例如：  // " 'AG1' " 
                    if (i < Empick.Length - 1)  //根据数组元素的个数来判断应该加多少个逗号 
                    {
                        str += ",";
                    }
                    endstr += str;//将str累加的字符串赋值给endstr;这样就得到字符串为endstr = "'AG1','B42','C526'";

                }

                //查询em string并注入到GridView中;
                string sql1 = "Select * from View_40structure where (Em = '" + Empick[0] + "' and Empick in (" + endstr + ") )order by Empick";//指定范围查询并排序;
                SqlCommand cmd1 = new SqlCommand(sql1, conn);//建立一个SQL查询命令;
                SqlDataAdapter da1 = new SqlDataAdapter();  //建立一个dataadapter;      
                da1.SelectCommand = cmd1;//执行sql查询命令,并将查询结果注入到dataadapter;
                da1.Fill(ds1);//将查询结果注入到dataset中;  

            }
            this.GridView2.DataSource = ds1;//将dataset结果注入到gridview;  
            this.GridView2.DataBind();//对gridview进行数据绑定;
            #endregion

            #region GridView4查询;
            this.GridView4.DataSource = ds; //GridView4和GridView3内容完全相同，只是不在同一个View上,因此其dataset相同；
            this.GridView4.DataBind();
            #endregion

            #region GridView5查询
            string emstring_GridView5 = "";
            DataSet ds1_GridView5 = new DataSet();//建立一个dataset;
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                emstring_GridView5 = Convert.ToString((ds.Tables[0]).Rows[j][1].ToString());//将ds的第n行第2列赋值给emstring;
                string Emstring_GridView5 = emstring_GridView5;
                //string Emstring = "5400X15-AG1-B20-C526-E17-F26-G4-H65-9A7-9D17-9E40";

                string[] Empick_GridView5 = Regex.Split(Emstring_GridView5, "-", RegexOptions.IgnoreCase);//字符串Emstring被打散;

                string endstr_GridView5 = "";//新建字符串endstr,该字符串将包含除Emstring的第一个字符串外的所有字符串，例如Emstring为"5400X15-AG1-B42-C526",则endstr为"AG1,B42,C526";
                for (int t = 1; t < Empick_GridView5.Length; t++)
                {
                    string str_GridView5 = "'" + Empick_GridView5[t] + "'";  //在每个元素前后加上我们想要的格式，效果例如：  // " 'AG1' " 
                    if (t < Empick_GridView5.Length - 1)  //根据数组元素的个数来判断应该加多少个逗号 
                    {
                        str_GridView5 += ",";
                    }
                    endstr_GridView5 += str_GridView5;//将str累加的字符串赋值给endstr;这样就得到字符串为endstr = "'AG1','B42','C526'";

                }

                //查询em string并注入到GridView中;
                string sql1_GridView5 = "Select * from View_41structure where (Em = '" + Empick_GridView5[0] + "' and Empick in (" + endstr_GridView5 + ") )order by Empick";//指定范围查询并排序;
                SqlCommand cmd1_GridView5 = new SqlCommand(sql1_GridView5, conn);//建立一个SQL查询命令;
                SqlDataAdapter da1_GridView5 = new SqlDataAdapter();  //建立一个dataadapter;      
                da1_GridView5.SelectCommand = cmd1_GridView5;//执行sql查询命令,并将查询结果注入到dataadapter;
                da1_GridView5.Fill(ds1_GridView5);//将查询结果注入到dataset中;  

            }
            this.GridView5.DataSource = ds1_GridView5;//将dataset结果注入到gridview;  
            this.GridView5.DataBind();//对gridview进行数据绑定;
            #endregion

            MultiView1.ActiveViewIndex = 0; //由于本页面设置了两个view, 此语句作用是按下Button1后，直接跳到View1,其index = 0;
        }
        #endregion        

        #region Button5 Export for OE
        protected void Button5_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1; //由于本页面设置了两个view, 此语句作用是按下Button5后，直接跳到View2,其index =1;
            DateTime dt = DateTime.Now; //获取server当前时间;
            Export_OE("application/ms-excel", "BOM List" + dt.ToString() + ".xls");//将导出的文件名命名为BOM LIST(当前时间).xls;
        }
        private void Export_OE(string FileType, string FileName)
        {
            Response.Charset = "GB2312";//避免文件名为乱码 
            Response.ContentEncoding = System.Text.Encoding.UTF8; //不知道干啥的，修改这行UTF8到7就出现乱码，最好别加了。
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
            Response.ContentType = FileType;
            this.EnableViewState = false;
            StringWriter tw1 = new StringWriter(); //实例化StringWriter;
            HtmlTextWriter hw1 = new HtmlTextWriter(tw1); //实例化HtmlTextWriter;
            //GridView1.Columns[7].Visible = false; //**!!!!**将第7列，也就是按钮列隐藏,否则无法导出来;
            GridView4.RenderControl(hw1);
            GridView5.RenderControl(hw1);
            Response.Write(tw1.ToString());
            Response.End();
        }
        //注意：这里本来是要加上public override void VerifyRenderingInServerForm(Control control) {}的，但是由于前面Button2已经加了，而且是public函数,所以这里就不加了；
        #endregion
    }
}