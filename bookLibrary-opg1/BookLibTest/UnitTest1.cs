using BookLibraryopg1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookLibTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // Tester om en bog kan oprettes ved at opfylde statements
        public void Succes()
        {
            Book book = new Book("Hurtige Biler", "T Hansen", 666, "1234567890123");
            Assert.IsTrue(book.forfatter.Length >= 2, "Forfatter navn inkludere flere tegn end 1");
            Assert.IsTrue(book.sidetal >= 4, "Sidetal er større end 3");
            Assert.IsTrue(book.sidetal <= 1000, "Sidetal er mindre end 1000");
            Assert.AreEqual(book.Isbn13.Length, 13);
        }

        [TestMethod]
        // Tester om Forfatter navnet er for kort, skal være mere end et bogstav
        public void Fail1()
        {
            Book book = new Book("Hurtige Biler", "T", 1, "1234567890123");
            Assert.IsTrue(book.forfatter.Length >= 2, "Forfatter navn inkludere flere tegn end 1");
            Assert.IsTrue(book.sidetal >= 4, "Sidetal er større end 3");
            Assert.IsTrue(book.sidetal <= 1000, "Sidetal er mindre end 1000");
            Assert.AreEqual(book.Isbn13.Length, 13);
        }

        [TestMethod]
        // Tester om Sidetallet er for højt, det skal være mellem 4 til 1000 sider
        public void Fail2()
        {
            Book book = new Book("Hurtige Biler", "T Hansen", 1001, "1234567890123");
            Assert.IsTrue(book.forfatter.Length >= 2, "Forfatter navn inkludere flere tegn end 1");
            Assert.IsTrue(book.sidetal >= 4, "Sidetal er større end 3");
            Assert.IsTrue(book.sidetal <= 1000, "Sidetal er mindre end 1000");
            Assert.AreEqual(book.Isbn13.Length, 13);
        }


        [TestMethod]
        // Tester om Isbn13 nummeret er 13 bogstaver/tal langt, der er 1 for meget i dette tilfælde
        public void Fail3()
        {
            Book book = new Book("Hurtige Biler", "T Hansen", 666, "12345678901234");
            Assert.IsTrue(book.forfatter.Length >= 2, "Forfatter navn inkludere flere tegn end 1");
            Assert.IsTrue(book.sidetal >= 4, "Sidetal er større end 3");
            Assert.IsTrue(book.sidetal <= 1000, "Sidetal er mindre end 1000");
            Assert.AreEqual(book.Isbn13.Length, 13);
        }
    }
}
