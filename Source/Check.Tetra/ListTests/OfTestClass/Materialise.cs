using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ListTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.List)]
public class Materialise
{
   /* ------------------------------------------------------------ */
   // public ISequence<T> Materialise<T>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_of_TestClass
   //WHEN
   //Materialise
   //THEN
   //a_sequence_containing_the_list_is_returned

   [TestMethod]
   public void GIVEN_an_List_of_TestClass_WHEN_Materialise_THEN_a_sequence_containing_the_list_is_returned()
   {
      static Property Property(List<TestClass> source)
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

      Prop.ForAll<List<TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_of_TestClass_is_Materialised
   //WHEN
   //the_list_is_modified
   //THEN
   //the_sequence_matches_the_original_list

   [TestMethod]
   public void GIVEN_an_List_of_TestClass_is_Materialised_WHEN_the_list_is_modified_THEN_the_sequence_matches_the_original_list()
   {
      static Property Property(List<TestClass> source)
      {
         //Arrange
         var expected = source.ToArray();
         var sequence = source.Materialise();

         //Act
         source[0] = new(90,
                         90);

         //Assert
         return AreSequenceEqual(AssertMessages.ReturnValue,
                                 expected,
                                 sequence);
      }

      Arb.Register<Libraries.NonEmptyListOfTestClass>();

      Prop.ForAll<List<TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}