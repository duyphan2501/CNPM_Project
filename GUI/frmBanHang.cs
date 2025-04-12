using BUS;
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
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // fullscreen
            int widthScreen = Screen.PrimaryScreen.Bounds.Width;
            int heightScreen = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(widthScreen, heightScreen);

            // giảm lag khi chứa nhiều item trong panel
            typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, pnlInvoiceItem, new object[] { true });

            // lấy ra loại sản phẩm
            loaiSanphamBUS = new BUS_LoaiSanPham();
            DataTable loaiSanPham = new DataTable();
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
            foreach (DataRow dr in onSaleProducts.Rows)
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

            foreach (Control ctrl in pnlInvoiceItem.Controls)
            {
                if (ctrl is InvoiceItem existingItem && existingItem.TenMon == tenmon)
                {
                    existingItem.IncreaseQuantity();
                    return;
                }
            }

            InvoiceItem newItem = new InvoiceItem(tenmon, dongia, 1);
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
