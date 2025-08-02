using velocist.Validations;

namespace GenericTestProject.Validations {

    [TestClass()]
    public class CurrentAccountValidationsHelperTests : BaseConfigureTest {

        [TestMethod()]
        public void IsValidTest() {
            var result = CurrentAccountValidationsHelper.IsValid("21000418401234567891");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsValidLongTest() {
            var result = CurrentAccountValidationsHelper.IsValid(2100, 0418, 40, 1234567891);
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void IsValidStringTest() {
            var result = CurrentAccountValidationsHelper.IsValid("2100", "0418", "40", "1234567891");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionLongTest() {
            var result = CurrentAccountValidationsHelper.IsValid(0, 0418, 40, 1234567891);
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionStringTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid(null, "0418", "40", "1234567891"));
        }

        [TestMethod()]
        public void NullBankTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid(null, "0418", "40", "1234567891"));
        }

        [TestMethod()]
        public void NullOfficeTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("2100", null, "40", "1234567891"));
        }

        [TestMethod()]
        public void NullDCTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("2100", "0418", null, "1234567891"));
        }

        [TestMethod()]
        public void NullAccountTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("2100", "0418", "40", null));
        }

        [TestMethod()]
        public void EmptyBankTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("", "0418", "40", "1234567891"));
        }

        [TestMethod()]
        public void EmptyOfficeTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("2100", "", "40", "1234567891"));
        }

        [TestMethod()]
        public void EmptyDCTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("2100", "0418", "", "1234567891"));
        }

        [TestMethod()]
        public void EmptyAccountTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CurrentAccountValidationsHelper.IsValid("2100", "0418", "40", ""));
        }

        [TestMethod()]
        public void InvalidLength_ThrowsArgumentException() {
            // Menos de 20 dígitos
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100041840123456789"));
        }

        [TestMethod()]
        public void NonNumericBank_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("21A0", "0418", "40", "1234567891"));
        }

        [TestMethod()]
        public void NonNumericOffice_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100", "04A8", "40", "1234567891"));
        }

        [TestMethod()]
        public void NonNumericDC_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100", "0418", "4A", "1234567891"));
        }

        [TestMethod()]
        public void NonNumericAccount_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100", "0418", "40", "12345678A1"));
        }

        [TestMethod()]
        public void InvalidBankLength_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("210", "0418", "40", "1234567891"));
        }

        [TestMethod()]
        public void InvalidOfficeLength_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100", "418", "40", "1234567891"));
        }

        [TestMethod()]
        public void InvalidDCLength_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100", "0418", "4", "1234567891"));
        }

        [TestMethod()]
        public void InvalidAccountLength_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100", "0418", "40", "123456789"));
        }

        [TestMethod()]
        public void ValidAccountWithLeadingZerosTest() {
            var result = CurrentAccountValidationsHelper.IsValid("0001", "0001", "01", "0000000001");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InvalidDC_ThrowsArgumentException() {
            // Cuenta con dígito de control incorrecto
            var result = CurrentAccountValidationsHelper.IsValid("2100", "0418", "99", "1234567891");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ValidAccountStringFormatTest() {
            var result = CurrentAccountValidationsHelper.IsValid("21000418401234567891");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void InvalidAccountStringFormat_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("2100041840123456789")); // 19 dígitos
        }

        [TestMethod()]
        public void InvalidAccountStringFormatTooLong_ThrowsArgumentException() {
            Assert.ThrowsException<ArgumentException>(() =>
                CurrentAccountValidationsHelper.IsValid("210004184012345678912")); // 21 dígitos
        }
    }
}