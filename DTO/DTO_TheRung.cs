using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TheRung
    {
        public string MaThe { get; set; }
        public string SoThe { get; set; }
        public int TrangThai { get; set; }

        public DTO_TheRung(string maThe, string soThe, int trangThai)
        {
            MaThe = maThe;
            SoThe = soThe;
            TrangThai = trangThai;
        }

        public DTO_TheRung() { }    
    }
}
