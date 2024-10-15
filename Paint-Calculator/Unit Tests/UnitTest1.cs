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
            double result = newRoom.Area;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestPaintQuantity()
        {
            //Data taken from: https://www.diy.com/ideas-advice/calculators/wall-painting-calculator
            //1 litre of paint per 10m^2
            //15x5 Wall - All 4 walls

            const double expected = 30;
            Square newRoom = new Square(15, 15, 5);
            double result = newRoom.GetPaintRequirement();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRoomVolume()
        {
            //Data taken from: https://www.popularmechanics.com/science/a41926325/how-to-measure-volume/
            //Width * Length * Height - 15*10*9

            const double expected = 1350;
            Square newRoom = new Square(15, 10, 9);
            double result = newRoom.Volume;

            Assert.AreEqual(expected, result);
        }
    }
}