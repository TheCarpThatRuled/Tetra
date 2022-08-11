using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ConditionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Condition)]
// ReSharper disable once InconsistentNaming
public class True_GetHashCode
{
   /* ------------------------------------------------------------ */
   // public int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_true_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_GetHashCode_THEN_the_hash_code_of_true_is_returned()
   {
      //Arrange
      var condition = Condition.True();

      //Act
      var actual = condition.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      true.GetHashCode(),
                      actual);
   }

   /* ------------------------------------------------------------ */
}