using WebApplication1;

namespace WebAppTests
{
    [TestClass]
    public class LiveNation_webapi_Data_Model_UnitTest
    {
        [TestMethod]
        public void BasicInputDataTest()
        {
            // Create data model:
            LiveNation_Webapi_Data_Model liveNation_Data = new LiveNation_Webapi_Data_Model();
            // Define a test input and output value:
            int[] expected_Array_Result = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            Range input = expected_Array_Result[0]..expected_Array_Result[expected_Array_Result.Length - 1];
            // Run the method under test:
            int[] actual_Array_Result = liveNation_Data.SetRange(liveNation_Data.X);

            // Verify the result:
            Assert.AreEqual(expected_Array_Result.Length, actual_Array_Result.Length);
        }
    }
}