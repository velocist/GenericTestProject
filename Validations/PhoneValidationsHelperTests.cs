using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.Services.Validations;
using System;

namespace GenericTestProject.Validations {

    [TestClass()]
    public class PhoneValidationsHelperTests : BaseConfigureTest{

        [TestMethod()]
        public void IsValidTest() {
            var result = PhoneValidationsHelper.IsValid("612345678");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NotValidTest() {
            var result = PhoneValidationsHelper.IsValid("6123456788");
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionTest() {
            Assert.ThrowsException<ArgumentNullException>(() => PhoneValidationsHelper.IsValid(string.Empty));
        }

        [TestMethod()]
        public void NullValueTest() {
            Assert.ThrowsException<ArgumentNullException>(() => PhoneValidationsHelper.IsValid(null));
        }

        [TestMethod()]
        public void WhitespaceOnlyTest() {
            Assert.ThrowsException<ArgumentNullException>(() => PhoneValidationsHelper.IsValid("   "));
        }

        [TestMethod()]
        public void TooShortTest() {
            var result = PhoneValidationsHelper.IsValid("61234567");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TooLongTest() {
            var result = PhoneValidationsHelper.IsValid("6123456789");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NonNumericTest() {
            var result = PhoneValidationsHelper.IsValid("61234567A");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpecialCharactersTest() {
            var result = PhoneValidationsHelper.IsValid("612-345-678");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpacesTest() {
            var result = PhoneValidationsHelper.IsValid("612 345 678");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LeadingZerosTest() {
            var result = PhoneValidationsHelper.IsValid("061234567");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void InvalidPrefixTest() {
            var result = PhoneValidationsHelper.IsValid("512345678");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void AllSameDigitsTest() {
            var result = PhoneValidationsHelper.IsValid("666666666");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InternationalFormatTest() {
            var result = PhoneValidationsHelper.IsValid("+34612345678");
            Assert.IsFalse(result);
        }
    }
}