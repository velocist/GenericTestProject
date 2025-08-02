using velocist.Utilities.Extensions;

namespace GenericTestProject.Extensions {

    [TestClass()]
    public class DateTimeExtensionsTests : BaseConfigureTest {

        [TestMethod()]
        public void CalcularInicioDiaTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularInicioDia();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularFinDiaTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularFinDia();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularInicioSemanaTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularInicioSemana();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularFinSemanaTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularFinSemana();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularInicioMesTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularInicioMes();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularFinMesTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularFinMes();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularInicioAñoTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularInicioAño();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularFinAñoTest() {
            try {
                var date = DateTime.Now;
                var result = date.CalcularFinAño();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularDiasHabilesEntreFechasTest() {
            try {
                var date = DateTime.Now;
                var date2 = DateTime.Now.AddDays(5);
                var result = date.CalcularDiasHabilesEntreFechas(date2);
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void CalcularTiempoEntreHorasTest() {
            try {
                var date = DateTime.Now;
                var date2 = DateTime.Now.AddDays(1);
                var result = date.CalcularTiempoEntreHoras(date2);
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void DevolverAñoTest() {
            try {
                var date = DateTime.Now;
                var result = date.DevolverAño();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

        [TestMethod()]
        public void DevolverMesTest() {
            try {
                var date = DateTime.Now;
                var result = date.DevolverMes();
                LogResults(result);

            } catch (Exception ex) {
                Console.Write(ex.Message);
                Assert.IsTrue(false);
            }
        }

    }
}
