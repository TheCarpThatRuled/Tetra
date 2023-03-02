using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class NoneFactory
{
   /* ------------------------------------------------------------ */
   // public static Option<T> None()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int
   //WHEN
   //None
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_None_THEN_a_none_is_returned()
   {
      //Act
      var actual = Option<int>.None();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }
   /* ------------------------------------------------------------ */
}