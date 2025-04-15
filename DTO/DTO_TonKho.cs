using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_TonKho
    {
        //private string MaNL, MaTon;
        //private int SoLuongTon, MucToiThieu, MucOnDinh;

        public string MaTon { get; set; }
        public string MaNL { get; set; }
        public int SoLuongTon { get; set; }
        public int MucToiThieu { get; set; }
        public int MucOnDinh { get; set; }

        public DTO_TonKho(string maton, string manl, int soluongton, int muctoithieu, int mucondinh)
        {
            this.MaTon = maton;
            this.MaNL = manl;
            this.SoLuongTon = soluongton;
            this.MucOnDinh = mucondinh;
            this.MucToiThieu = muctoithieu;
        }
    }
}
