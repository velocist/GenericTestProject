namespace GenericTestProject.Formats {
    [TestClass()]
    public class FormatHelperTests : BaseConfigureTest {
        [TestMethod()]
        public void NormalizeStringTest_ValidString_ReturnsNormalized() {
            // Arrange
            var item = "Prue'ba";

            // Act
            var result = FormatHelper.NormalizeString(item);

            // Assert
            LogResults(result);
            Assert.AreEqual("Prueba", result);
        }

        [TestMethod()]
        public void NormalizeStringTest_NullString_ThrowsException() {
            // Arrange
            string nullString = null;

            // Act & Assert
            LogResults("Testing null string");
            Assert.ThrowsException<Exception>(() => FormatHelper.NormalizeString(nullString));
        }

        [TestMethod()]
        public void NormalizeStringTest_EmptyString_ThrowsException() {
            // Arrange
            var emptyString = "";

            // Act & Assert
            LogResults("Testing empty string");
            Assert.ThrowsException<Exception>(() => FormatHelper.NormalizeString(emptyString));
        }

        [TestMethod()]
        public void ConvertToBooleanTest_ValidTrueValues_ReturnsTrue() {
            // Arrange & Act & Assert
            var trueValues = new object[] { "true", "True", "TrUe", "1", 1 };

            foreach (var value in trueValues) {
                object resultOut;
                var result = FormatHelper.ConvertToBoolean(value, out resultOut);
                LogResults($"Value: {value}, Result: {result}, Output: {resultOut}");
                Assert.IsTrue(result);
            }
        }

        [TestMethod()]
        public void ConvertToBooleanTest_ValidFalseValues_ReturnsTrue() {
            // Arrange & Act & Assert
            var falseValues = new object[] { "false", "False", "FaLsE", "0", 0 };

            foreach (var value in falseValues) {
                object resultOut;
                var result = FormatHelper.ConvertToBoolean(value, out resultOut);
                LogResults($"Value: {value}, Result: {result}, Output: {resultOut}");
                Assert.IsTrue(result);
            }
        }

        [TestMethod()]
        public void ConvertToBooleanTest_InvalidValues_ReturnsFalse() {
            // Arrange & Act & Assert
            var invalidValues = new[] { "nein", "invalid", "yes", "no", null };

            foreach (var value in invalidValues) {
                object resultOut;
                var result = FormatHelper.ConvertToBoolean(value, out resultOut);
                LogResults($"Invalid value: {value}, Result: {result}, Output: {resultOut}");
                Assert.IsFalse(result);
                Assert.IsNull(resultOut);
            }
        }

        [TestMethod()]
        public void NullToStringTest_NullValue_ReturnsEmptyString() {
            // Arrange
            object nullValue = null;

            // Act
            var result = FormatHelper.NullToString(nullValue);

            // Assert
            LogResults(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod()]
        public void NullToStringTest_ValidString_ReturnsString() {
            // Arrange
            var validString = "Prueba string";

            // Act
            var result = FormatHelper.NullToString(validString);

            // Assert
            LogResults(result);
            Assert.AreEqual("Prueba string", result);
        }

        [TestMethod()]
        public void NullToStringTest_EmptyString_ReturnsEmptyString() {
            // Arrange
            var emptyString = "";

            // Act
            var result = FormatHelper.NullToString(emptyString);

            // Assert
            LogResults(result);
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod()]
        public void NullToIntegerTest_NullValue_ReturnsZero() {
            // Arrange
            object nullValue = null;

            // Act
            var result = FormatHelper.NullToInteger(nullValue);

            // Assert
            LogResults(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NullToIntegerTest_ValidInteger_ReturnsInteger() {
            // Arrange
            var validInteger = "5";

            // Act
            var result = FormatHelper.NullToInteger(validInteger);

            // Assert
            LogResults(result);
            Assert.AreEqual(5, result);
        }

        [TestMethod()]
        public void NullToIntegerTest_InvalidInteger_ReturnsZero() {
            // Arrange
            var invalidInteger = "not_a_number";

            // Act
            var result = FormatHelper.NullToInteger(invalidInteger);

            // Assert
            LogResults(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NullToDoubleTest_NullValue_ReturnsZero() {
            // Arrange
            object nullValue = null;

            // Act
            var result = FormatHelper.NullToDouble(nullValue);

            // Assert
            LogResults(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NullToDoubleTest_ValidDouble_ReturnsDouble() {
            // Arrange
            var validDouble = "0,5";

            // Act
            var result = FormatHelper.NullToDouble(validDouble);

            // Assert
            LogResults(result);
            Assert.AreEqual(0.5d, result);
        }

        [TestMethod()]
        public void NullToDoubleTest_InvalidDouble_ReturnsZero() {
            // Arrange
            var invalidDouble = "not_a_number";

            // Act
            var result = FormatHelper.NullToDouble(invalidDouble);

            // Assert
            LogResults(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NullToFloatTest_NullValue_ReturnsZero() {
            // Arrange
            object nullValue = null;

            // Act
            var result = FormatHelper.NullToFloat(nullValue);

            // Assert
            LogResults(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NullToFloatTest_ValidFloat_ReturnsFloat() {
            // Arrange
            var validFloat = "0,5";

            // Act
            var result = FormatHelper.NullToFloat(validFloat);

            // Assert
            LogResults(result);
            Assert.AreEqual(0.5f, result);
        }

        [TestMethod()]
        public void NullToFloatTest_InvalidFloat_ReturnsZero() {
            // Arrange
            var invalidFloat = "not_a_number";

            // Act
            var result = FormatHelper.NullToFloat(invalidFloat);

            // Assert
            LogResults(result);
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void NuloADateTimeNuloTest_NullValue_ReturnsNull() {
            // Arrange
            object nullValue = null;

            // Act
            var result = FormatHelper.NuloADateTimeNulo(nullValue);

            // Assert
            LogResults(result);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void NuloADateTimeNuloTest_ValidDate_ReturnsDateTime() {
            // Arrange
            var validDate = "15/06/2025";

            // Act
            var result = FormatHelper.NuloADateTimeNulo(validDate);

            // Assert
            LogResults(result);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(DateTime));
        }

        [TestMethod()]
        public void NuloADateTimeNuloTest_InvalidDate_ReturnsNull() {
            // Arrange
            var invalidDate = "invalid_date";

            // Act
            var result = FormatHelper.NuloADateTimeNulo(invalidDate);

            // Assert
            LogResults(result);
            Assert.IsNull(result);
        }
    }
}
