using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_IsANone
{
   /* ------------------------------------------------------------ */
   // public bool IsANone()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //IsANone
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestClass_WHEN_IsANone_THEN_true_is_returned()
   {
      //Arrange
      var option = Option<TestClass>.None();

      //Act
      var actual = option.IsANone();

      //Assert
      Assert.That
            .IsTrue(AssertMessages.ReturnValue,
                    actual);
   }

   /* ------------------------------------------------------------ */
}