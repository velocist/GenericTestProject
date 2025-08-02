using velocist.Services.HttpClientApis;

namespace GenericTestProject.HttpClientApis {
    [TestClass()]
    public class HttpClientApisOfTypeTests : BaseConfigureTest {

        private string urlApi = "https://jsonplaceholder.typicode.com/";
        private string posts = "posts";
        private string post = "posts/1";

        [TestMethod()]
        public void GetAllTest() {
            var api = new HttpClientApi<ResultObject>(urlApi);
            var result = (List<ResultObject>)api.CallApi(posts, HttpMethod.Get).Result;

            Console.WriteLine(result.Count());

            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod()]
        public void GetTest() {
            var api = new HttpClientApi<ResultObject>(urlApi);
            var result = (ResultObject)api.CallApi(post, HttpMethod.Get).Result;

            Console.WriteLine(result.Id);

            Assert.AreNotEqual(0, result.Id);
        }

        [TestMethod()]
        public void PostTest() {
            var api = new HttpClientApi<ResultObject>(urlApi);

            var obj = new ResultObject() {
                UserId = 1,
                Title = "Titulo nuevo",
                Body = "Prueba body"
            };

            var result = (ResultObject)api.CallApi(post, HttpMethod.Post, obj).Result;

            Console.WriteLine(result.Id);

            Assert.AreNotEqual(0, result.Id);
        }
    }
}