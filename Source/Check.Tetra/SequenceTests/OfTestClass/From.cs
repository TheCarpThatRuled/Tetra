using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.SequenceTests.LocalAsserts;

namespace Check.SequenceTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Sequence)]
// ReSharper disable once InconsistentNaming
public class From
{
   /* ------------------------------------------------------------ */
   // public static ISequence<T> Sequence<T>.From(params T[] array)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Sequence_of_TestClass_AND_an_Array_of_TestClass
   //WHEN
   //From
   //THEN
   //an_ISequence_of_TestClass_that_is_sequence_equal_to_the_array_is_returned

   [TestMethod]
   public void GIVEN_Sequence_of_TestClass_AND_an_Array_of_TestClass_WHEN_From_THEN_an_ISequence_of_TestClass_that_is_sequence_equal_to_the_array_is_returned()
   {
      static Property Property(TestClass[] array)
      {
         //Arrange
         //Act
         var actual = Sequence<TestClass>.From(array);

         //Assert
         return TetraSequenceEquals(array,
                                    actual);
      }

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static ISequence<T> Sequence.From<T>(params T[] array)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Sequence_AND_an_Array_of_TestClass
   //WHEN
   //From
   //THEN
   //an_ISequence_of_TestClass_that_is_sequence_equal_to_the_array_is_returned

   [TestMethod]
   public void GIVEN_Sequence_AND_an_Array_of_TestClass_WHEN_From_THEN_an_ISequence_of_TestClass_that_is_sequence_equal_to_the_array_is_returned()
   {
      static Property Property(TestClass[] array)
      {
         //Arrange
         //Act
         var actual = Sequence.From(array);

         //Assert
         return TetraSequenceEquals(array,
                                    actual);
      }

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}