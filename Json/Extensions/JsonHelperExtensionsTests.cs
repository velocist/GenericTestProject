using Newtonsoft.Json.Linq;
using velocist.Services.Json.Extensions;

namespace GenericTestProject.Json.Extensions {

    [TestClass()]
    public class JsonHelperExtensionsTests : BaseConfigureTest {

        private readonly string simpleJson = "{\"id\":1,\"name\":\"Test\",\"nested\":{\"id\":2,\"name\":\"Nested\"}}";
        private readonly string arrayJson = "[{\"id\":1,\"name\":\"A\"},{\"id\":2,\"name\":\"B\"}]";
        private readonly string _propertyName = "Name";
        private readonly string _propertyNameValue = "Test";

        [TestMethod()]
        public void ObtenerTokenPorNombrePropiedadYValorTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);
                var objString = jsonToken.ObtenerTokenPorNombrePropiedadYValor(_propertyName, _propertyNameValue);
                LogResults(objString);

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void ObtenerValorTokenPorNombrePropiedadTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);
                var objString = jsonToken.ObtenerValorTokenPorNombrePropiedad(_propertyName);
                LogResults(objString);

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void ListarTokensPorNombrePropiedadTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);
                var objString = jsonToken.ListarTokensPorNombrePropiedad(_propertyName);

                foreach (var item in objString)
                    Console.WriteLine($"Key: {item.Key.ToString()} Value: {item.Value.ToString()}");

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void ListarTokensPorNombrePropiedadYValorTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);
                var objString = jsonToken.ListarTokensPorNombrePropiedadYValor(_propertyName, _propertyNameValue, true);

                foreach (var item in objString)
                    Console.WriteLine($"Key: {item.Key.ToString()} Value: {item.Value.ToString()}");

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void ObtenerTokenPorPathTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);
                var objString = jsonToken.ObtenerTokenPorPath($"$.{_propertyName}");

                Console.WriteLine($"{objString.ToString()}");

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void FindPathsAndValuesByPropertyNameAndValueTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);

                var objString = jsonToken.FindPathsAndValuesByPropertyNameAndValue(_propertyName, _propertyNameValue);

                foreach (var item in objString)
                    Console.WriteLine($"Key: {item.Key.ToString()} Value: {item.Value.ToString()}");

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void FilterPropertiesTest() {
            try {
                var jsonToken = JArray.Parse(arrayJson);
                var objString = jsonToken.FilterProperties(new List<string>() { _propertyName });

                foreach (var item in objString)
                    Console.WriteLine($"Property: {item.ToString()}");

                Assert.IsTrue(true);
            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void ObtenerTokenPorNombrePropiedadYValor_DevuelveTokenCorrecto() {
            var token = JToken.Parse(simpleJson);
            var result = token.ObtenerTokenPorNombrePropiedadYValor("name", "Nested");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, (int)result["id"]);
        }

        [TestMethod]
        public void ObtenerTokenPorNombrePropiedadYValor_NoEncuentraValor_DevuelveNull() {
            var token = JToken.Parse(simpleJson);
            var result = token.ObtenerTokenPorNombrePropiedadYValor("name", "NoExiste");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ObtenerValorTokenPorNombrePropiedad_DevuelveValorCorrecto() {
            var token = JToken.Parse(simpleJson);
            var result = token.ObtenerValorTokenPorNombrePropiedad("name");
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", (string)result);
        }

        [TestMethod]
        public void ObtenerValorTokenPorNombrePropiedad_NoEncuentra_DevuelveNull() {
            var token = JToken.Parse(simpleJson);
            var result = token.ObtenerValorTokenPorNombrePropiedad("noexiste");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ListarTokensPorNombrePropiedad_DevuelveTodosLosTokens() {
            var token = JToken.Parse(simpleJson);
            var dict = token.ListarTokensPorNombrePropiedad("id");
            Assert.AreEqual(2, dict.Count);
            Assert.IsTrue(dict.Values.All(v => v.Type == JTokenType.Integer));
        }

        [TestMethod]
        public void ListarTokensPorNombrePropiedadYValor_DevuelveTokensCorrectos() {
            var token = JToken.Parse(simpleJson);
            var dict = token.ListarTokensPorNombrePropiedadYValor("name", "Nested", false);
            Assert.AreEqual(1, dict.Count);
            Assert.AreEqual("Nested", dict?.First().Value.ToString());
        }

        [TestMethod]
        public void ListarTokensPorNombrePropiedadYValor_NoEncuentra_DevuelveVacio() {
            var token = JToken.Parse(simpleJson);
            var dict = token.ListarTokensPorNombrePropiedadYValor("name", "NoExiste", false);
            Assert.AreEqual(0, dict.Count);
        }

        [TestMethod]
        public void ObtenerTokenPorPath_DevuelveTokenCorrecto() {
            var token = JToken.Parse(simpleJson);
            var result = token.ObtenerTokenPorPath("nested.id");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, (int)result);
        }

        [TestMethod]
        public void ObtenerTokenPorPath_PathInvalido_DevuelveNull() {
            var token = JToken.Parse(simpleJson);
            var result = token.ObtenerTokenPorPath("no.existe");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindPathsAndValuesByPropertyNameAndValue_DevuelvePathsYValores() {
            var token = JToken.Parse(simpleJson);
            var dict = token.FindPathsAndValuesByPropertyNameAndValue("name", "Test");
            Assert.IsTrue(dict.Any());
            Assert.AreEqual("Test", dict?.First().Value.ToString());
        }

        [TestMethod]
        public void FindPathsAndValuesByPropertyNameAndValue_NoEncuentra_DevuelveVacio() {
            var token = JToken.Parse(simpleJson);
            var dict = token.FindPathsAndValuesByPropertyNameAndValue("name", "NoExiste");
            Assert.AreEqual(0, dict.Count);
        }

        [TestMethod]
        public void FilterProperties_DevuelveSoloPropiedadesFiltradas() {
            var arr = JArray.Parse(arrayJson);
            var filtered = arr.FilterProperties(new List<string> { "id" });
            Assert.AreEqual(2, filtered.Count);
            Assert.AreEqual(1, (int)filtered[0]["id"]);
            Assert.IsTrue(filtered[0]["id"] != null);
            Assert.IsTrue(filtered[0]["id"].Type == JTokenType.Integer);
            Assert.IsTrue(filtered[0]["name"] == null || filtered[0]["name"].Type == JTokenType.Null);
        }

        [TestMethod]
        public void FilterProperties_PropiedadNoExiste_DevuelveStringVacio() {
            var arr = JArray.Parse(arrayJson);
            var filtered = arr.FilterProperties(new List<string> { "noexiste" });
            Assert.AreEqual(2, filtered.Count);
            Assert.AreEqual(string.Empty, (string)filtered[0]["noexiste"]);
        }
    }
}