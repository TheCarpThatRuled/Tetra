using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_IsASome
{
   /* ------------------------------------------------------------ */
   // bool IsASome()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestStruct
   //WHEN
   //IsASome
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestStruct_WHEN_IsASome_THEN_false_is_returned()
   {
      //Arrange
      var option = Option<TestStruct>.None();

      //Act
      var actual = option.IsASome();

      //Assert
      Assert.That
            .IsFalse(actual);
   }

   /* ------------------------------------------------------------ */
}