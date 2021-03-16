using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WaklingTech.Mvvm.Controllers;
using WaklingTech.Mvvm.ViewModel.AreaVMs;
using WalkingTec.Mvvm.Core;
using WaklingTech.Mvvm.DataAccess;

namespace WaklingTech.Mvvm.Test
{
    [TestClass]
    public class AreaControllerTest
    {
        private AreaController _controller;
        private string _seed;

        public AreaControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<AreaController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search((rv.Model as AreaListVM).Searcher);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(AreaVM));

            AreaVM vm = rv.Model as AreaVM;
            Area v = new Area();
			
            v.AreaName = "AyD9qo";
            v.ParentId = AddParent();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Area>().Find(v.ID);
				
                Assert.AreEqual(data.AreaName, "AyD9qo");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.AreaName = "AyD9qo";
                v.ParentId = AddParent();
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AreaVM));

            AreaVM vm = rv.Model as AreaVM;
            vm.Wtm.DC = new DataContext(_seed, DBTypeEnum.Memory);
            v = new Area();
            v.ID = vm.Entity.ID;
       		
            v.AreaName = "bLt4Lg7Ll";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.AreaName", "");
            vm.FC.Add("Entity.ParentId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Area>().Find(v.ID);
 				
                Assert.AreEqual(data.AreaName, "bLt4Lg7Ll");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.AreaName = "AyD9qo";
                v.ParentId = AddParent();
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(AreaVM));

            AreaVM vm = rv.Model as AreaVM;
            v = new Area();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Area>().Find(v.ID);
                Assert.AreEqual(data, null);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.AreaName = "AyD9qo";
                v.ParentId = AddParent();
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchEditTest()
        {
            Area v1 = new Area();
            Area v2 = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.AreaName = "AyD9qo";
                v1.ParentId = AddParent();
                v2.AreaName = "bLt4Lg7Ll";
                v2.ParentId = v1.ParentId; 
                context.Set<Area>().Add(v1);
                context.Set<Area>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AreaBatchVM));

            AreaBatchVM vm = rv.Model as AreaBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            
            vm.FC = new Dictionary<string, object>();
			
            _controller.DoBatchEdit(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Area>().Find(v1.ID);
                var data2 = context.Set<Area>().Find(v2.ID);
 				
            }
        }


        [TestMethod]
        public void BatchDeleteTest()
        {
            Area v1 = new Area();
            Area v2 = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.AreaName = "AyD9qo";
                v1.ParentId = AddParent();
                v2.AreaName = "bLt4Lg7Ll";
                v2.ParentId = v1.ParentId; 
                context.Set<Area>().Add(v1);
                context.Set<Area>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(AreaBatchVM));

            AreaBatchVM vm = rv.Model as AreaBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Area>().Find(v1.ID);
                var data2 = context.Set<Area>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }
        }

        private Guid AddParent()
        {
            Area v = new Area();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.AreaName = "Kkb";
                context.Set<Area>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
