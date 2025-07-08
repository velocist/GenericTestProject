using Newtonsoft.Json.Linq;
using velocist.Services.Json;

namespace GenericTestProject.Json {

    [TestClass()]
    public class JsonGenerateHelperTests : BaseConfigureTest {

        private readonly string simpleJson = "{\"id\":1,\"name\":\"Test\"}";
        private readonly string arrayJson = "[{\"id\":1,\"name\":\"Test\"}]";
        private readonly string schemaJson = "{\"type\":\"object\",\"properties\":{\"id\":{\"type\":\"integer\"},\"name\":{\"type\":\"string\"}}}";

        [TestMethod()]
        public void GenerateSchema_FromStringTest() {
            var objString = JsonGenerateHelper.GenerateSchema(simpleJson);
            LogResults(objString);
            Assert.IsNotNull(objString);
        }

        [TestMethod()]
        public void GenerateSchema_FromJsonTokenTest() {
            var objString = JsonGenerateHelper.GenerateSchema(simpleJson);
            LogResults(objString);
            Assert.IsNotNull(objString);
        }

        [TestMethod()]
        public void GenerateSchema_FromJsonObjectTest() {
            var jObj = JObject.Parse(simpleJson);
            var objString = JsonGenerateHelper.GenerateSchema(jObj);
            LogResults(objString);
            Assert.IsNotNull(objString);
        }

        [TestMethod()]
        public void GenerateSchema_FromJsonArrayTest() {
            var objString = JsonGenerateHelper.GenerateSchema(arrayJson);
            LogResults(objString);
            Assert.IsNotNull(objString);
        }

        [TestMethod()]
        public void GenerateSchema_FromString_Works() {
            var schema = JsonGenerateHelper.GenerateSchema(simpleJson);
            LogResults(schema);
            Assert.IsNotNull(schema);
            StringAssert.Contains(schema, "$schema");
        }

        [TestMethod()]
        public void GenerateSchema_FromJObject_Works() {
            var jObj = JObject.Parse(simpleJson);
            var schema = JsonGenerateHelper.GenerateSchema(jObj);
            LogResults(schema);
            Assert.IsNotNull(schema);
            StringAssert.Contains(schema, "$schema");
        }

        [TestMethod()]
        public void GenerateSchema_FromJArray_Works() {
            var jArr = JArray.Parse(arrayJson);
            var schema = JsonGenerateHelper.GenerateSchema(jArr);
            LogResults(schema);
            Assert.IsNotNull(schema);
            StringAssert.Contains(schema, "$schema");
        }

        [TestMethod()]
        public void GenerateSchema_FromJToken_Works() {
            var jToken = JToken.Parse(simpleJson);
            var schema = JsonGenerateHelper.GenerateSchema(jToken);
            LogResults(schema);
            Assert.IsNotNull(schema);
            StringAssert.Contains(schema, "$schema");
        }

        [TestMethod()]
        public void GenerateJsonEditorSchema_FromObjectTest() {
            var jsonObject = JObject.Parse(simpleJson);
            var objString = JsonGenerateHelper.GenerateJsonEditorSchema(jsonObject);
            LogResults(objString);
            Assert.IsNotNull(objString);
        }

        [TestMethod()]
        public void GenerateJsonEditorSchema_FromObjectWithoutTitleInJsonTest() {
            var jsonObject = JObject.Parse(simpleJson);
            var objString = JsonGenerateHelper.GenerateJsonEditorSchema(jsonObject);
            LogResults(objString);
            Assert.IsNotNull(objString);
        }

        [TestMethod()]
        public void GenerateJsonEditorSchema_Works() {
            var jObj = JObject.Parse("{\"id\":{\"type\":\"integer\"},\"name\":{\"type\":\"string\"}}");
            var schema = JsonGenerateHelper.GenerateJsonEditorSchema(jObj);
            LogResults(schema);
            Assert.IsNotNull(schema);
            StringAssert.Contains(schema, "$schema");
        }

        [TestMethod()]
        public void ValidarJsonConSchemaTest() {
            var jsonObject = JObject.Parse(simpleJson);
            var objString = JsonGenerateHelper.GenerateJsonEditorSchema(jsonObject);
            LogResults(objString);
            var result = JsonGenerateHelper.ValidarJsonConSchema(objString, simpleJson);
            LogResults(result);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ValidarJsonConSchema_ValidJson_ReturnsNoErrors() {
            var errors = JsonGenerateHelper.ValidarJsonConSchema(schemaJson, simpleJson);
            LogResults(errors);
            Assert.IsNotNull(errors);
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod()]
        public void ValidarJsonConSchema_InvalidJson_ReturnsErrors() {
            var errors = JsonGenerateHelper.ValidarJsonConSchema(schemaJson, "{\"id\":\"notInt\",\"name\":1}");
            LogResults(errors);
            Assert.IsTrue(errors.Count > 0);
        }

        [TestMethod()]
        public void DeserializeJsonAndClearPropertiesTest() {
            var result = JsonGenerateHelper.DeserializeJsonAndClearProperties(simpleJson);
            LogResults(result);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeserializeJsonAndClearProperties_Works() {
            var cleared = JsonGenerateHelper.DeserializeJsonAndClearProperties(simpleJson);
            LogResults(cleared);
            Assert.IsNotNull(cleared);
            Assert.AreEqual("", cleared["id"]?.ToString());
            Assert.AreEqual("", cleared["name"]?.ToString());
        }

        [TestMethod()]
        public void GetJsonPropertiesTest() {
            var result = JsonGenerateHelper.GetJsonProperties(simpleJson);
            LogResults(result);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetJsonProperties_Recursive_Works() {
            var json = "{\"a\":1,\"b\":{\"c\":2}}";
            var props = JsonGenerateHelper.GetJsonProperties(json, true);
            LogResults(props);
            CollectionAssert.Contains(props, "a");
            CollectionAssert.Contains(props, "b.c");
        }

        [TestMethod()]
        public void GetJsonProperties_NonRecursive_Works() {
            var json = "{\"a\":1,\"b\":{\"c\":2}}";
            var props = JsonGenerateHelper.GetJsonProperties(json, false);
            LogResults(props);
            CollectionAssert.Contains(props, "a");
            CollectionAssert.Contains(props, "b");
            CollectionAssert.DoesNotContain(props, "b.c");
        }

        [TestMethod()]
        public void GenerateSchema_InvalidJson_Throws() {
            var invalidJson = "{invalid json}";
            LogResults(invalidJson);
            Assert.ThrowsException<Newtonsoft.Json.JsonReaderException>(() =>
                JsonGenerateHelper.GenerateSchema(invalidJson));
        }
    }
}