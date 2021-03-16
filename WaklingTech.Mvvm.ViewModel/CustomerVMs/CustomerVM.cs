using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;


namespace WaklingTech.Mvvm.ViewModel.CustomerVMs
{
    public partial class CustomerVM : BaseCRUDVM<Customer>
    {
        public List<ComboSelectListItem> AllStations { get; set; }
        public List<ComboSelectListItem> AllAreas { get; set; }
        public List<ComboSelectListItem> Allcommunitys { get; set; }
        public List<ComboSelectListItem> Allbuildings { get; set; }

        public CustomerVM()
        {
            SetInclude(x => x.Station);
            SetInclude(x => x.Area);
            SetInclude(x => x.community);
            SetInclude(x => x.building);
        }

        protected override void InitVM()
        {
            AllStations = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            AllAreas = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            Allcommunitys = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            Allbuildings = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
