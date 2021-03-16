using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WaklingTech.Mvvm.Controllers;
using WaklingTech.Mvvm.ViewModel.CustomerVMs;
using WalkingTec.Mvvm.Core;
using WaklingTech.Mvvm.DataAccess;

namespace WaklingTech.Mvvm.Test
{
    [TestClass]
    public class CustomerControllerTest
    {
        private CustomerController _controller;
        private string _seed;

        public CustomerControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<CustomerController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as CustomerListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerVM));

            CustomerVM vm = rv.Model as CustomerVM;
            Customer v = new Customer();
			
            v.CardNum = "Ododn6F";
            v.StationId = AddStation();
            v.AreaId = AddArea();
            v.communityId = Addcommunity();
            v.buildingId = Addbuilding();
            v.Unit = "JFwD3";
            v.Room = 12;
            v.CustomerName = "UGbmE";
            v.IDCard = "vVV";
            v.BuildingArea = 98;
            v.HeatingArea = 92;
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customer>().Find(v.ID);
				
                Assert.AreEqual(data.CardNum, "Ododn6F");
                Assert.AreEqual(data.Unit, "JFwD3");
                Assert.AreEqual(data.Room, 12);
                Assert.AreEqual(data.CustomerName, "UGbmE");
                Assert.AreEqual(data.IDCard, "vVV");
                Assert.AreEqual(data.BuildingArea, 98);
                Assert.AreEqual(data.HeatingArea, 92);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.CardNum = "Ododn6F";
                v.StationId = AddStation();
                v.AreaId = AddArea();
                v.communityId = Addcommunity();
                v.buildingId = Addbuilding();
                v.Unit = "JFwD3";
                v.Room = 12;
                v.CustomerName = "UGbmE";
                v.IDCard = "vVV";
                v.BuildingArea = 98;
                v.HeatingArea = 92;
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerVM));

            CustomerVM vm = rv.Model as CustomerVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Customer();
            v.ID = vm.Entity.ID;
       		
            v.CardNum = "z5NK";
            v.Unit = "YDj5hILg";
            v.Room = 79;
            v.CustomerName = "Lf2u3";
            v.IDCard = "TnIdHzjDR";
            v.BuildingArea = 28;
            v.HeatingArea = 90;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.CardNum", "");
            vm.FC.Add("Entity.StationId", "");
            vm.FC.Add("Entity.AreaId", "");
            vm.FC.Add("Entity.communityId", "");
            vm.FC.Add("Entity.buildingId", "");
            vm.FC.Add("Entity.Unit", "");
            vm.FC.Add("Entity.Room", "");
            vm.FC.Add("Entity.CustomerName", "");
            vm.FC.Add("Entity.IDCard", "");
            vm.FC.Add("Entity.BuildingArea", "");
            vm.FC.Add("Entity.HeatingArea", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customer>().Find(v.ID);
 				
                Assert.AreEqual(data.CardNum, "z5NK");
                Assert.AreEqual(data.Unit, "YDj5hILg");
                Assert.AreEqual(data.Room, 79);
                Assert.AreEqual(data.CustomerName, "Lf2u3");
                Assert.AreEqual(data.IDCard, "TnIdHzjDR");
                Assert.AreEqual(data.BuildingArea, 28);
                Assert.AreEqual(data.HeatingArea, 90);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.CardNum = "Ododn6F";
                v.StationId = AddStation();
                v.AreaId = AddArea();
                v.communityId = Addcommunity();
                v.buildingId = Addbuilding();
                v.Unit = "JFwD3";
                v.Room = 12;
                v.CustomerName = "UGbmE";
                v.IDCard = "vVV";
                v.BuildingArea = 98;
                v.HeatingArea = 92;
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerVM));

            CustomerVM vm = rv.Model as CustomerVM;
            v = new Customer();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Customer>().Find(v.ID);
                Assert.AreEqual(data, null);
          }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Customer v = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.CardNum = "Ododn6F";
                v.StationId = AddStation();
                v.AreaId = AddArea();
                v.communityId = Addcommunity();
                v.buildingId = Addbuilding();
                v.Unit = "JFwD3";
                v.Room = 12;
                v.CustomerName = "UGbmE";
                v.IDCard = "vVV";
                v.BuildingArea = 98;
                v.HeatingArea = 92;
                context.Set<Customer>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Customer v1 = new Customer();
            Customer v2 = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CardNum = "Ododn6F";
                v1.StationId = AddStation();
                v1.AreaId = AddArea();
                v1.communityId = Addcommunity();
                v1.buildingId = Addbuilding();
                v1.Unit = "JFwD3";
                v1.Room = 12;
                v1.CustomerName = "UGbmE";
                v1.IDCard = "vVV";
                v1.BuildingArea = 98;
                v1.HeatingArea = 92;
                v2.CardNum = "z5NK";
                v2.StationId = v1.StationId; 
                v2.AreaId = v1.AreaId; 
                v2.communityId = v1.communityId; 
                v2.buildingId = v1.buildingId; 
                v2.Unit = "YDj5hILg";
                v2.Room = 79;
                v2.CustomerName = "Lf2u3";
                v2.IDCard = "TnIdHzjDR";
                v2.BuildingArea = 28;
                v2.HeatingArea = 90;
                context.Set<Customer>().Add(v1);
                context.Set<Customer>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerBatchVM));

            CustomerBatchVM vm = rv.Model as CustomerBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Customer>().Find(v1.ID);
                var data2 = context.Set<Customer>().Find(v2.ID);
 				
                Assert.AreEqual(data1.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data1.UpdateTime.Value).Seconds < 10);
                Assert.AreEqual(data2.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data2.UpdateTime.Value).Seconds < 10);
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Customer v1 = new Customer();
            Customer v2 = new Customer();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.CardNum = "Ododn6F";
                v1.StationId = AddStation();
                v1.AreaId = AddArea();
                v1.communityId = Addcommunity();
                v1.buildingId = Addbuilding();
                v1.Unit = "JFwD3";
                v1.Room = 12;
                v1.CustomerName = "UGbmE";
                v1.IDCard = "vVV";
                v1.BuildingArea = 98;
                v1.HeatingArea = 92;
                v2.CardNum = "z5NK";
                v2.StationId = v1.StationId; 
                v2.AreaId = v1.AreaId; 
                v2.communityId = v1.communityId; 
                v2.buildingId = v1.buildingId; 
                v2.Unit = "YDj5hILg";
                v2.Room = 79;
                v2.CustomerName = "Lf2u3";
                v2.IDCard = "TnIdHzjDR";
                v2.BuildingArea = 28;
                v2.HeatingArea = 90;
                context.Set<Customer>().Add(v1);
                context.Set<Customer>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(CustomerBatchVM));

            CustomerBatchVM vm = rv.Model as CustomerBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Customer>().Find(v1.ID);
                var data2 = context.Set<Customer>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as CustomerListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddStation()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.AreaName = "ltK";
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid AddArea()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.AreaName = "zOsh";
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid Addcommunity()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.AreaName = "j5Tlxswsg";
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }

        private Guid Addbuilding()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.AreaName = "NYkyuFi";
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
