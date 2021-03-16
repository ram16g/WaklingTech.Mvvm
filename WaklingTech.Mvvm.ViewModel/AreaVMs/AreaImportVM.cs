using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;


namespace WaklingTech.Mvvm.ViewModel.AreaVMs
{
    public partial class AreaTemplateVM : BaseTemplateVM
    {
        [Display(Name = "省")]
        public ExcelPropety Sheng_Excel = ExcelPropety.CreateProperty<Area>(x => x.Name);
        [Display(Name = "市")]
        public ExcelPropety Shi_Excel = ExcelPropety.CreateProperty<Area>(x => x.Shi);
        [Display(Name = "区")]
        public ExcelPropety Qu_Excel = ExcelPropety.CreateProperty<Area>(x => x.Qu);

        protected override void InitVM()
        {
            
        }

    }

    public class AreaImportVM : BaseImportVM<AreaTemplateVM, Area>
    {
        public override bool BatchSaveData()
        {
            this.SetEntityList();
            List<Area> newList = new List<Area>();
            var shengs = EntityList.Select(x => x.Name).Distinct();

            foreach (var sheng in shengs)
            {
                Area c = new Area
                {
                    Name = sheng
                };
                newList.Add(c);
                var shis = EntityList.Where(x => x.Name == sheng).Select(x => x.Shi).Distinct();
                foreach (var shi in shis)
                {
                    Area c2 = new Area
                    {
                        Name = shi,
                        Parent = c,
                        ParentId = c.ID
                    };
                    newList.Add(c2);
                    var qus = EntityList.Where(x => x.Name == sheng && x.Shi == shi && x.Qu != "市辖区").Select(x => x.Qu).Distinct();
                    foreach (var qu in qus)
                    {
                        Area c3 = new Area
                        {
                            Name = qu,
                            Parent = c2,
                            ParentId = c2.ID
                        };
                        newList.Add(c3);
                    }
                }
            }
            this.EntityList = newList;
            return base.BatchSaveData();
        }
    }

}
