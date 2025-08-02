using Newtonsoft.Json.Linq;

namespace GenericTestProject.Json.Helpers {
    [TestClass]
    public class JsonValidationsHelperTests : BaseConfigureTest {
        [TestMethod]
        public void IsValidJson_ValidJson_ReturnsTrue() {
            string json = "{\"name\":\"John\",\"age\":30}";
            bool result = JsonValidationsHelper.IsValidJson(json);
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidJson_InvalidJson_ReturnsFalse() {
            string json = "{name:John,age:30";
            bool result = JsonValidationsHelper.IsValidJson(json);
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsValidJson_NullOrEmpty_ThrowsArgumentNullException() {
            JsonValidationsHelper.IsValidJson(null);
        }

        [TestMethod]
        public void ValidateAndCorrectJson_ValidJson_ReturnsSameJson() {
            string json = "{\"name\":\"John\"}";
            string result = JsonValidationsHelper.ValidateAndCorrectJson(json);
            LogResults(result);
            Assert.AreEqual(json, result);
        }

        [TestMethod]
        public void ValidateAndCorrectJson_InvalidJson_ReturnsNull() {
            string json = "{name:John,age:30";
            string result = JsonValidationsHelper.ValidateAndCorrectJson(json);
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateAndCorrectJson_NullOrEmpty_ThrowsArgumentNullException() {
            JsonValidationsHelper.ValidateAndCorrectJson("");
        }

        [TestMethod]
        public void ConvertJsonToString_ValidJToken_ReturnsString() {
            JToken token = JToken.Parse("\"test\"");
            string result = JsonValidationsHelper.ConvertJsonToString(token);
            LogResults(result);
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void ConvertJsonToString_EmptyJToken_ReturnsEmptyString() {
            JToken token = JToken.Parse("\"\"");
            string result = JsonValidationsHelper.ConvertJsonToString(token);
            LogResults(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertJsonToString_NullJToken_ThrowsArgumentNullException() {
            JsonValidationsHelper.ConvertJsonToString(null);
        }

        [TestMethod]
        public void ConvertJsonDatetimeValueToString_DefaultDate_ReturnsDateString() {
            JToken token = JToken.Parse("\"01/01/0001 00:00:00\"");
            string result = JsonValidationsHelper.ConvertJsonDatetimeValueToString(token);
            LogResults(result);
            Assert.AreEqual("01/01/0001 00:00:00", result);
        }

        [TestMethod]
        public void ConvertJsonDatetimeValueToString_NonDefaultDate_ReturnsDash() {
            JToken token = JToken.Parse("\"2024-01-01T12:00:00\"");
            string result = JsonValidationsHelper.ConvertJsonDatetimeValueToString(token);
            LogResults(result);
            Assert.AreEqual("-", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertJsonDatetimeValueToString_NullJToken_ThrowsArgumentNullException() {
            JsonValidationsHelper.ConvertJsonDatetimeValueToString(null);
        }
    }
}