using System.Text.Json;
using velocist.Services.Json.References;

namespace GenericTestProject.Json.References {
    [TestClass]
    public class JsonReferenceResolverHelperTests {
        public class TestEntity { public int Id { get; set; } }

        [TestMethod]
        public void AddReference_And_ResolveReference_Works() {
            var resolver = new JsonReferenceResolverHelper();
            var obj = new TestEntity { Id = 1 };
            resolver.AddReference("ref1", obj);
            var resolved = resolver.ResolveReference("ref1");
            Assert.AreSame(obj, resolved);
        }

        [TestMethod]
        public void GetReference_SameObject_ReturnsSameId() {
            var resolver = new JsonReferenceResolverHelper();
            var obj = new TestEntity { Id = 2 };
            bool alreadyExists1, alreadyExists2;
            var id1 = resolver.GetReference(obj, out alreadyExists1);
            var id2 = resolver.GetReference(obj, out alreadyExists2);
            Assert.AreEqual(id1, id2);
            Assert.IsFalse(alreadyExists1);
            Assert.IsTrue(alreadyExists2);
        }

        [TestMethod]
        public void GetReference_DifferentObjects_ReturnsDifferentIds() {
            var resolver = new JsonReferenceResolverHelper();
            var obj1 = new TestEntity { Id = 1 };
            var obj2 = new TestEntity { Id = 2 };
            bool exists1, exists2;
            var id1 = resolver.GetReference(obj1, out exists1);
            var id2 = resolver.GetReference(obj2, out exists2);
            Assert.AreNotEqual(id1, id2);
            Assert.IsFalse(exists1);
            Assert.IsFalse(exists2);
        }

        [TestMethod]
        public void AddReference_DuplicateId_Throws() {
            var resolver = new JsonReferenceResolverHelper();
            var obj1 = new TestEntity { Id = 1 };
            var obj2 = new TestEntity { Id = 2 };
            resolver.AddReference("ref1", obj1);
            Assert.ThrowsException<JsonException>(() => resolver.AddReference("ref1", obj2));
        }

        [TestMethod]
        public void ResolveReference_NonExistentId_Throws() {
            var resolver = new JsonReferenceResolverHelper();
            Assert.ThrowsException<JsonException>(() => resolver.ResolveReference("nope"));
        }

        [TestMethod]
        public void JsonReferenceHandlerHelper_DisposeAndReset_Works() {
            var handler = new JsonReferenceHandlerHelper();
            handler.Reset();
            handler.Dispose();
            // No exception means success
            Assert.IsNotNull(handler.CreateResolver());
        }
    }
}