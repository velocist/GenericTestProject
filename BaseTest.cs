using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace GenericTestProject {

    /// <summary>
    /// Bases class for configure tests.
    /// </summary>
    public class BaseConfigureTest {

        [TestInitialize]
        public void InitializeTest() {
            // Limpiar errores antes de cada test
            ErrorCollector.Clear();
        }

        [TestCleanup]
        public void EndTest() {

            var errores = ErrorCollector.GetErrors();
            foreach (var error in errores) {
                // Puedes loguear, asertar, etc.
                Console.WriteLine($"{error.ClassName}.{error.MethodName}: {error.Message}");
            }

            ErrorCollector.Clear();
        }

        [Table("TestObjectTable")]
        public class TestObject {

            [System.Text.Json.Serialization.JsonPropertyName("Id")]
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }

            [System.Text.Json.Serialization.JsonPropertyName("Name")]
            [Newtonsoft.Json.JsonProperty("name")]
            [Newtonsoft.Json.JsonIgnore]
            public string Name { get; set; }

            [System.Text.Json.Serialization.JsonIgnore]
            [System.Text.Json.Serialization.JsonPropertyName("Activo")]
            [Newtonsoft.Json.JsonProperty("activo")]
            public bool Activo { get; set; }
        }


        public static IEnumerable<object[]> GetTestCases() {
            yield return new object[] { new TestObject { Id = 1, Name = "Test", Activo = true } };
            yield return new object[] { new TestObject { Id = 1, Name = "Test", Activo = true }, new TestObject { Id = 2, Name = "Test2", Activo = false } };
        }

        /// <summary>
        /// Logs the results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public void LogResults<T>(T input) {
            if (input != null) {
                if (input.GetType() == typeof(string))
                    Console.WriteLine(input);
                else if (input.GetType() == typeof(JObject) || input.GetType() == typeof(JArray)) {
                    Console.WriteLine(input.ToString());
                } else if (input.GetType() == typeof(Dictionary<string, object>)) {
                    var stringItem = JsonHelper<Dictionary<string, object>>.Serialize(input);
                    Console.WriteLine(stringItem);
                } else if (input.GetType() == typeof(Dictionary<string, Type>)) {
                    var stringItem = JsonHelper<Dictionary<string, Type>>.Serialize(input);
                    Console.WriteLine(stringItem);
                } else if (input.GetType() == typeof(PropertyInfo[])) {
                    var stringItem = JsonHelper<PropertyInfo[]>.Serialize(input);
                    Console.WriteLine(stringItem);
                } else if (input.GetType() == typeof(List<string>)) {
                    var stringItem = JsonHelper<List<string>>.Serialize(input);
                    Console.WriteLine(stringItem);
                } else if (input.GetType() == typeof(IEnumerable<T>)) {
                    var stringItem = JsonHelper<IEnumerable<T>>.Serialize(input);
                    Console.WriteLine(stringItem);
                } else {
                    var stringItem = JsonHelper<T>.Serialize(input);
                    Console.WriteLine(stringItem);
                }
            } else {
                Console.WriteLine($"Resultado nulo");
            }
        }
    }
}