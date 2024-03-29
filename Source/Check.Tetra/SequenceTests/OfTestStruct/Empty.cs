﻿namespace Check.SequenceTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Sequence)]
// ReSharper disable once InconsistentNaming
public class Empty
{
   /* ------------------------------------------------------------ */
   // public static ISequence<T> Sequence<T>.From(params T[] array)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Sequence_of_TestStruct
   //WHEN
   //Empty
   //THEN
   //an_empty_ISequence_of_TestStruct_is_returned

   [TestMethod]
   public void GIVEN_Sequence_of_TestStruct_WHEN_Empty_THEN_an_empty_ISequence_of_TestStruct_is_returned()
   {
      //Arrange
      //Act
      var actual = Sequence<TestStruct>.Empty();

      //Assert
      Assert.That
            .TetraSequenceEquals(Array.Empty<TestStruct>(),
                                 actual);
   }

   /* ------------------------------------------------------------ */
}