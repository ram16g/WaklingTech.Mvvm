using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WaklingTech.Mvvm.Model
{
    [Table("Student")]
    public class Student:BasePoco
    {
        [Display(Name = "区域名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "年龄")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int Age { get; set; }
    }
}
