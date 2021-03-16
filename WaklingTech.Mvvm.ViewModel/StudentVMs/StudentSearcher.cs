using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WaklingTech.Mvvm.Model;


namespace WaklingTech.Mvvm.ViewModel.StudentVMs
{
    public partial class StudentSearcher : BaseSearcher
    {
        [Display(Name = "区域名称")]
        public String Name { get; set; }
        [Display(Name = "年龄")]
        public Int32? Age { get; set; }

        protected override void InitVM()
        {
        }

    }
}
