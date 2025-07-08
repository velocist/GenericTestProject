using Microsoft.VisualStudio.TestTools.UnitTesting;
using velocist.Services.Exceptions;

namespace GenericTestProject.Exceptions {

	[TestClass()]
	public class VelocistExceptionsHelperTests {

		[TestMethod]
		public void VelocistExceptionWithClassNameTest() {
			try {
				throw new VelocistException();
			} catch (VelocistException ex) {
				Console.Write(ex.Message);
				Assert.IsTrue(true);
			} catch (Exception ex) {
				Console.Write(ex.Message);
				Assert.IsTrue(false);
			}
		}

		[TestMethod]
		public void VelocistExceptionWithMessageTest() {
			try {
				throw new VelocistException("Exception message test");
			} catch (VelocistException ex) {
				Console.Write(ex.Message);
				Assert.IsTrue(true);
			} catch (Exception ex) {
				Console.Write(ex.Message);
				Assert.IsTrue(false);
			}
		}
	}
}
