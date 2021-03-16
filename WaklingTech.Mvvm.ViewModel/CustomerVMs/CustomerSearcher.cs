using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;


namespace WaklingTech.Mvvm.ViewModel.CustomerVMs
{
    public partial class CustomerSearcher : BaseSearcher
    {
        [Display(Name = "客户卡号")]
        public String CardNum { get; set; }
        public List<ComboSelectListItem> AllStations { get; set; }
        [Display(Name = "换热站")]
        public Guid? StationId { get; set; }
        public List<ComboSelectListItem> AllAreas { get; set; }
        public Guid? AreaId { get; set; }
        public List<ComboSelectListItem> Allcommunitys { get; set; }
        public Guid? communityId { get; set; }
        public List<ComboSelectListItem> Allbuildings { get; set; }
        public Guid? buildingId { get; set; }
        [Display(Name = "单元")]
        public String Unit { get; set; }
        [Display(Name = "室")]
        public Int32? Room { get; set; }
        [Display(Name = "客户名称")]
        public String CustomerName { get; set; }
        [Display(Name = "身份证号")]
        public String IDCard { get; set; }
        [Display(Name = "建筑面积")]
        public Int32? BuildingArea { get; set; }
        [Display(Name = "采暖面积")]
        public Int32? HeatingArea { get; set; }

        protected override void InitVM()
        {
            AllStations = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            AllAreas = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            Allcommunitys = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            Allbuildings = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
