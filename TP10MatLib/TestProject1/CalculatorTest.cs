using CalcLib;

namespace TestProject1
{
    public class CalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdd()
        {
            Assert.That(3, Is.EqualTo(Calculator.Add(1,2)));
        }

        [Test]
        public void TestEdgeCase()
        {
            try
            {
                Calculator.Div(1,0);
                Assert.Fail(); // raises AssertionException
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
    }
}