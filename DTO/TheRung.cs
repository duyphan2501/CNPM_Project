using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheRung
    {
        private string MaThe, TenThe, TrangThai;
        public string _MaThe { get; set; }
        public string _TenThe { get; set; }
        public string _TrangThai { get; set; }

        public TheRung(string maThe, string tenThe, string trangThai)
        {
            this.MaThe = maThe;
            this.TenThe = tenThe;
            this.TrangThai = trangThai;
        }
    }
}
