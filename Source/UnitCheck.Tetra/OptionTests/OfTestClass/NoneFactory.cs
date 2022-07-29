using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class NoneFactory
{
   /* ------------------------------------------------------------ */
   // Option<T> None()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //None
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_None_THEN_a_none_is_returned()
   {
      //Act
      var actual = Option<TestClass>.None();

      //Assert
      Assert.That
            .IsANone("Return value",
                     actual);
   }
   /* ------------------------------------------------------------ */
}