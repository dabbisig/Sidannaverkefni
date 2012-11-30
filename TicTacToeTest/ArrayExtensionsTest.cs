using TicTacToe.Core.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToeTest
{
    
    
    /// <summary>
    ///This is a test class for ArrayExtensionsTest and is intended
    ///to contain all ArrayExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ArrayExtensionsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CheckStatus
        ///</summary>
        [TestMethod()]
        public void CheckStatusTest()
        {
            int[] self1 = new int[] { 1, 1, 1, 0, 0, 0, 0, 0, 0 };
            int[] self2 = new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0 };
            int[] self3 = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 };
            int[] self4 = new int[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 };
            int[] self5 = new int[] { 0, 1, 0, 0, 1, 0, 0, 1, 0 };
            int[] self6 = new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 1 };
            int[] self7 = new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
            int[] self8 = new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 0 };
            Nullable<int> expected = new Nullable<int>();
            expected = 3 as Nullable<int>;
            Nullable<int> actual = new Nullable<int>();
            actual = ArrayExtensions.CheckStatus(self1);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self2);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self3);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self4);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self5);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self6);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self7);
            Assert.AreEqual(expected, actual);
            actual = ArrayExtensions.CheckStatus(self8);
            Assert.AreEqual(expected, actual);
        }
    }
}
