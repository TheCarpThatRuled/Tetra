using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class None_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //GetHashCode
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_None_WHEN_GetHashCode_THEN_zero_is_returned()
   {
      //Arrange
      var error = Error.None();

      //Act
      var actual = error.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(0,
                      actual);
   }

   /* ------------------------------------------------------------ */
}