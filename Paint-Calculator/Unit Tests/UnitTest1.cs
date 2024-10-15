namespace Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFloorArea()
        {
            //Data taken from: https://www.britishhardwoods.co.uk/blog/measure-floor-area/

            const double expected = 22.32;
            double result = 0; //Will use RoomData function

            Assert.AreEqual(expected, result);
        }

        public void TestPaintQuantity()
        {
            //Data taken from: https://www.diy.com/ideas-advice/calculators/wall-painting-calculator
            //1 litre of paint per 10m^2
            //15x5 Wall

            const double expected = 7.5;
            double result = 0; //Will use RoomData function

            Assert.AreEqual(expected, result);
        }

        public void TestRoomVolume()
        {
            //Data taken from: https://www.popularmechanics.com/science/a41926325/how-to-measure-volume/

            const double expected = 1350;
            double result = 0; //Will use RoomData function

            Assert.AreEqual(expected, result);
        }
    }
}