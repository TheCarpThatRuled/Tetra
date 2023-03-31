using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ArrayTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Array)]
public class Materialise
{
   /* ------------------------------------------------------------ */
   // public ISequence<T> Materialise<T>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_Array_of_TestStruct
   //WHEN
   //Materialise
   //THEN
   //a_sequence_containing_the_array_is_returned

   [TestMethod]
   public void GIVEN_an_Array_of_TestStruct_WHEN_Materialise_THEN_a_sequence_containing_the_array_is_returned()
   {
      static Property Property(TestStruct[] source)
      {
         //Arrange
         //Act
         var actual = source.Materialise();

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 source,
                                 actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_Array_of_TestStruct_is_Materialised
   //WHEN
   //the_array_is_modified
   //THEN
   //the_sequence_matches_the_original_array

   [TestMethod]
   public void GIVEN_an_Array_of_TestStruct_is_Materialised_WHEN_the_array_is_modified_THEN_the_sequence_matches_the_original_array()
   {
      static Property Property(TestStruct[] source)
      {
         //Arrange
         var expected = (TestStruct[]) source.Clone();
         var sequence = source.Materialise();

         //Act
         source[0] = new(90, 90);

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 expected,
                                 sequence);
      }

      Arb.Register<Libraries.NonEmptyArrayOfTestStruct>();

      Prop.ForAll<TestStruct[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}