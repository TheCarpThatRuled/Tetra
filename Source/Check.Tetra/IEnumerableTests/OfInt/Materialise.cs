using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.IEnumerableTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.IEnumerable)]
public class Materialise
{
   /* ------------------------------------------------------------ */
   // public ISequence<T> Materialise<T>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_int
   //WHEN
   //Materialise
   //THEN
   //a_sequence_containing_the_enumerable_is_returned

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_int_WHEN_Materialise_THEN_a_sequence_containing_the_enumerable_is_returned()
   {
      static Property Property(int[] source)
      {
         //Arrange
         //Act
         var actual = source
                     .ToEnumerable()
                     .Materialise();

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 source,
                                 actual);
      }

      Prop.ForAll<int[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_int_is_Materialised
   //WHEN
   //the_underlying_array_is_modified
   //THEN
   //the_sequence_matches_the_original_enumerable

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_int_is_Materialised_WHEN_the_underlying_array_is_modified_THEN_the_sequence_matches_the_original_enumerable()
   {
      static Property Property(int[] source)
      {
         //Arrange
         var expected = (int[]) source.Clone();
         var sequence = source
                       .ToEnumerable()
                       .Materialise();

         //Act
         source[0] = 90;

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 expected,
                                 sequence);
      }

      Arb.Register<Libraries.NonEmptyArrayOfInt32>();

      Prop.ForAll<int[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}