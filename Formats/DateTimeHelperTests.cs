using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.Services.Formats;

namespace GenericTestProject.Formats {

    [TestClass()]
    public class DateTimeHelperTests : BaseConfigureTest {

        [TestMethod()]
        public void EsFechaTest_ValidDate_ReturnsTrue() {
            // Arrange
            var validDate = "15/06/2025";
            
            // Act
            var result = DateTimeHelper.EsFecha(validDate);
            
            // Assert
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void EsFechaTest_InvalidDate_ReturnsFalse() {
            // Arrange
            var invalidDate = "32/13/2025";
            
            // Act
            var result = DateTimeHelper.EsFecha(invalidDate);
            
            // Assert
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void EsFechaTest_NullDate_ReturnsFalse() {
            // Arrange
            string nullDate = null;
            
            // Act
            var result = DateTimeHelper.EsFecha(nullDate);
            
            // Assert
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void EsFechaTest_EmptyDate_ReturnsFalse() {
            // Arrange
            var emptyDate = "";
            
            // Act
            var result = DateTimeHelper.EsFecha(emptyDate);
            
            // Assert
            LogResults(result);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void EsFechaValidaTest_ValidDate_ReturnsTrue() {
            // Arrange
            var validDate = "15/06/2025";
            
            // Act
            var result = DateTimeHelper.EsFechaValida(validDate);
            
            // Assert
            LogResults(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void EsFechaValidaTest_InvalidDate_ThrowsException() {
            // Arrange
            var invalidDate = "06/15/2025"; // Formato incorrecto
            
            // Act & Assert
            LogResults($"Testing invalid date: {invalidDate}");
            Assert.ThrowsException<Exception>(() => DateTimeHelper.EsFechaValida(invalidDate));
        }

        [TestMethod()]
        public void EsFechaValidaTest_NullValue_ThrowsException() {
            // Arrange
            object nullValue = null;
            
            // Act & Assert
            LogResults("Testing null value");
            Assert.ThrowsException<Exception>(() => DateTimeHelper.EsFechaValida(nullValue));
        }

        [TestMethod()]
        public void DevolverNombreMesTest_ValidMonths_ReturnsCorrectNames() {
            // Arrange & Act & Assert
            var testCases = new[] {
                (1, "Enero"),
                (2, "Febrero"),
                (3, "Marzo"),
                (4, "Abril"),
                (5, "Mayo"),
                (6, "Junio"),
                (7, "Julio"),
                (8, "Agosto"),
                (9, "Septiembre"),
                (10, "Octubre"),
                (11, "Noviembre"),
                (12, "Diciembre")
            };

            foreach (var (month, expectedName) in testCases) {
                var result = DateTimeHelper.DevolverNombreMes(month);
                LogResults($"Month {month}: {result}");
                Assert.AreEqual(expectedName, result);
            }
        }

        [TestMethod()]
        public void DevolverNombreMesTest_InvalidMonth_ReturnsEmptyString() {
            // Arrange
            var invalidMonths = new[] { 0, 13, -1, 99 };
            
            // Act & Assert
            foreach (var month in invalidMonths) {
                var result = DateTimeHelper.DevolverNombreMes(month);
                LogResults($"Invalid month {month}: {result}");
                Assert.AreEqual("", result);
            }
        }

        [TestMethod()]
        public void GetMonthTest_ValidMonths_ReturnsCorrectAbbreviations() {
            // Arrange & Act & Assert
            var testCases = new[] {
                (1, "JAN"),
                (2, "FEB"),
                (3, "MAR"),
                (4, "APR"),
                (5, "MAY"),
                (6, "JUN"),
                (7, "JUL"),
                (8, "AUG"),
                (9, "SEP"),
                (10, "OCT"),
                (11, "NOV"),
                (12, "DEC")
            };

            foreach (var (month, expectedAbbr) in testCases) {
                var result = DateTimeHelper.GetMonth(month);
                LogResults($"Month {month}: {result}");
                Assert.AreEqual(expectedAbbr, result);
            }
        }

        [TestMethod()]
        public void GetMonthTest_InvalidMonth_ReturnsEmptyString() {
            // Arrange
            var invalidMonths = new[] { 0, 13, -1, 99 };
            
            // Act & Assert
            foreach (var month in invalidMonths) {
                var result = DateTimeHelper.GetMonth(month);
                LogResults($"Invalid month {month}: {result}");
                Assert.AreEqual("", result);
            }
        }

        [TestMethod()]
        public void GetMonthTest_ValidAbbreviations_ReturnsCorrectNumbers() {
            // Arrange & Act & Assert
            var testCases = new[] {
                ("JAN", "01"),
                ("FEB", "02"),
                ("MAR", "03"),
                ("APR", "04"),
                ("MAY", "05"),
                ("JUN", "06"),
                ("JUL", "07"),
                ("AUG", "08"),
                ("SEP", "09"),
                ("OCT", "10"),
                ("NOV", "11"),
                ("DEC", "12")
            };

            foreach (var (abbr, expectedNumber) in testCases) {
                var result = DateTimeHelper.GetMonth(abbr);
                LogResults($"Abbreviation {abbr}: {result}");
                Assert.AreEqual(expectedNumber, result);
            }
        }

        [TestMethod()]
        public void GetMonthTest_InvalidAbbreviation_ReturnsNull() {
            // Arrange
            var invalidAbbrs = new[] { "INV", "XYZ", "", null };
            
            // Act & Assert
            foreach (var abbr in invalidAbbrs) {
                var result = DateTimeHelper.GetMonth(abbr);
                LogResults($"Invalid abbreviation {abbr}: {result}");
                Assert.IsNull(result);
            }
        }

        [TestMethod()]
        public void DiccionarioMesesTest_ReturnsCorrectDictionary() {
            // Act
            var result = DateTimeHelper.DiccionarioMeses();
            
            // Assert
            LogResults($"Dictionary count: {result.Count}");
            Assert.AreEqual(12, result.Count);
            Assert.AreEqual("Enero", result[1]);
            Assert.AreEqual("Diciembre", result[12]);
        }

        [TestMethod()]
        public void ListaMesesTest_ReturnsCorrectList() {
            // Act
            var result = DateTimeHelper.ListaMeses();
            
            // Assert
            LogResults($"List count: {result.Count}");
            Assert.AreEqual(12, result.Count);
            Assert.AreEqual("Enero", result[0]);
            Assert.AreEqual("Diciembre", result[11]);
        }

        [TestMethod()]
        public void ListaSemanasTest_ReturnsCorrectList() {
            // Act
            var result = DateTimeHelper.ListaSemanas();
            
            // Assert
            LogResults($"Weeks list count: {result.Count}");
            Assert.AreEqual(52, result.Count);
            Assert.AreEqual("Sem. 1", result[0]);
            Assert.AreEqual("Sem. 52", result[51]);
        }
    }
}
