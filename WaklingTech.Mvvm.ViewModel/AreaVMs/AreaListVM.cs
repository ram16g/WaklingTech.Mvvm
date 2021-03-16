using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace WaklingTech.Mvvm.ViewModel.AreaVMs
{
    public partial class AreaListVM : BasePagedListVM<Area_View, AreaSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "", dialogWidth: 800),
                this.MakeStandardAction("Area", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], ""),
            };
        }


        protected override IEnumerable<IGridColumn<Area_View>> InitGridHeader()
        {
            return new List<GridColumn<Area_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.AreaName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Area_View> GetSearchQuery()
        {
            var query = DC.Set<Area>()
                .CheckContain(Searcher.AreaName, x=>x.Name)
                .CheckEqual(Searcher.ParentId, x=>x.ParentId)
                .Select(x => new Area_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    AreaName_view = x.Parent.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Area_View : Area{
        [Display(Name = "区域名称")]
        public String AreaName_view { get; set; }

    }
}
