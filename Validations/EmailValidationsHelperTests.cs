using velocist.Services.Validations;
using System;

namespace GenericTestProject.Validations {
    [TestClass()]
    public class EmailValidationsHelperTests : BaseConfigureTest{
        [TestMethod()]
        public void IsValidTest() {
            var result = EmailValidationsHelper.IsValid("prueba@gmail.com");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NotValidTest() {
            var result = EmailValidationsHelper.IsValid("prueba@gmail");
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionTest() {
            Assert.ThrowsException<ArgumentNullException>(() => EmailValidationsHelper.IsValid(string.Empty));
        }

        [TestMethod()]
        public void NullValueTest() {
            Assert.ThrowsException<ArgumentNullException>(() => EmailValidationsHelper.IsValid(null));
        }

        [TestMethod()]
        public void WhitespaceOnlyTest() {
            Assert.ThrowsException<ArgumentNullException>(() => EmailValidationsHelper.IsValid("   "));
        }

        [TestMethod()]
        public void MissingAtSymbolTest() {
            var result = EmailValidationsHelper.IsValid("pruebagmail.com");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void MultipleAtSymbolsTest() {
            var result = EmailValidationsHelper.IsValid("prueba@@gmail.com");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void MissingDomainTest() {
            var result = EmailValidationsHelper.IsValid("prueba@");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void MissingLocalPartTest() {
            var result = EmailValidationsHelper.IsValid("@gmail.com");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InvalidCharactersTest() {
            var result = EmailValidationsHelper.IsValid("prueba<test>@gmail.com");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpacesInEmailTest() {
            var result = EmailValidationsHelper.IsValid("prueba test@gmail.com");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void MultipleDotsTest() {
            var result = EmailValidationsHelper.IsValid("prueba..test@gmail.com");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidComplexEmailTest() {
            var result = EmailValidationsHelper.IsValid("prueba.test+tag@subdomain.gmail.com");
            Assert.IsTrue(result);
        }
    }
}