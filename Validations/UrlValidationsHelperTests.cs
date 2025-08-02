using velocist.Validations;

namespace GenericTestProject.Validations {

    [TestClass()]
    public class UrlValidationsHelperTests : BaseConfigureTest {

        [TestMethod()]
        public void IsValidTest() {
            var result = UrlValidationsHelper.IsValid("http://www.google.es");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NotValidTest() {
            var result = UrlValidationsHelper.IsValid("www.google.es");
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionTest() {
            Assert.ThrowsException<VelocistArgumentNullException>(() => UrlValidationsHelper.IsValid(string.Empty));
        }

        [TestMethod()]
        public void NullValueTest() {
            Assert.ThrowsException<VelocistArgumentNullException>(() => UrlValidationsHelper.IsValid(null));
        }

        [TestMethod()]
        public void WhitespaceOnlyTest() {
            Assert.ThrowsException<VelocistArgumentNullException>(() => UrlValidationsHelper.IsValid("   "));
        }

        [TestMethod()]
        public void MissingProtocolTest() {
            var result = UrlValidationsHelper.IsValid("google.es");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InvalidProtocolTest() {
            var result = UrlValidationsHelper.IsValid("ftp://www.google.es");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void HttpsProtocolTest() {
            var result = UrlValidationsHelper.IsValid("https://www.google.es");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void MissingDomainTest() {
            var result = UrlValidationsHelper.IsValid("http://");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InvalidDomainTest() {
            var result = UrlValidationsHelper.IsValid("http://.google.es");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpacesInUrlTest() {
            var result = UrlValidationsHelper.IsValid("http://www.google.es/path with spaces");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpecialCharactersTest() {
            var result = UrlValidationsHelper.IsValid("http://www.google.es/path<test>");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidWithPathTest() {
            var result = UrlValidationsHelper.IsValid("http://www.google.es/search?q=test");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidWithPortTest() {
            var result = UrlValidationsHelper.IsValid("http://www.google.es:8080");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InvalidPortTest() {
            var result = UrlValidationsHelper.IsValid("http://www.google.es:99999");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LocalhostTest() {
            var result = UrlValidationsHelper.IsValid("http://localhost:3000");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IpAddressTest() {
            var result = UrlValidationsHelper.IsValid("http://192.168.1.1");
            Assert.IsTrue(result);
        }
    }
}