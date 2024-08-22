using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MalusAdmin.BackUpServices.Model
{
    public class bs_bingwallpaper
    {

        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        public string CopyRight { get; set; }
        public string GitUrl { get; set; }
        public string Url { get; set; }
        public string MobileUrl { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean IsDeleted { get; set; } = false;
    }
}
