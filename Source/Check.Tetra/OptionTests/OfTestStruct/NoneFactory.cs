using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestStruct;

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
   //Option_of_TestStruct
   //WHEN
   //None
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_None_THEN_a_none_is_returned()
   {
      //Act
      var actual = Option<TestStruct>.None();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }
   /* ------------------------------------------------------------ */
}