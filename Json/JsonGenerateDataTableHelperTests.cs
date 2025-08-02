using Newtonsoft.Json.Linq;

namespace GenericTestProject.Json {

    [TestClass()]
    public class JsonGenerateDataTableHelperTests : BaseConfigureTest {


        [TestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GenerateDataTableColumnsDefs_FromJsonObjectTest<T>(T input) where T : class {
            try {
                var stringInput = System.Text.Json.JsonSerializer.Serialize(input);
                var jsonObject = JObject.Parse(stringInput);
                var result = JsonGenerateDataTableHelper.GenerateDataTableColumnsDefs(jsonObject);
                LogResults(result);

                Assert.IsNotNull(result);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetDataTableColumnsList_FromJsonObjectTest<T>(T input) where T : class {
            try {
                var stringInput = System.Text.Json.JsonSerializer.Serialize(input);
                var jsonObject = JObject.Parse(stringInput);
                var result = JsonGenerateDataTableHelper.GenerateDataTableColumnsList(jsonObject);
                LogResults(result);

                Assert.IsNotNull(result);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }


        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GenerateDataTableColumnsDefs_FromObject_Works<T>(T input) where T : class {
            var result = JsonGenerateDataTableHelper.GenerateDataTableColumnsDefs<T>();
            LogResults(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GenerateDataTableColumnsDefs_FromObjectWithoutRemove_Works<T>(T input) where T : class {
            var result = JsonGenerateDataTableHelper.GenerateDataTableColumnsDefs<T>(false);
            LogResults(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GenerateDataTableColumnsList_Works<T>(T input) where T : class {
            var result = JsonGenerateDataTableHelper.GenerateDataTableColumnsList<T>();
            LogResults(result);
            Assert.IsNotNull(result);
        }
    }
}