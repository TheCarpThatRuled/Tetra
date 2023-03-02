using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_GetHashCode
{
   /* ------------------------------------------------------------ */
   // public int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestClass
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_Type_TestClass_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestClass_WHEN_GetHashCode_THEN_the_hash_code_of_Type_TestClass_is_returned()
   {
      //Arrange
      var option = Option<TestClass>.None();

      //Act
      var actual = option.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      typeof(TestClass).GetHashCode(),
                      actual);
   }

   /* ------------------------------------------------------------ */
}