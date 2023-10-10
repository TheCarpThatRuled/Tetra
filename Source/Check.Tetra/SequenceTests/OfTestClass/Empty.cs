namespace Check.SequenceTests.OfTestClass;

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
   //Sequence_of_TestClass
   //WHEN
   //Empty
   //THEN
   //an_empty_ISequence_of_TestClass_is_returned

   [TestMethod]
   public void GIVEN_Sequence_of_TestClass_WHEN_Empty_THEN_an_empty_ISequence_of_TestClass_is_returned()
   {
      //Arrange
      //Act
      var actual = Sequence<TestClass>.Empty();

      //Assert
      Assert.That
            .TetraSequenceEquals(Array.Empty<TestClass>(),
                                 actual);
   }

   /* ------------------------------------------------------------ */
}