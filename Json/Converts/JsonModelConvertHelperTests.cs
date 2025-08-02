using System.Text.Json;

namespace GenericTestProject.Json.Converts {

    [TestClass]
    public class JsonModelConvertHelperTests : BaseConfigureTest {

        [TestMethod]
        public void CanConvert_ReturnsTrueForCorrectType() {
            var converter = new JsonModelConvertHelper<TestObject>();
            Assert.IsTrue(converter.CanConvert(typeof(TestObject)));
        }

        [TestMethod]
        public void CanConvert_ReturnsFalseForIncorrectType() {
            var converter = new JsonModelConvertHelper<TestObject>();
            Assert.IsFalse(converter.CanConvert(typeof(string)));
        }

        [TestMethod]
        public void Read_DeserializesSimpleObject() {
            var converter = new JsonModelConvertHelper<TestObject>();
            var json = "{\"Id\":42,\"Name\":\"TestName\"}";
            var options = new JsonSerializerOptions();
            options.Converters.Add(converter);
            var entity = JsonSerializer.Deserialize<TestObject>(json, options);
            Assert.AreEqual(42, entity.Id);
            Assert.AreEqual("TestName", entity.Name);
        }

        [TestMethod]
        public void Write_SerializesSimpleObject() {
            var converter = new JsonModelConvertHelper<TestObject>();
            var entity = new TestObject { Id = 7, Name = "WriteTest" };
            var options = new JsonSerializerOptions();
            options.Converters.Add(converter);
            var json = JsonSerializer.Serialize(entity, options);
            // El Write implementado serializa como un array con un objeto dentro
            StringAssert.Contains(json, "WriteTest");
            StringAssert.Contains(json, "7");
        }

        [TestMethod]
        public void Read_InvalidJson_ThrowsException() {
            var converter = new JsonModelConvertHelper<TestObject>();
            var options = new JsonSerializerOptions();
            options.Converters.Add(converter);
            var invalidJson = "{ invalid json }";
            Assert.ThrowsException<JsonException>(() =>
                JsonSerializer.Deserialize<TestObject>(invalidJson, options));
        }

        [TestMethod]
        public void Read_WrongType_ThrowsException() {
            var converter = new JsonModelConvertHelper<TestObject>();
            var options = new JsonSerializerOptions();
            options.Converters.Add(converter);
            var json = "{\"Id\":1,\"Name\":\"Test\"}";
            // Forzar el error usando otro tipo
            Assert.ThrowsException<InvalidCastException>(() =>
                JsonSerializer.Deserialize<string>(json, options));
        }
    }
}