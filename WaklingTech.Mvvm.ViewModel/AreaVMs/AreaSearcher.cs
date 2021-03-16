using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace WaklingTech.Mvvm.ViewModel.AreaVMs
{
    public partial class AreaSearcher : BaseSearcher
    {
        [Display(Name = "区域名称")]
        public String AreaName { get; set; }
        public List<ComboSelectListItem> AllParents { get; set; }
        [Display(Name = "_Admin.Parent")]
        public Guid? ParentId { get; set; }

        protected override void InitVM()
        {
            AllParents = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
