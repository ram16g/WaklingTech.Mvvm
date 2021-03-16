using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace WaklingTech.Mvvm.ViewModel.CustomerVMs
{
    public partial class CustomerTemplateVM : BaseTemplateVM
    {
        [Display(Name = "客户卡号")]
        public ExcelPropety CardNum_Excel = ExcelPropety.CreateProperty<Customer>(x => x.CardNum);
        public ExcelPropety Station_Excel = ExcelPropety.CreateProperty<Customer>(x => x.StationId);
        public ExcelPropety Area_Excel = ExcelPropety.CreateProperty<Customer>(x => x.AreaId);
        public ExcelPropety community_Excel = ExcelPropety.CreateProperty<Customer>(x => x.communityId);
        public ExcelPropety building_Excel = ExcelPropety.CreateProperty<Customer>(x => x.buildingId);
        [Display(Name = "单元")]
        public ExcelPropety Unit_Excel = ExcelPropety.CreateProperty<Customer>(x => x.Unit);
        [Display(Name = "室")]
        public ExcelPropety Room_Excel = ExcelPropety.CreateProperty<Customer>(x => x.Room);
        [Display(Name = "客户名称")]
        public ExcelPropety CustomerName_Excel = ExcelPropety.CreateProperty<Customer>(x => x.CustomerName);
        [Display(Name = "身份证号")]
        public ExcelPropety IDCard_Excel = ExcelPropety.CreateProperty<Customer>(x => x.IDCard);
        [Display(Name = "建筑面积")]
        public ExcelPropety BuildingArea_Excel = ExcelPropety.CreateProperty<Customer>(x => x.BuildingArea);
        [Display(Name = "采暖面积")]
        public ExcelPropety HeatingArea_Excel = ExcelPropety.CreateProperty<Customer>(x => x.HeatingArea);

	    protected override void InitVM()
        {
            Station_Excel.DataType = ColumnDataType.ComboBox;
            Station_Excel.ListItems = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            Area_Excel.DataType = ColumnDataType.ComboBox;
            Area_Excel.ListItems = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            community_Excel.DataType = ColumnDataType.ComboBox;
            community_Excel.ListItems = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
            building_Excel.DataType = ColumnDataType.ComboBox;
            building_Excel.ListItems = DC.Set<Area>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class CustomerImportVM : BaseImportVM<CustomerTemplateVM, Customer>
    {

    }

}
