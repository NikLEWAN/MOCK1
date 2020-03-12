using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCustomerServiceCoreY.Model;
using RestCustomerServiceCoreY.Controllers;
using System;
using System.Collections.Generic;

namespace UnitTestCustomer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CustomerController cc = new CustomerController();
            List<Customer> cList = cc.Get();
            Assert.AreEqual(6, cList.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CustomerController cc = new CustomerController();
            //List<Customer> cList = cc.Get();
            //Customer c = new Customer("Ny", "Ny", 1988);
            //c = cList[0];
            Customer c = cc.GetCustomer(0);
            
  
            Assert.AreEqual(c.Titel, "Hans");
            Customer c1 = cc.GetCustomer(17);
            Assert.IsNull(c1);

        }


        [TestMethod]
        public void TestMethod3()
        {
            CustomerController cc = new CustomerController();
            Customer c = new Customer("Ny", "Ny", 1988);
            List<Customer> cList = cc.Get();
            int preCount = cList.Count;
            cc.InsertCustomer(c);
            Assert.AreEqual(preCount+1, cList.Count);
               }



        [TestMethod]
        public void TestMethodDelete()
        {
            CustomerController cc = new CustomerController();

            List<Customer> cList = cc.Get();
            int preCount = cList.Count;
            Customer c = cc.GetCustomer(3);
            Customer c1 = cc.DeleteCustomer(3);
            Assert.AreEqual(preCount - 1, cList.Count);
            Assert.AreEqual(3, c1.Isbn13);
            //Cannot delete customers with ID < 3
            Customer c2 = cc.DeleteCustomer(0);
            Assert.IsNull(c2);
            Customer c3 = cc.DeleteCustomer(17);
            Assert.IsNull(c3);


        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            CustomerController cc = new CustomerController();
            Customer c = cc.GetCustomer(0);
            c.Titel = c.Titel + "1";        
            Customer x = cc.UpdateCustomer(0,c);
            Assert.AreEqual(x.Titel, c.Titel);

            Customer c1 = new Customer("NewFirst", "NewLast", c.Sidetal+1);
            Customer y = cc.UpdateCustomer(0, c1);
            Assert.AreEqual(y.Titel, c.Titel);

            Customer z = cc.UpdateCustomer(17, c1);
            Assert.IsNull(z);

        }

    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethodDelete1()
        {
            CustomerController cc = new CustomerController();

            List<Customer> cList = cc.Get();
            int preCount = cList.Count;
            Customer c = cc.GetCustomer(4);
            Customer c1 = cc.DeleteCustomer(4);
            Assert.AreEqual(preCount - 1, cList.Count);
            Assert.AreEqual(4, c1.Isbn13);
        }
    }
}
