namespace GenericTestProject.Reflection {
    [TestClass]
    public sealed class ReflectionTests : BaseConfigureTest {


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
            var result = JsonHelper<List<T>>.ConvertToList(input, false, true, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConvertToList_OptionsSerializeFalse_OptionsDeserializeFalseTest<T>(T input) {
            var result = JsonHelper<List<T>>.ConvertToList(input, false, false, true);
            LogResults(result);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void JsonHelper_ConvertToList_OptionsSerializeTrue_OptionsDeserializeTrueTest<T>(T input) {
            var result = JsonHelper<T>.ConvertToList(input, true, true, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetValues_ExcludeIgnoreTrueTest<T>(T input) {
            var result = input.GetValues(true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetValues_ExcludeIgnoreFalseTest<T>(T input) {
            var result = input.GetValues(false);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetValuesDictionary_ExcludeIgnoreTrue_JsonAttributeTrueTest<T>(T input) {
            var result = input.GetValuesDictionary(true, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetValuesDictionary_ExcludeIgnoreFalse_JsonAttributeTrueTest<T>(T input) {
            var result = input.GetValuesDictionary(false, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetValuesDictionary_ExcludeIgnoreFalse_JsonAttributeFalseTest<T>(T input) {
            var result = input.GetValuesDictionary(false, false);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetPropertiesDictionary_ExcludeIgnoreTrue_JsonAttributeTrueTest<T>(T input) {
            var result = input.GetPropertiesDictionary(true, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetPropertiesDictionary_ExcludeIgnoreFalse_JsonAttributeTrueTest<T>(T input) {
            var result = input.GetPropertiesDictionary(false, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetPropertiesDictionary_ExcludeIgnoreFalse_JsonAttributeFalseTest<T>(T input) {
            var result = input.GetPropertiesDictionary(false, false);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetNameProperties_ExcludeIgnoreTrue_JsonAttributeTrueTest<T>(T input) {
            var result = input.GetProperties(true, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetNameProperties_ExcludeIgnoreFalse_JsonAttributeTrueTest<T>(T input) {
            var result = input.GetProperties(false, true);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetNameProperties_ExcludeIgnoreFalse_JsonAttributeFalseTest<T>(T input) {
            var result = input.GetProperties(false, false);
            LogResults(result);
        }

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void GetTableAttributeNameTest<T>(T input) {
            var result = input.GetTableAttributeName();
            LogResults(result);
        }


    }

}