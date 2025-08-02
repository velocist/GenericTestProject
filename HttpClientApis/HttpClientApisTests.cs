using Newtonsoft.Json.Linq;
using velocist.Services.HttpClientApis;

namespace GenericTestProject.HttpClientApis {

    [TestClass()]
    public class HttpClientApisTests : BaseConfigureTest {

        private string urlApi = "https://jsonplaceholder.typicode.com/";
        private string posts = "posts";
        private string post = "posts/1";

        [TestMethod()]
        public void HttpClientApiTest() {
            var api = new HttpClientApi(urlApi);
            Console.WriteLine(api);

            Assert.IsNotNull(api);
        }

        [TestMethod()]
        public void GetAllTest() {
            var api = new HttpClientApi(urlApi);

            var result = api.CallApi(posts, HttpMethod.Get).Result;

            var resultArray = JArray.Parse(result.ToString());
            Console.WriteLine(resultArray.Count());

            Assert.AreNotEqual(0, resultArray.Count());
        }

        [TestMethod()]
        public void GetTest() {
            var api = new HttpClientApi(urlApi);

            var result = api.CallApi(post, HttpMethod.Get).Result;

            var resultObject = JsonHelper<ResultObject>.DeserializeToObject(result.ToString());
            Console.WriteLine(resultObject.Id);

            Assert.AreNotEqual(0, resultObject.Id);
        }

        [TestMethod()]
        public void PostTest() {
            var api = new HttpClientApi(urlApi);

            var obj = new ResultObject() {
                UserId = 1,
                Title = "Tiutlo nuevo json",
                Body = "Prueba body json"
            };

            var result = api.CallApi(post, HttpMethod.Post, obj).Result;

            var resultObject = JsonHelper<ResultObject>.DeserializeToObject(result.ToString());
            Console.WriteLine(resultObject.Id);

            Assert.AreNotEqual(0, resultObject.Id);
        }

    }

    public class ResultObject() {

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}