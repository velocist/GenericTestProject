using velocist.Services.Files;

namespace GenericTestProject.Files {
    [TestClass]
    public class JsonFilesHelperTests : BaseConfigureTest {
        private string tempFilePath;

        [TestCleanup]
        public void Cleanup() {
            if (tempFilePath != null && File.Exists(tempFilePath))
                File.Delete(tempFilePath);
        }


        [TestMethod]
        public void WriteToJsonFile_And_ReadJsonFile_Generic_Works() {
            tempFilePath = Path.GetTempFileName();
            var obj = new TestObject { Id = 1, Name = "Test" };
            JsonFilesHelper.WriteToJsonFile(obj, tempFilePath);
            var result = JsonFilesHelper.ReadJsonFile<TestObject>(tempFilePath);
            Assert.AreEqual(obj.Id, result.Id);
            Assert.AreEqual(obj.Name, result.Name);
        }

        [TestMethod]
        public void WriteToJsonFile_And_ReadJsonFile_JToken_Works() {
            tempFilePath = Path.GetTempFileName();
            var obj = new TestObject { Id = 2, Name = "Other" };
            JsonFilesHelper.WriteToJsonFile(obj, tempFilePath);
            var token = JsonFilesHelper.ReadJsonFile(tempFilePath);
            Assert.AreEqual(2, (int)token["Id"]);
            Assert.AreEqual("Other", (string)token["Name"]);
        }

        [TestMethod]
        public void ReadJsonFile_Generic_FileNotFound_Throws() {
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "no_such_file_" + Path.GetRandomFileName() + ".json");
            Assert.ThrowsException<FileNotFoundException>(() =>
                JsonFilesHelper.ReadJsonFile<TestObject>(nonExistentPath));
        }

        [TestMethod]
        public void ReadJsonFile_JToken_FileNotFound_Throws() {
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "no_such_file_" + Path.GetRandomFileName() + ".json");
            Assert.ThrowsException<FileNotFoundException>(() =>
                JsonFilesHelper.ReadJsonFile(nonExistentPath));
        }

        [TestMethod]
        public void ReadJsonFile_Generic_InvalidJson_Throws() {
            tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "{ invalid json }");
            Assert.ThrowsException<Newtonsoft.Json.JsonReaderException>(() =>
                JsonFilesHelper.ReadJsonFile<TestObject>(tempFilePath));
        }

        [TestMethod]
        public void ReadJsonFile_JToken_InvalidJson_Throws() {
            tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, "{ invalid json }");
            Assert.ThrowsException<Newtonsoft.Json.JsonReaderException>(() =>
                JsonFilesHelper.ReadJsonFile(tempFilePath));
        }
    }
}