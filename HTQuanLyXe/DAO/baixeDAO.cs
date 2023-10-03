﻿using HTQuanLyXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQuanLyXe.DAO
{
    class baixeDAO
    {
        private static baixeDAO instance;

        internal static baixeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new baixeDAO();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        public List<baixeDTO> hienthi()
        {
            String Query = "select * from BAIXE ";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            List<baixeDTO> listve = new List<baixeDTO>();
            foreach (DataRow item in data.Rows)
            {
                baixeDTO dt = new baixeDTO(item);
                listve.Add(dt);
            }
            return listve;
        }
        //kiểm tra số vị trí ô tô trống
        public int tongototrong()
        {
            int so = 0;
            String Query = "select * from BAIXE where loaiXe=N'Ô tô'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                so = b.Sochotrong;
            }
            return so;
        }
        //kiểm tra số vị trí xe máy trống
        public int tongxemaytrong()
        {
            int so = 0;
            String Query = "select * from BAIXE where loaiXe=N'Xe máy'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                so = b.Sochotrong;
            }
            return so;
        }
        public int tongoto()
        {
            int so = 0;
            String Query = "select * from BAIXE where loaiXe=N'Ô tô'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                so = b.Tongsocho;
            }
            return so;
        }
        //kiểm tra số vị trí xe máy trống
        public int tongxemay()
        {
            int so = 0;
            String Query = "select * from BAIXE where loaiXe=N'Xe máy'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                so = b.Tongsocho;
            }
            return so;
        }
        //thay đổi thông tin bến
        public Boolean thaydoiben(int oto, int xemay)
        {
            string query3 = "update BAIXE set soChoTrong=("+oto+"-(select count(bienSo) from XE where loaiXe='Xe máy')) where loaiXe='Xe máy'";
            string query4 = "update BAIXE set soChoTrong=("+xemay+"-(select count(bienSo) from XE where loaiXe='Ô tô')) where loaiXe='Ô tô'";
            string query = "update BAIXE set tongSoCho="+oto+" where loaiXe='Ô tô'";
            string query2 = "update BAIXE set tongSoCho=" + xemay + " where loaiXe='Xe máy'";
            int o = dataprovider.Instance.ExcuteNonQuery(query3);
            int a = dataprovider.Instance.ExcuteNonQuery(query4);
            int b = dataprovider.Instance.ExcuteNonQuery(query);
            int m = dataprovider.Instance.ExcuteNonQuery(query2);
            return (0 < m && 0 < o&& 0<a&& 0<b);
        }
        //tiền vé xe máy
        public int tienveoto()
        {
            int gia=0;
            String Query = "select * from BAIXE where loaiXe='Ô tô'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                gia = b.Tien;
            }
            return gia;
        }
        public int tienvexemay()
        {
            int gia = 0;
            String Query = "select * from BAIXE where loaiXe=N'Xe máy'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                gia = b.Tien;
            }
            return gia;
        }
        public Boolean fullben(string loaixe)
        {
            int so = 0;
            String Query = "select * from BAIXE where loaiXe=N'"+loaixe+"'";
            DataTable data = new DataTable();
            data = dataprovider.Instance.ExcuteQuery(Query);
            foreach (DataRow item in data.Rows)
            {
                baixeDTO b = new baixeDTO(item);
                so = b.Sochotrong;
            }
            return so<=0;
        }

    }
}
