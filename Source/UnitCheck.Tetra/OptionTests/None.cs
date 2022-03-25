using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None
{
   /* ------------------------------------------------------------ */
   // Option<T> None()
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_None_THEN_a_none_is_returned()
   {
      //Act
      var actual = Option<int>.None();

      //Assert
      Assert.That
            .IsANone(actual);
   }
   /* ------------------------------------------------------------ */
}