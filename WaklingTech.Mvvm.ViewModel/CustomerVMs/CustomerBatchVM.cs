using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;


namespace WaklingTech.Mvvm.ViewModel.CustomerVMs
{
    public partial class CustomerBatchVM : BaseBatchVM<Customer, Customer_BatchEdit>
    {
        public CustomerBatchVM()
        {
            ListVM = new CustomerListVM();
            LinkedVM = new Customer_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Customer_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
