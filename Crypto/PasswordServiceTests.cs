namespace GenericTestProject.Crypto {

    [TestClass()]
    public class PasswordServiceTests {

        public PasswordServiceTests() {

        }

        [TestMethod()]
        public void GeneratePassword() {

            var password = "PruebaPassword";
            var generatedPassword = PasswordService.GeneratePassword(password);
            Console.WriteLine($"{generatedPassword.ToString()}");
        }

        [TestMethod()]
        public void GenerateRandomPassword() {
            var generatedPassword = PasswordService.GenerateRandomPassword(12);
            Console.WriteLine($"{generatedPassword.ToString()}");
        }

        [TestMethod()]
        public void GenerateFullPassword() {

            var password = "PruebaPassword";
            Console.WriteLine($"Password: {password}");

            var salt = CryptoBackendHelper.GetRandomNumberString(password.Length);
            Assert.AreNotEqual(string.Empty, salt);
            Console.WriteLine($"RandomNumberString: {salt}");

            var generatedSaltInput = CryptoBackendHelper.GenerateSalt(password, salt);
            Assert.AreNotEqual(string.Empty, generatedSaltInput);
            Console.WriteLine($"GeneratedSalt: {generatedSaltInput}");

            var generatedHash = CryptoBackendHelper.ComputeHash(password, new System.Security.Cryptography.SHA256CryptoServiceProvider(), generatedSaltInput);
            Assert.AreNotEqual(string.Empty, generatedHash);
            Console.WriteLine($"GeneratedHash: {generatedHash}");

            var token = CryptoBackendHelper.GenerateToken(password.Length);
            Assert.AreNotEqual(string.Empty, salt);
            Console.WriteLine($"Token: {token}");

            var isValidPassword = CryptoBackendHelper.IsValidPasswordWithHash(password, generatedSaltInput, generatedHash);
            Assert.IsTrue(isValidPassword);
            Console.WriteLine($"IsValid: {isValidPassword}");

        }

        [TestMethod()]
        public void GenerateFullRandomPassword() {

            var generatedPassword = CryptoBackendHelper.GeneratePassword(8);

            Assert.AreNotEqual(string.Empty, generatedPassword);
            Console.WriteLine($"Password: {generatedPassword}");

            var salt = CryptoBackendHelper.GetRandomNumberString(generatedPassword.Length);
            Assert.AreNotEqual(string.Empty, salt);
            Console.WriteLine($"RandomNumberString: {salt}");

            var generatedSaltInput = CryptoBackendHelper.GenerateSalt(generatedPassword, salt);
            Assert.AreNotEqual(string.Empty, generatedSaltInput);
            Console.WriteLine($"GeneratedSalt: {generatedSaltInput}");

            var generatedHash = CryptoBackendHelper.ComputeHash(generatedPassword, new System.Security.Cryptography.SHA256CryptoServiceProvider(), generatedSaltInput);
            Assert.AreNotEqual(string.Empty, generatedHash);
            Console.WriteLine($"GeneratedHash: {generatedHash}");

            var token = CryptoBackendHelper.GenerateToken(generatedPassword.Length);
            Assert.AreNotEqual(string.Empty, salt);
            Console.WriteLine($"Token: {token}");

            var isValidPassword = CryptoBackendHelper.IsValidPasswordWithHash(generatedPassword, generatedSaltInput, generatedHash);
            Assert.IsTrue(isValidPassword);
            Console.WriteLine($"IsValid: {isValidPassword}");
        }

        [TestMethod()]
        public void ValidPassword() {
            var password = "PruebaPassword";
            var generatedPassword = PasswordService.GeneratePassword(password);
            Console.WriteLine($"{generatedPassword.ToString()}");

            var passwordToTest = "PruebaPassword";
            var generatedPasswordTest = PasswordService.GeneratePassword(passwordToTest);
            Console.WriteLine($"{generatedPasswordTest.ToString()}");

            var isValid = PasswordService.IsValidPassword(passwordToTest, generatedPassword.Salt, generatedPassword.Hash);
            Console.WriteLine($"IsValid: {isValid}");
        }

        [TestMethod()]
        public void InvalitPassword() {
            var password = "PruebaPassword";
            var generatedPassword = PasswordService.GeneratePassword(password);
            Console.WriteLine($"{generatedPassword.ToString()}");

            var passwordToTest = "Prueba";
            var generatedPasswordTest = PasswordService.GeneratePassword(passwordToTest);
            Console.WriteLine($"{generatedPasswordTest.ToString()}");

            var isValid = PasswordService.IsValidPassword(passwordToTest, generatedPassword.Salt, generatedPassword.Hash);
            Console.WriteLine($"IsValid: {isValid}");
        }
    }
}
