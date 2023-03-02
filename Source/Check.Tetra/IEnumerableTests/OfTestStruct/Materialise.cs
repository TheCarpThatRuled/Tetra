using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.IEnumerableTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.IEnumerable)]
public class Materialise
{
   /* ------------------------------------------------------------ */
   // public ISequence<T> Materialise<T>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_TestStruct
   //WHEN
   //Materialise
   //THEN
   //a_sequence_containing_the_enumerable_is_returned

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_TestStruct_WHEN_Materialise_THEN_a_sequence_containing_the_enumerable_is_returned()
   {
      static Property Property(TestStruct[] source)
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

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_TestStruct_is_Materialised
   //WHEN
   //the_underlying_array_is_modified
   //THEN
   //the_sequence_matches_the_original_enumerable

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_TestStruct_is_Materialised_WHEN_the_underlying_array_is_modified_THEN_the_sequence_matches_the_original_enumerable()
   {
      static Property Property(TestStruct[] source)
      {
         //Arrange
         var expected = (TestStruct[]) source.Clone();
         var sequence = source
                       .ToEnumerable()
                       .Materialise();

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