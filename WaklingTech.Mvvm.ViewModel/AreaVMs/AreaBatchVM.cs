using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;


namespace WaklingTech.Mvvm.ViewModel.AreaVMs
{
    public partial class AreaBatchVM : BaseBatchVM<Area, Area_BatchEdit>
    {
        public AreaBatchVM()
        {
            ListVM = new AreaListVM();
            LinkedVM = new Area_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Area_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
