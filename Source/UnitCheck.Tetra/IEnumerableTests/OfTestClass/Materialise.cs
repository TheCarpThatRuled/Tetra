using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.IEnumerableTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.IEnumerable)]
public class Materialise
{
   /* ------------------------------------------------------------ */
   // public static ISequence<T> Materialise<T>(this IEnumerable<T> sequence)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_TestClass
   //WHEN
   //Materialise
   //THEN
   //a_sequence_containing_the_enumerable_is_returned

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_TestClass_WHEN_Materialise_THEN_a_sequence_containing_the_enumerable_is_returned()
   {
      static Property Property(TestClass[] source)
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

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_TestClass_is_Materialised
   //WHEN
   //the_underlying_array_is_modified
   //THEN
   //the_sequence_matches_the_original_enumerable

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_TestClass_is_Materialised_WHEN_the_underlying_array_is_modified_THEN_the_sequence_matches_the_original_enumerable()
   {
      static Property Property(TestClass[] source)
      {
         //Arrange
         var expected = (TestClass[]) source.Clone();
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

      Arb.Register<Libraries.NonEmptyArrayOfTestClass>();

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}