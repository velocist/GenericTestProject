using velocist.Validations;

namespace GenericTestProject.Validations {

    [TestClass()]
    public class CreditCardValidationsHelperTests : BaseConfigureTest {
        [TestMethod()]
        public void IsValidTest() {
            var result = CreditCardValidationsHelper.IsValid("4111 1111 1111 1111");
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void NotValidTest() {
            var result = CreditCardValidationsHelper.IsValid("4111 1111 1111");
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ArgumentNullExceptionTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CreditCardValidationsHelper.IsValid(string.Empty));
        }

        [TestMethod()]
        public void NullValueTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CreditCardValidationsHelper.IsValid(null));
        }

        [TestMethod()]
        public void WhitespaceOnlyTest() {
            Assert.ThrowsException<ArgumentNullException>(() => CreditCardValidationsHelper.IsValid("   "));
        }

        [TestMethod()]
        public void TooShortTest() {
            var result = CreditCardValidationsHelper.IsValid("4111 1111 111");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TooLongTest() {
            var result = CreditCardValidationsHelper.IsValid("4111 1111 1111 1111 1");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NonNumericTest() {
            var result = CreditCardValidationsHelper.IsValid("4111 1111 1111 111A");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SpecialCharactersTest() {
            var result = CreditCardValidationsHelper.IsValid("4111-1111-1111-1111");
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void NoSpacesTest() {
            var result = CreditCardValidationsHelper.IsValid("4111111111111111");
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void MultipleSpacesTest() {
            var result = CreditCardValidationsHelper.IsValid("4111  1111  1111  1111");
            Assert.IsFalse(result);
        }
    }
}

