namespace GenericTestProject.Json.Helpers {
    [TestClass]
    public class JsonConvertHelperTests : BaseConfigureTest {

        [DataTestMethod()]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void ConvertirAJson_SerializesObject<T>(T input) {
            var result = JsonConvertHelper.ConvertirAJson(input);
            LogResults(result);
            StringAssert.Contains(result, "\"Id\":1");
            //StringAssert.Contains(result, "\"Name\":\"Test\"");
        }

        [TestMethod]
        public void ConvertirAJson_Null_ReturnsNullString() {
            var json = JsonConvertHelper.ConvertirAJson(null);
            Assert.AreEqual("null", json);
        }

        [TestMethod]
        public void ConvertirAJson_NotSerializable_ReturnsNull() {
            // System.IO.Stream is not serializable by Newtonsoft.Json
            var json = JsonConvertHelper.ConvertirAJson(new MemoryStream());
            Assert.IsNull(json);
        }

        [TestMethod]
        public void ConvertJsonValueToObject_ObjectString_Works() {
            var json = "{\"Id\":1,\"Name\":\"Test\"}";
            var result = JsonConvertHelper.ConvertJsonValueToObject(json);
            StringAssert.Contains(result, "Id");
            StringAssert.Contains(result, "Test");
        }

        [TestMethod]
        public void ConvertJsonValueToObject_ArrayString_Works() {
            var json = "[{\"Id\":1,\"Name\":\"Test\"}]";
            var result = JsonConvertHelper.ConvertJsonValueToObject(json);
            StringAssert.Contains(result, "Id");
            StringAssert.Contains(result, "Test");
        }

        [TestMethod]
        public void ConvertJsonValueToObject_NestedEscapedJson_Works() {
            var json = "{\"data\":\"[{\\\"Id\\\":2,\\\"Name\\\":\\\"Nested\\\"}]\"}";
            var result = JsonConvertHelper.ConvertJsonValueToObject(json);
            StringAssert.Contains(result, "Nested");
        }

        [TestMethod]
        public void ConvertJsonValueToObject_InvalidJson_Throws() {
            var invalidJson = "{ invalid json }";
            Assert.ThrowsException<Newtonsoft.Json.JsonReaderException>(() =>
                JsonConvertHelper.ConvertJsonValueToObject(invalidJson));
        }

        [TestMethod]
        public void ConvertJsonValueToObject_NotObjectOrArray_Throws() {
            var notObjectOrArray = "12345";
            Assert.ThrowsException<ArgumentException>(() =>
                JsonConvertHelper.ConvertJsonValueToObject(notObjectOrArray));
        }
    }
}