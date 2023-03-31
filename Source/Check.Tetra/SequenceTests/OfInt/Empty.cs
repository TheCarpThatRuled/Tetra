namespace Check.SequenceTests.OfInt;

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
   //Sequence_of_int
   //WHEN
   //Empty
   //THEN
   //an_empty_ISequence_of_int_is_returned

   [TestMethod]
   public void GIVEN_Sequence_of_int_WHEN_Empty_THEN_an_empty_ISequence_of_int_is_returned()
   {
      //Arrange
      //Act
      var actual = Sequence<int>.Empty();

      //Assert
      Assert.That
            .TetraSequenceEquals(Array.Empty<int>(),
                                 actual);
   }

   /* ------------------------------------------------------------ */
}