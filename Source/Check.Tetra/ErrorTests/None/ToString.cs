using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class None_ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //ToString
   //THEN
   //None_is_returned

   [TestMethod]
   public void GIVEN_None_WHEN_ToString_THEN_None_is_returned()
   {
      //Arrange
      var error = Error.None();

      //Act
      var actual = error.ToString();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      "None",
                      actual);
   }

   /* ------------------------------------------------------------ */
}