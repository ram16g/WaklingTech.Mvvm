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
    public partial class StudentBatchVM : BaseBatchVM<Student, Student_BatchEdit>
    {
        public StudentBatchVM()
        {
            ListVM = new StudentListVM();
            LinkedVM = new Student_BatchEdit();
        }
        public override bool DoBatchEdit()
        {
            var ids = ListVM.Ids;


            foreach(string id in ids)
            {
                Student student = Wtm.DC.Set<Student>().Where(s => s.ID.ToString() == id).FirstOrDefault();
                student.Age +=LinkedVM.Age;
                DC.SaveChanges();
            }
            return true;
            
            //return base.DoBatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Student_BatchEdit : BaseVM
    {
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "年龄")]
        public Int32 Age { get; set; }

        protected override void InitVM()
        {
        }

    }

}
