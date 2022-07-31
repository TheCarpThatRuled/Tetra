using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_int
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_Type_int_is_returned

   [TestMethod]
   public void GIVEN_None_of_int_WHEN_GetHashCode_THEN_the_hash_code_of_Type_int_is_returned()
   {
      //Arrange
      var option = Option<int>.None();

      //Act
      var actual = option.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      typeof(int).GetHashCode(),
                      actual);
   }

   /* ------------------------------------------------------------ */
}