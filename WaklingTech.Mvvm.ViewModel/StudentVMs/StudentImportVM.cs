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
    public partial class StudentTemplateVM : BaseTemplateVM
    {
        [Display(Name = "区域名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Student>(x => x.Name);
        [Display(Name = "年龄")]
        public ExcelPropety Age_Excel = ExcelPropety.CreateProperty<Student>(x => x.Age);

	    protected override void InitVM()
        {
        }

    }

    public class StudentImportVM : BaseImportVM<StudentTemplateVM, Student>
    {

    }

}
