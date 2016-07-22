using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers.Drawing;

namespace Common.Helpers.Tests
{
    [TestClass]
    public class DrawingTests
    {
        [TestMethod]
        public void NoScaleTest()
        {
            var quadrilateral = new Quadrilateral(500, 500);
            var scale = quadrilateral.Scale(500, 500);

            Assert.AreEqual(quadrilateral.Width, scale.Width);
            Assert.AreEqual(quadrilateral.Height, scale.Height);
        }

        [TestMethod]
        public void ScaleDownUsingWidthTest()
        {
            var quadrilateral = new Quadrilateral(500, 500);
            var scale = quadrilateral.Scale(851, 314);

            Assert.AreEqual(500, scale.Width);
            Assert.AreEqual(184, scale.Height);
        }

        [TestMethod]
        public void ScaleDownUsingHeightTest()
        {
            var quadrilateral = new Quadrilateral(500, 500);
            var scale = quadrilateral.Scale(314, 851);

            Assert.AreEqual(184, scale.Width);
            Assert.AreEqual(500, scale.Height);
        }

        [TestMethod]
        public void ScaleUpUsingWidthTest()
        {
            var quadrilateral = new Quadrilateral(500, 500);
            var scale = quadrilateral.Scale(100, 50);

            Assert.AreEqual(500, scale.Width);
            Assert.AreEqual(250, scale.Height);
        }

        [TestMethod]
        public void ScaleUpUsingHeightTest()
        {
            var quadrilateral = new Quadrilateral(500, 500);
            var scale = quadrilateral.Scale(50, 100);

            Assert.AreEqual(250, scale.Width);
            Assert.AreEqual(500, scale.Height);
        }

        [TestMethod]
        public void ScaleDownMultipleTest()
        {
            var quadrilateral = new Quadrilateral(500, 500);
            var scale = quadrilateral.Scale(851, 314);

            Assert.AreEqual(500, scale.Width);
            Assert.AreEqual(184, scale.Height);

            var quadrilateral2 = new Quadrilateral(300, 300);
            var scale2 = quadrilateral2.Scale(scale.Width, scale.Height);

            Assert.AreEqual(300, scale2.Width);
            Assert.AreEqual(110, scale2.Height);
        }

        [TestMethod]
        public void ScaleDownHops()
        {
            var quadrilateral = new Quadrilateral(500, 500);

            var scale1 = quadrilateral.Scale(618, 348);

            Assert.AreEqual(500, scale1.Width);
            Assert.AreEqual(282, scale1.Height);

            quadrilateral = new Quadrilateral(45, 45);
            scale1 = quadrilateral.Scale(scale1.Width, scale1.Height);

            Assert.AreEqual(45, scale1.Width);
            Assert.AreEqual(25, scale1.Height);
        }
    }
}
