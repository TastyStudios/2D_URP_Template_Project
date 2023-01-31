using NUnit.Framework;

namespace Setup.Scripts.Editor.Tests {
    public class ToPascalCaseTest
    {
        [Test]
        public void ToPascalCaseTestSimplePasses() {
            Assert.AreEqual("PascalCase", StringHelper.ToPascalCase("pascal case"));
        }
    }
}
