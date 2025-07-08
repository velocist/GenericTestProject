using velocist.Services.Validations;
using System;

namespace GenericTestProject.Validations {

    [TestClass()]
    public class AddressValidationsHelperTests : BaseConfigureTest {

        [TestMethod()]
        public void IsValidTest() {
            var result = AddressValidationsHelper.IsValid("08320");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NotValidTest() {
            var result = AddressValidationsHelper.IsValid("320");
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionTest() {
            Assert.ThrowsException<ArgumentNullException>(() => AddressValidationsHelper.IsValid(string.Empty));
        }

        [TestMethod()]
        public void NullValueTest() {
            Assert.ThrowsException<ArgumentNullException>(() => AddressValidationsHelper.IsValid(null));
        }

        [TestMethod()]
        public void WhitespaceOnlyTest() {
            Assert.ThrowsException<ArgumentNullException>(() => AddressValidationsHelper.IsValid("   "));
        }

        [TestMethod()]
        public void TooShortTest() {
            var result = AddressValidationsHelper.IsValid("123");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TooLongTest() {
            var result = AddressValidationsHelper.IsValid("123456");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NonNumericTest() {
            var result = AddressValidationsHelper.IsValid("12A45");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpecialCharactersTest() {
            var result = AddressValidationsHelper.IsValid("12-45");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void LeadingZerosTest() {
            var result = AddressValidationsHelper.IsValid("00123");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidPostalCodeRangeTest() {
            // Códigos postales válidos en diferentes rangos
            var result1 = AddressValidationsHelper.IsValid("01001"); // Álava
            var result2 = AddressValidationsHelper.IsValid("28001"); // Madrid
            var result3 = AddressValidationsHelper.IsValid("08001"); // Barcelona
            var result4 = AddressValidationsHelper.IsValid("41001"); // Sevilla
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod()]
        public void InvalidPostalCodeRangeTest() {
            // Códigos postales fuera del rango válido (52xxx no existe)
            var result = AddressValidationsHelper.IsValid("52001");
            Assert.IsFalse(result);
        }
    }
}
