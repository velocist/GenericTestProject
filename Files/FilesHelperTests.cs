using System.Text;
using Microsoft.AspNetCore.Http;
using velocist.Services.Files;

namespace GenericTestProject.Files {
    [TestClass]
    public class FilesHelperTests {
        private string tempFilePath;
        private string tempFileContent = "Line1\nLine2\nLine3";
        private List<string> tempFileLines => new List<string> { "Line1", "Line2", "Line3" };

        [TestCleanup]
        public void Cleanup() {
            if (tempFilePath != null && File.Exists(tempFilePath))
                File.Delete(tempFilePath);
        }

        [TestMethod]
        public void WriteFile_And_ReadFileLines_Works() {
            tempFilePath = Path.GetTempFileName();
            FilesHelper.WriteFile(tempFilePath, tempFileLines);
            var lines = FilesHelper.ReadFileLines(tempFilePath).ToList();
            CollectionAssert.AreEqual(tempFileLines, lines);
        }

        [TestMethod]
        public void WriteFile_And_ReadFileAllText_Works() {
            tempFilePath = Path.GetTempFileName();
            FilesHelper.WriteFile(tempFilePath, tempFileLines);
            var text = FilesHelper.ReadFileAllText(tempFilePath);
            Assert.AreEqual(string.Join(Environment.NewLine, tempFileLines), text.Replace("\r", ""));
        }

        [TestMethod]
        public void WriteFile_And_ReadFileAllBytes_Works() {
            tempFilePath = Path.GetTempFileName();
            FilesHelper.WriteFile(tempFilePath, tempFileLines);
            var bytes = FilesHelper.ReadFileAllBytes(tempFilePath);
            var text = Encoding.UTF8.GetString(bytes).Replace("\r", "");
            Assert.AreEqual(string.Join(Environment.NewLine, tempFileLines), text);
        }

        [TestMethod]
        public void Delete_RemovesFile() {
            tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, tempFileContent);
            Assert.IsTrue(File.Exists(tempFilePath));
            FilesHelper.Delete(tempFilePath);
            Assert.IsFalse(File.Exists(tempFilePath));
            tempFilePath = null; // Prevent cleanup from trying to delete again
        }

        [TestMethod]
        public void CopyFile_CreatesCopy() {
            // Arrange
            var fileName = "testfile.txt";
            var fileContent = "Hello, world!";
            var tempSourcePath = Path.GetTempFileName();
            File.WriteAllText(tempSourcePath, fileContent);
            var formFile = new FormFile(new FileStream(tempSourcePath, FileMode.Open, FileAccess.Read), 0, fileContent.Length, "Data", fileName) {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };
            var pathToCopy = Path.Combine(Path.GetTempPath(), "copy_" + fileName);

            // Act
            var copiedPath = FilesHelper.CopyFile(formFile, pathToCopy);

            // Assert
            Assert.IsTrue(File.Exists(copiedPath));
            var copiedContent = File.ReadAllText(copiedPath);
            Assert.AreEqual(fileContent, copiedContent);

            // Cleanup
            File.Delete(tempSourcePath);
            File.Delete(copiedPath);
        }

        [TestMethod]
        public void Delete_NonExistentFile_ThrowsException() {
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "no_such_file_" + Path.GetRandomFileName());
            try {
                FilesHelper.Delete(nonExistentPath);
                Assert.Fail("Expected exception was not thrown.");
            } catch (Exception ex) {
                StringAssert.Contains(ex.Message.ToLower(), "could not find".ToLower());
            }
        }

        [TestMethod]
        public void ReadFileLines_NonExistentFile_ThrowsException() {
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "no_such_file_" + Path.GetRandomFileName());
            try {
                var lines = FilesHelper.ReadFileLines(nonExistentPath).ToList();
                Assert.Fail("Expected exception was not thrown.");
            } catch (Exception ex) {
                StringAssert.Contains(ex.Message.ToLower(), "could not find".ToLower());
            }
        }

        [TestMethod]
        public void ReadFileAllText_NonExistentFile_ThrowsException() {
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "no_such_file_" + Path.GetRandomFileName());
            try {
                var text = FilesHelper.ReadFileAllText(nonExistentPath);
                Assert.Fail("Expected exception was not thrown.");
            } catch (Exception ex) {
                StringAssert.Contains(ex.Message.ToLower(), "could not find".ToLower());
            }
        }

        [TestMethod]
        public void ReadFileAllBytes_NonExistentFile_ThrowsException() {
            var nonExistentPath = Path.Combine(Path.GetTempPath(), "no_such_file_" + Path.GetRandomFileName());
            try {
                var bytes = FilesHelper.ReadFileAllBytes(nonExistentPath);
                Assert.Fail("Expected exception was not thrown.");
            } catch (Exception ex) {
                StringAssert.Contains(ex.Message.ToLower(), "could not find".ToLower());
            }
        }

        [TestMethod]
        public void WriteFile_InvalidPath_ThrowsException() {
            var invalidPath = Path.Combine(Path.GetTempPath(), "invalid_dir_", "file.txt");
            try {
                FilesHelper.WriteFile(invalidPath, tempFileLines);
                Assert.Fail("Expected exception was not thrown.");
            } catch (Exception ex) {
                StringAssert.Contains(ex.Message.ToLower(), "could not find".ToLower());
            }
        }
    }
}