using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Testing_and_DI_Quiz;

namespace QuizTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fakeDataAccess = new Mock<IDataAccess>();
            Employee employee = new Employee();
            fakeDataAccess.Setup(e => e.GetEmployee(It.IsAny<int>())).Returns(employee);
            fakeDataAccess.Setup(e => e.GetEmployeeSalary(It.IsAny<int>())).Returns(23.524);
        }
    }
}
