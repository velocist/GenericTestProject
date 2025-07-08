using velocist.Services.Validations;
using System;

namespace GenericTestProject.Validations {

    [TestClass()]
    public class IdentificationNumberValidationsHelperTests: BaseConfigureTest {

        [TestMethod()]
        public void GetIdentificactionTypeTest() {
            var result = IdentificationNumberValidationsHelper.GetIdentificactionType("12345678Z");
            LogResults(result);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void IsValidTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("12345678Z");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NotValidTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("12345678Zs");
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionTest() {
            Assert.ThrowsException<ArgumentNullException>(() => IdentificationNumberValidationsHelper.IsValid(string.Empty));
        }

        [TestMethod()]
        public void NullValueTest() {
            Assert.ThrowsException<ArgumentNullException>(() => IdentificationNumberValidationsHelper.IsValid(null));
        }

        [TestMethod()]
        public void WhitespaceOnlyTest() {
            Assert.ThrowsException<ArgumentNullException>(() => IdentificationNumberValidationsHelper.IsValid("   "));
        }

        [TestMethod()]
        public void TooShortTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("1234567Z");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TooLongTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("123456789Z");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NonNumericPartTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("1234567AZ");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NonLetterCheckDigitTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("123456789");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpecialCharactersTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("1234567-Z");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpacesTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("1234567 Z");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LowercaseLetterTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("12345678z");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InvalidCheckDigitTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("12345678A");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidNIFTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("12345678Z");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidNIETest() {
            var result = IdentificationNumberValidationsHelper.IsValid("X1234567L");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidCIFTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("A12345678");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetIdentificactionTypeNIFTest() {
            var result = IdentificationNumberValidationsHelper.GetIdentificactionType("12345678Z");
            Assert.AreEqual("NIF", result);
        }

        [TestMethod()]
        public void GetIdentificactionTypeNIETest() {
            var result = IdentificationNumberValidationsHelper.GetIdentificactionType("X1234567L");
            Assert.AreEqual("NIE", result);
        }

        [TestMethod()]
        public void GetIdentificactionTypeCIFTest() {
            var result = IdentificationNumberValidationsHelper.GetIdentificactionType("A12345678");
            Assert.AreEqual("CIF", result);
        }

        [TestMethod()]
        public void GetIdentificactionTypeUnknownTest() {
            var result = IdentificationNumberValidationsHelper.GetIdentificactionType("I12345678");
            Assert.AreEqual("UNKNOWN", result);
        }

        [TestMethod()]
        public void TrimmedInputTest() {
            var result = IdentificationNumberValidationsHelper.IsValid(" 12345678Z ");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NormalizedInputTest() {
            var result = IdentificationNumberValidationsHelper.IsValid("12345678-Z");
            Assert.IsTrue(result);
        }
    }
}