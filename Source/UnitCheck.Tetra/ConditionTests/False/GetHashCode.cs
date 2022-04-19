using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ConditionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Condition)]
// ReSharper disable once InconsistentNaming
public class False_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Condition
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_false_is_returned

   [TestMethod]
   public void GIVEN_Condition_WHEN_GetHashCode_THEN_the_hash_code_of_false_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(false.GetHashCode(),
                      actual);
   }

   /* ------------------------------------------------------------ */
}