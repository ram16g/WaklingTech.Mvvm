using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// Customer
    /// </summary>
    [Table("Customer")]
    public class Customer : BasePoco
    {
        [Display(Name = "客户卡号")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string CardNum { get; set; }

        [Display(Name = "供热点")]
        public Guid? StationId { get; set; }
        public Area Station { get; set; }

        [Display(Name = "片区")]
        public Guid? AreaId { get; set; }
        public Area Area { get; set; }

        [Display(Name = "小区")]
        public Guid? communityId { get; set; }
        public Area community { get; set; }

        [Display(Name = "楼号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? buildingId { get; set; }
        public Area building { get; set; }


        [Display(Name = "单元")]
        public string Unit { get; set; }

        [Display(Name = "室")]
        public int Room { get; set; }

        [Display(Name = "客户名称")]
        [StringLength(10, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string CustomerName { get; set; }

        [Display(Name = "身份证号")]
        [StringLength(18, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string IDCard { get; set; }

        [Display(Name = "建筑面积")]
        public int BuildingArea { get; set; }

        [Display(Name = "采暖面积")]
        public int HeatingArea { get; set; }
    }
}
