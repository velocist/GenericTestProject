using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using velocist.Services.Json.Extensions;

namespace GenericTestProject.Json.Extensions {

    [TestClass()]
    public class JsonManipulateHelperExtensionsTests : BaseConfigureTest {

        private JObject baseJson;
        private readonly string simpleJson = "{\"id\":1,\"name\":\"Test\",\"nested\":{\"id\":2,\"name\":\"Nested\"}}";
        private readonly string arrayJson = "[{\"id\":1,\"name\":\"A\"},{\"id\":2,\"name\":\"B\"}]";

        [TestInitialize]
        public void Setup() {
            baseJson = JObject.Parse(simpleJson);
        }

        #region ReplaceTokenByPropertyName Tests

        [TestMethod]
        public void ReplaceTokenByPropertyName_ReemplazaPropiedadExistente() {
            var newValue = JToken.Parse("{\"id\":3,\"name\":\"NewNested\"}");
            var result = baseJson.ReplaceTokenByPropertyName("nested", newValue);

            Assert.IsNotNull(result);
            var nestedObj = result["nested"];
            Assert.AreEqual(3, (int)nestedObj["id"]);
            Assert.AreEqual("NewNested", (string)nestedObj["name"]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReplaceTokenByPropertyName_ConArray_LanzaExcepcion() {
            var arrayToken = JToken.Parse(arrayJson);
            var newValue = JToken.Parse("{\"test\":\"value\"}");
            arrayToken.ReplaceTokenByPropertyName("test", newValue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReplaceTokenByPropertyName_PropiedadNula_LanzaExcepcion() {
            var newValue = JToken.Parse("{\"test\":\"value\"}");
            baseJson.ReplaceTokenByPropertyName(null, newValue);
        }

        #endregion

        #region ReplaceTokenByPath Tests

        [TestMethod]
        public void ReplaceTokenByPath_ReemplazaTokenCorrecto() {
            var newToken = JToken.FromObject(new { id = 3, name = "Updated" });
            var result = baseJson.ReplaceTokenByPath("nested", newToken);

            Assert.IsNotNull(result);
            Assert.AreEqual(3, (int)result.SelectToken("nested.id"));
            Assert.AreEqual("Updated", (string)result.SelectToken("nested.name"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ReplaceTokenByPath_PathInexistente_LanzaExcepcion() {
            var newToken = JToken.FromObject(new { test = "value" });
            baseJson.ReplaceTokenByPath("noexiste", newToken);
        }

        #endregion

        #region AddOrUpdateTokenByPath Tests

        [TestMethod]
        public void AddOrUpdateTokenByPath_AgregaNuevoToken() {
            var newObject = JToken.FromObject(new { value = "test" });
            var result = baseJson.AddOrUpdateTokenByPath("", "newProp", newObject);

            LogResults(result);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result["newProp"]);
            Assert.AreEqual("test", (string)result["newProp"]["value"]);
        }

        [TestMethod]
        public void AddOrUpdateTokenByPath_ActualizaTokenExistente() {
            var newObject = JToken.FromObject(new { id = 3, name = "Updated" });
            var result = baseJson.AddOrUpdateTokenByPath("", "nested", newObject);
            
            LogResults(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(3, (int)result["nested"]["id"]);
            Assert.AreEqual("Updated", (string)result["nested"]["name"]);
        }

        [TestMethod]
        public void AddOrUpdateTokenByPath_AgregaEnPath() {
            var newObject = JToken.FromObject(new { value = "test" });
            var result = baseJson.AddOrUpdateTokenByPath("nested", "newProp", newObject);

            LogResults(result);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.SelectToken("nested.newProp"));
            Assert.AreEqual("test", (string)result.SelectToken("nested.newProp.value"));
        }

        #endregion

        #region AñadirPropiedadPorNombrePropiedad Tests

        [TestMethod]
        public void AñadirPropiedadPorNombrePropiedad_AgregaAlFinal() {
            var result = baseJson.AñadirPropiedadPorNombrePropiedad("newProp", "value", JPosition.Last);

            LogResults(result);
            Assert.IsNotNull(result);
            Assert.AreEqual("value", (string)result["newProp"]);
        }

        [TestMethod]
        public void AñadirPropiedadPorNombrePropiedad_AgregaAlPrincipio() {
            var result = baseJson.AñadirPropiedadPorNombrePropiedad("newProp", "value", JPosition.First);

            LogResults(result);
            Assert.IsNotNull(result);
            Assert.AreEqual("value", (string)result["newProp"]);
            // Verificar que sea la primera propiedad
            Assert.AreEqual("newProp", result.First.Path);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AñadirPropiedadPorNombrePropiedad_PropiedadExistente_LanzaExcepcion() {
            baseJson.AñadirPropiedadPorNombrePropiedad("name", "value");
        }

        #endregion

        #region DeleteTokenByPropertyName Tests

        [TestMethod]
        public void DeleteTokenByPropertyName_EliminaPropiedadExistente() {
            var result = baseJson.DeleteTokenByPropertyName("name");

            LogResults(result);
            Assert.IsNotNull(result);
            Assert.IsNull(result["name"]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteTokenByPropertyName_PropiedadInexistente_LanzaExcepcion() {
            baseJson.DeleteTokenByPropertyName("noexiste");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteTokenByPropertyName_ConArray_LanzaExcepcion() {
            var arrayToken = JToken.Parse(arrayJson);
            arrayToken.DeleteTokenByPropertyName("name");
        }

        #endregion
    }
}