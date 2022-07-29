using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfInt;

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
   //None_of_int
   //WHEN
   //ToString
   //THEN
   //None_of_Int32_is_returned

   [TestMethod]
   public void GIVEN_None_of_int_WHEN_ToString_THEN_None_of_Int32_is_returned()
   {
      //Arrange
      var option = Option<int>.None();

      //Act
      var actual = option.ToString();

      //Assert
      Assert.That
            .AreEqual("Return value",
                      "None of Int32",
                      actual);
   }

   /* ------------------------------------------------------------ */
}