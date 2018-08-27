using System;
using System.IO;
using System.Data;


namespace GuldeDwgSystem
{
    public partial class SearchDWG_Fisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = "小董专用,查FISHE图号专用页面";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //获取输入的文件名;
            string File2besearch = this.TextBox1.Text;
            //获取文件所在文件夹地址
            string Filefolder = @"\\cntsn1-vmgweb01\C$\inetpub\PartSystem\GuldeDwgSystem\App_Data\Dwg";//这个例子给定了图纸文件夹地址;

            string[] Filepath = Directory.GetFiles(Filefolder, "*" + File2besearch + "*.txt"); //返回文件名对应的文件路径,注意本例中限定后缀为.pdf;

            //新表dt, 并将拆分后的数组按指定行写入dt中，并将dt转值给GridView1;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));//创建列,这列最终会显示在网页上作为第一列;
            dt.Columns.Add("Link", typeof(string));//创建列，这个列会最终显示在网页上，作为第二列;

            //2.1 如果文件存在,则进行下一步,否则返回重新查询;
            if (Filepath.Length >= 1) //当查询结果不为空时,执行输出语句;
            {
                this.Label1.Text = "";
                string Filenamewithoutextension;
                for (int i = 0; i < Filepath.Length; i++)//遍历所有文件文件路径,并输出;
                {
                    Filenamewithoutextension = Path.GetFileNameWithoutExtension(Filepath[i]);//获取无后缀的文件名;

                    DataRow newRow = dt.NewRow();//创建行
                    newRow["Link"] = Filepath[i];//newRow行的Id列这个单元格，赋值为10 
                    newRow["Name"] = Filenamewithoutextension;//newRow行的Id列这个单元格，赋值为10 
                    dt.Rows.Add(newRow);//把newrow1行添加到表dt里 ；
                    //DataSet ds = new DataSet();

                }
                this.GridView1.DataSource = dt; //将表dt的值传给Gridview1；
                this.GridView1.DataBind(); //GridView2 数据绑定；
            }
            else
            {
                this.Label1.Text = "图纸不存在";
                this.GridView1.DataSource = dt; //将表dt的值传给Gridview1；
                this.GridView1.DataBind(); //GridView2 数据绑定；
            }
        }
    }
}