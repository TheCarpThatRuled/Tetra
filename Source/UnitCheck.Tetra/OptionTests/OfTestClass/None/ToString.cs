using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //ToString
   //THEN
   //None_of_TestClass_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestClass_WHEN_ToString_THEN_None_of_TestClass_is_returned()
   {
      //Arrange
      var option = Option<TestClass>.None();

      //Act
      var actual = option.ToString();

      //Assert
      Assert.That
            .AreEqual("None of TestClass",
                      actual);
   }

   /* ------------------------------------------------------------ */
}