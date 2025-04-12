using BUS;
using cnpm;
using GUI.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }

        BUS_LoaiSanPham loaiSanphamBUS;
        BUS_SanPham sanPhamBUS;
        BUS_CaLamViec calam;
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // fullscreen
            int widthScreen = Screen.PrimaryScreen.Bounds.Width;
            int heightScreen = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(widthScreen, heightScreen);

            //kiểm tra mở ca chưa
            KiemTraMoCa();

            // giảm lag khi chứa nhiều item trong panel
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlInvoiceItem, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlThucDon, new object[] { true });

            // lấy ra loại sản phẩm
            loaiSanphamBUS = new BUS_LoaiSanPham();
            string[] categoryProductName = loaiSanphamBUS.GetAllCategoryProduct();

            //tải lên pnlProductCategory
            foreach (string category in categoryProductName)
            {
                pnlProductCategory.Controls.Add(new ProductCategory(category));
            }

            // Lấy sản phẩm còn bán
            sanPhamBUS = new BUS_SanPham();
            DataTable onSaleProducts = sanPhamBUS.SelectOnSaleProduct();

            // Tải lên pnlThucDon
            loadProduct(onSaleProducts);
        }

        private void KiemTraMoCa()
        {
            var calam = new BUS_CaLamViec();
            string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();
            Program.shift = calam.selectOpenShift(tenDangNhap);

            if (Program.shift.Rows.Count == 0)
            {
                frmMoCaLam frmMoCaLam = new frmMoCaLam();
                General.ShowDialogWithBlur(frmMoCaLam);
            }
        }


        private void loadProduct(DataTable products)
        {
            foreach (DataRow dr in products.Rows)
            {
                // Lấy dữ liệu từ DataRow
                string productName = dr["TenSp"].ToString();
                byte[] productImage = dr["HinhAnh"] as byte[];
                int productPrice = Convert.ToInt32(dr["GiaBan"]);

                // Tạo đối tượng Widget với constructor đã tạo sẵn
                Widget widget = new Widget(productImage, productName, productPrice);
                widget.ThemSanPhamClicked += Widget_ThemSanPhamClicked;
                // Thêm Widget vào Panel (giả sử pnlThucDon là một Panel có sẵn trên Form)
                pnlThucDon.Controls.Add(widget);
            }
        }

        private void Widget_ThemSanPhamClicked(object sender, EventArgs e)
        {
            Widget widget = sender as Widget;
            string tenmon = widget.TenSanPham;
            int dongia = widget.GiaSanPham;
            // kiểm tra đã có trong pnlInvoiceItem chưa
            foreach (Control ctrl in pnlInvoiceItem.Controls)
            {
                if (ctrl is InvoiceItem existingItem && existingItem.TenMon == tenmon)
                {
                    // có thì tăg số lượng
                    existingItem.IncreaseQuantity();
                    return;
                }
            }
            // ko thì thêm vào
            InvoiceItem newItem = new InvoiceItem(tenmon, dongia, 1);
            // thêm event click để gửi dữ liệu cho frm cha
            newItem.XoaItemClicked += InvoiceItem_XoaItemClicked;
            pnlInvoiceItem.Controls.Add(newItem);
        }

        private void InvoiceItem_XoaItemClicked(object sender, EventArgs e)
        {
            if (sender is InvoiceItem item)
            {
                // Xóa khỏi Panel
                pnlInvoiceItem.Controls.Remove(item);
            }
        }

        private void txtTimMon_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimMon.Text.Trim().ToLower();

            foreach (Control ctrl in pnlThucDon.Controls)
            {
                if (ctrl is Widget widget)
                {
                    // So sánh tên sản phẩm có chứa từ khóa hay không
                    string tenSp = widget.TenSanPham.ToLower();
                    widget.Visible = tenSp.Contains(keyword);
                }
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            frmTheRung frmTheRung = new frmTheRung();
            General.ShowDialogWithBlur(frmTheRung);
        }
    }
}
