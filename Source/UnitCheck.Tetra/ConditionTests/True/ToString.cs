using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.ConditionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Condition)]
// ReSharper disable once InconsistentNaming
public class True_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //True
   //WHEN
   //ToString
   //THEN
   //True_is_returned

   [TestMethod]
   public void GIVEN_True_WHEN_ToString_THEN_True_is_returned()
   {
      //Arrange
      var condition = Condition.True();

      //Act
      var actual = condition.ToString();

      //Assert
      Assert.That
            .AreEqual("Return value",
                      "True",
                      actual);
   }

   /* ------------------------------------------------------------ */
}