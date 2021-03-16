using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WalkingTec.Mvvm.Core
{
 
    [Table("Area")]
    public class Area : TreePoco<Area>
    {
        [Display(Name = "区域名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        //[NotMapped]
        //public string Sheng { get; set; }
        [NotMapped]
        public string Shi { get; set; }
        [NotMapped]
        public string Qu { get; set; }

    }


}

