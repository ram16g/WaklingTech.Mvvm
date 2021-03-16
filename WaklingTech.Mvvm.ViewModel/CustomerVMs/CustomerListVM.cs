using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace WaklingTech.Mvvm.ViewModel.CustomerVMs
{
    public partial class CustomerListVM : BasePagedListVM<Customer_View, CustomerSearcher>
    {
        
        public List<TreeSelectListItem> AllAreas { get; set; }

        protected override void InitVM()
        {
            AllAreas = DC.Set<Area>().GetTreeSelectListItems(Wtm, x => x.Name);
        }

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "", dialogWidth: 800),
                this.MakeStandardAction("Customer", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], ""),
            };
        }


        protected override IEnumerable<IGridColumn<Customer_View>> InitGridHeader()
        {
            return new List<GridColumn<Customer_View>>{
                this.MakeGridHeader(x => x.CardNum),
                this.MakeGridHeader(x => x.AreaName_view),
                this.MakeGridHeader(x => x.AreaName_view2),
                this.MakeGridHeader(x => x.AreaName_view3),
                this.MakeGridHeader(x => x.AreaName_view4),
                this.MakeGridHeader(x => x.Unit),
                this.MakeGridHeader(x => x.Room),
                this.MakeGridHeader(x => x.CustomerName),
                this.MakeGridHeader(x => x.IDCard),
                this.MakeGridHeader(x => x.BuildingArea),
                this.MakeGridHeader(x => x.HeatingArea),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Customer_View> GetSearchQuery()
        {
            var query = DC.Set<Customer>()
                .CheckContain(Searcher.CardNum, x=>x.CardNum)
                .CheckEqual(Searcher.StationId, x=>x.StationId)
                .CheckEqual(Searcher.AreaId, x=>x.AreaId)
                .CheckEqual(Searcher.communityId, x=>x.communityId)
                .CheckEqual(Searcher.buildingId, x=>x.buildingId)
                .CheckContain(Searcher.Unit, x=>x.Unit)
                .CheckEqual(Searcher.Room, x=>x.Room)
                .CheckContain(Searcher.CustomerName, x=>x.CustomerName)
                .CheckContain(Searcher.IDCard, x=>x.IDCard)
                .CheckEqual(Searcher.BuildingArea, x=>x.BuildingArea)
                .CheckEqual(Searcher.HeatingArea, x=>x.HeatingArea)
                .Select(x => new Customer_View
                {
				    ID = x.ID,
                    CardNum = x.CardNum,
                    AreaName_view = x.Station.Name,
                    AreaName_view2 = x.Area.Name,
                    AreaName_view3 = x.community.Name,
                    AreaName_view4 = x.building.Name,
                    Unit = x.Unit,
                    Room = x.Room,
                    CustomerName = x.CustomerName,
                    IDCard = x.IDCard,
                    BuildingArea = x.BuildingArea,
                    HeatingArea = x.HeatingArea,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Customer_View : Customer{
        [Display(Name = "区域名称")]
        public String AreaName_view { get; set; }
        [Display(Name = "区域名称")]
        public String AreaName_view2 { get; set; }
        [Display(Name = "区域名称")]
        public String AreaName_view3 { get; set; }
        [Display(Name = "区域名称")]
        public String AreaName_view4 { get; set; }

    }
}
