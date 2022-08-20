using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLSV;
namespace BUS_QLBH
{
    public class BUS_QuanLy
    {
        DAL_QuanLy dal = new DAL_QuanLy();
        public DataTable showdgv()
        {
            string srt = "select MaSV, HoTen, Nu, QueQuan, Tuoi from Student";
            return dal.gettable(srt);
        }
        public DataTable showcb()
        {
            string srt = "select*from Class";
            return dal.gettable(srt);
        }
        public void InsertSQL(string msv, string Tensv, string Nu, string QueQuan, string tuoi, string Malop)
        {
            string srt = "insert into Student values('" + msv + "',N'" + Tensv + "','" + Nu + "',N'" + QueQuan + "'," + tuoi + ",'" + Malop + "')";
            dal.ExecuteNonQuery(srt);
        }
        public void DELETESQL(string msv)
        {
            string srt = "DELETE Student where MaSV='"+msv+"'";
            dal.ExecuteNonQuery(srt);
        }
        //Lay Ten lop qua ma sv
        public string TenLop(string Masv)
        {
            string srt = "Select TenLop from class inner join Student on Class.MaLop=Student.MaLop where MaSV='" + Masv + "'";
            return dal.tencb(srt);
        }
        public bool check(string Masv)
        {
            string  srt = "select * from Student where MaSV='" + Masv + "'";
            DataTable tb = dal.gettable(srt);
            if (tb.Rows.Count == 0)
                return true;
            else
                return false;
        }
    }
}
