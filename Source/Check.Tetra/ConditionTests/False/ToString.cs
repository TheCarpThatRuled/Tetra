﻿namespace Check.ConditionTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Condition)]
// ReSharper disable once InconsistentNaming
public class False_ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //False
   //WHEN
   //ToString
   //THEN
   //False_is_returned

   [TestMethod]
   public void GIVEN_False_WHEN_ToString_THEN_False_is_returned()
   {
      //Arrange
      var condition = Condition.False();

      //Act
      var actual = condition.ToString();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      "False",
                      actual);
   }

   /* ------------------------------------------------------------ */
}