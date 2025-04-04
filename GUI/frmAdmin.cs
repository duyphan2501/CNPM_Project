using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private bool isOpenKho = false;    //Biến cờ để biết trạng thái xổ menu

        private async void btnKho_Click(object sender, EventArgs e)
        {
            if(pnlKho.Height > btnKho.Height + 25)
            {
                isOpenKho = true;
            }
            if (isOpenKho == false)
            {
                //btnKho.FillColor = Color.FromArgb(128, 64, 0);     //Tô màu nút đang được xổ
                isOpenKho = true;
                for (int i = pnlKho.Height; i <= (4 * btnKho.Height) +25 ; i += 5)
                {
                    pnlKho.Height = i;
                    await Task.Delay(2);         // Dừng 5ms để tạo hiệu ứng mượt
                }
            }
            else
            {
                isOpenKho = false;
                pnlKho.Height = btnKho.Height + 15;
                //btnKho.FillColor = Color.FromArgb(212, 151, 96);   //Trở lại màu ban đầu khi tắt xổ
            }
        }

        private void btnLoinhuan_Click(object sender, EventArgs e)
        {

        }

        private void btnMathangbanchay_Click(object sender, EventArgs e)
        {

        }

        private void btnKiemkekho_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatnhapkho_Click(object sender, EventArgs e)
        {

        }

        private void btnTonkho_Click(object sender, EventArgs e)
        {

        }

        private bool isOpenBaocao = false;
        private async void btnBaocaoTK_Click(object sender, EventArgs e)
        {
            if (pnlBaocaoTK.Height > btnBaocaoTK.Height + 25)
            {
                isOpenBaocao = true;
            }
            if (isOpenBaocao == false)
            {
                //btnKho.FillColor = Color.FromArgb(128, 64, 0);     //Tô màu nút đang được xổ
                isOpenKho = true;
                for (int i = pnlBaocaoTK.Height; i <= (3 * btnBaocaoTK.Height) + 25; i += 5)
                {
                    pnlBaocaoTK.Height = i;
                    await Task.Delay(2);         // Dừng 5ms để tạo hiệu ứng mượt
                }
            }
            else
            {
                isOpenBaocao = false;
                pnlBaocaoTK.Height = btnBaocaoTK.Height + 15;
                //btnKho.FillColor = Color.FromArgb(212, 151, 96);   //Trở lại màu ban đầu khi tắt xổ
            }

        }

        //    private bool isOpenMenu = true;
        //    private async void picMenu_Click(object sender, EventArgs e)
        //    {
        //        if (!isOpenMenu)
        //        {
        //            isOpenMenu = true;
        //            for (int i = pnlMenu.Width; i <= btnDashboard.Width; i += 5)
        //            {
        //                pnlMenu.Width = i;
        //                await Task.Delay(2);         // Dừng 3ms để tạo hiệu ứng mượt
        //            }
        //        }
        //        else
        //        {
        //            pnlMenu.Width = 48;
        //            isOpenMenu = false;
        //        }

        //    }


        //    //Xổ menu Báo cáo thống kê
        //    private bool isOpenBaocao = false;

        //    private async void btnBaocaotk_Click_1(object sender, EventArgs e)
        //    {
        //        if (!isOpenBaocao)
        //        {
        //            btnBaocaotk.FillColor = Color.FromArgb(128, 64, 0);
        //            isOpenBaocao = true;
        //            for (int i = pnlBaocaotk.Height; i <= 3 * btnBaocaotk.Height + 6; i += 5)
        //            {
        //                pnlBaocaotk.Height = i;
        //                await Task.Delay(2);         // Dừng 3ms để tạo hiệu ứng mượt
        //            }
        //        }
        //        else
        //        {
        //            pnlBaocaotk.Height = btnBaocaotk.Height;
        //            isOpenBaocao = false;
        //            btnBaocaotk.FillColor = Color.FromArgb(212, 151, 96);
        //        }

        //    }

        //    private void btnDStaikhoan_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnDashboard_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnThucdon_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnXemdanhsachhanghoa_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnNhapkho_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnXuatkho_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnKiemkekho_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnThuchi_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnBaocaohoatdongkd_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private void btnThongkeluongmua_Click(object sender, EventArgs e)
        //    {

        //    }

        //    private bool isOpenMenu = true;
        //    private async void picMenu_Click(object sender, EventArgs e)
        //    {
        //        if (!isOpenMenu)
        //        {
        //            isOpenMenu = true;
        //            for (int i = pnlMenu.Width; i <= btnDashboard.Width; i += 5)
        //            {
        //                pnlMenu.Width = i;
        //                await Task.Delay(2);         // Dừng 3ms để tạo hiệu ứng mượt
        //            }
        //        }
        //        else
        //        {
        //            pnlMenu.Width = 48;
        //            isOpenMenu = false;
        //        }

        //    }

        //    private void frmAdmin_Load(object sender, EventArgs e)
        //    {
        //        pnlMenu.Width = btnBaocaotk.Width;
        //        pnlKho.Height = btnKho.Height;
        //        pnlBaocaotk.Height = btnBaocaotk.Height;

        //    }
    }
}
