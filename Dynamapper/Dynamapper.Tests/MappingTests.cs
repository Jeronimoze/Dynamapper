using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dynamapper.Tests
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void MapperExtensionMap_WhenDynamicResultIsNull_ReturnEmptyEntityList()
        {
            // arrange

            // act
            var results = MapperExtension.Map<EmployeeEntityTest>(null);

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityTest>));
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void MapperExtensionMap_WhenDynamicListEmpty_ReturnEmptyEntityList()
        {
            // arrange
            var queryResults = new List<dynamic>();

            // act
            var results = queryResults.Map<EmployeeEntityTest>();

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityTest>));
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void MapperExtensionMap_WhenDynamicListOneValue_ReturnEntityList()
        {
            // arrange
            var queryResults = new List<dynamic>();
            var properties = new Dictionary<string, object>();
            properties.Add("Id", 1);
            properties.Add("Name", 1);
            properties.Add("Age", 42);
            properties.Add("Salary", 175000M);
            queryResults.Add(properties);

            // act
            var results = MapperExtension.Map<EmployeeEntityTest>(queryResults);

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityTest>));
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void MapperExtensionMap_WhenDynamicListOneValueNull_ReturnEntityList()
        {
            // arrange
            var queryResults = new List<dynamic>();
            var properties = new Dictionary<string, object>();
            properties.Add("Id", 1);
            properties.Add("Name", 1);

            queryResults.Add(properties);

            // act
            var results = MapperExtension.Map<EmployeeEntityTest>(queryResults);

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityTest>));
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void MapperExtensionMap_WhenDynamicListOneValueNameIsNull_ReturnEntityList()
        {
            // arrange
            var queryResults = new List<dynamic>();
            var properties = new Dictionary<string, object>();
            properties.Add("Id", 1);
            properties.Add("Age", 42);
            properties.Add("Salary", 175000M);

            queryResults.Add(properties);

            // act
            var results = MapperExtension.Map<EmployeeEntityTest>(queryResults);

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityTest>));
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void MapperExtensionMap_WhenDynamicListOneValuePlusColumnAttribe_ReturnEntityList()
        {
            // arrange
            var queryResults = new List<dynamic>();
            var properties = new Dictionary<string, object>();
            properties.Add("Id", 1);
            properties.Add("Name", "Test");
            properties.Add("Age", 42);
            properties.Add("Salary", 175000M);

            queryResults.Add(properties);

            // act
            var results = MapperExtension.Map<EmployeeEntityColumnAttributeTest>(queryResults);

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityColumnAttributeTest>));
            Assert.AreEqual(1, results.Count());
        }

        [TestMethod]
        public void MapperExtensionMap_WhenDynamicListOneValuePlusColumnAttribeNotFound_ReturnEntityList()
        {
            // arrange
            var queryResults = new List<dynamic>();
            var properties = new Dictionary<string, object>();
            properties.Add("Id", 1);
            properties.Add("NameTest", "Test");
            properties.Add("Age", 42);
            properties.Add("Salary", 175000M);

            queryResults.Add(properties);

            // act
            var results = MapperExtension.Map<EmployeeEntityColumnAttributeTest>(queryResults);

            // assert
            Assert.IsNotNull(results);
            Assert.IsInstanceOfType(results, typeof(IEnumerable<EmployeeEntityColumnAttributeTest>));
            Assert.AreEqual(1, results.Count());
        }
    }
}
