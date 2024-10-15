using Paint_Calculator;
using static Paint_Calculator.RoomData;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFloorArea()
        {
            //Data taken from: https://www.britishhardwoods.co.uk/blog/measure-floor-area/
            //Width * Length - 4.25 * 5.25

            const double expected = 22.31;
            Square newRoom = new Square(4.25, 5.25, 0);
            double result = Math.Round(newRoom.Area, 2);

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