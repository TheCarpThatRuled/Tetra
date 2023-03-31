using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ArrayTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Array)]
public class Materialise
{
   /* ------------------------------------------------------------ */
   // public ISequence<T> Materialise<T>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_Array_of_TestClass
   //WHEN
   //Materialise
   //THEN
   //a_sequence_containing_the_array_is_returned

   [TestMethod]
   public void GIVEN_an_Array_of_TestClass_WHEN_Materialise_THEN_a_sequence_containing_the_array_is_returned()
   {
      static Property Property(TestClass[] source)
      {
         //Arrange
         //Act
         var actual = source.Materialise();

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 source,
                                 actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_Array_of_TestClass_is_Materialised
   //WHEN
   //the_array_is_modified
   //THEN
   //the_sequence_matches_the_original_array

   [TestMethod]
   public void GIVEN_an_Array_of_TestClass_is_Materialised_WHEN_the_array_is_modified_THEN_the_sequence_matches_the_original_array()
   {
      static Property Property(TestClass[] source)
      {
         //Arrange
         var expected = (TestClass[]) source.Clone();
         var sequence = source.Materialise();

         //Act
         source[0] = new(90, 90);

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 expected,
                                 sequence);
      }

      Arb.Register<Libraries.NonEmptyArrayOfTestClass>();

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}