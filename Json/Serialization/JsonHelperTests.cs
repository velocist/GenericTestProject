namespace GenericTestProject.Json.Serialization {
    public class JsonHelperTests : BaseConfigureTest {


        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_GeneralizedTest<T>(T input) {
            var json = JsonHelper<T>.Serialize(input);
            var result = JsonHelper<T>.DeserializeToObject(json);
            LogResults(result);
            Assert.AreEqual(input.ToString(), result.ToString()); // o haz comparación personalizada
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConverToObject_OptionsSerializeTrue_OptionsDeserializeTrueTest<T>(T input) {
            var result = JsonHelper<T>.ConverToObject(input, true, true, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConverToObject_OptionsSerializeFalse_OptionsDeserializeTrueTest<T>(T input) {
            var result = JsonHelper<T>.ConverToObject(input, false, true, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConverToObject_OptionsSerializeFalse_OptionsDeserializeFalseTest<T>(T input) {
            var result = JsonHelper<T>.ConverToObject(input, false, false, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConvertToList_OptionsSerializeFalse_OptionsDeserializeTrueTest<T>(T input) {
            var result = JsonHelper<T>.ConvertToList(input, false, true, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConvertToList_OptionsSerializeFalse_OptionsDeserializeFalseTest<T>(T input) {
            var result = JsonHelper<T>.ConvertToList(input, false, false, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConvertToList_OptionsSerializeTrue_OptionsDeserializeTrueTest<T>(T input) {
            var result = JsonHelper<T>.ConvertToList(input, true, true, true);
            LogResults(result);
        }
    }
}
