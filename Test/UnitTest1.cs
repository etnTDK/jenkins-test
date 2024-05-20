namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void UnitTest()
        {
            var i = 0;
            var y = 1;
            var expect = 1;
            var result = i + y;
            Assert.Equal(expect, result);

        }
    }
}