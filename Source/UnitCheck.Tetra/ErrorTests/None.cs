using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class None
{
   /* ------------------------------------------------------------ */
   // Error None()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Error
   //WHEN
   //None
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Error_WHEN_None_THEN_a_none_is_returned()
   {
      //Act
      var actual = Error.None();

      //Assert
      Assert.That
            .IsANone(actual);
   }
   /* ------------------------------------------------------------ */
}