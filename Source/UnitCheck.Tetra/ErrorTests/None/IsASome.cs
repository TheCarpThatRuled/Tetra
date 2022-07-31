using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class None_IsASome
{
   /* ------------------------------------------------------------ */
   // bool IsASome()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //IsASome
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_None_WHEN_IsASome_THEN_false_is_returned()
   {
      //Arrange
      var error = Error.None();

      //Act
      var actual = error.IsASome();

      //Assert
      Assert.That
            .IsFalse(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */
}