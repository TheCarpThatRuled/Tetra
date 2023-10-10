using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.FileComponent)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // public int CompareTo(FileComponent? other)
   /* ------------------------------------------------------------ */


   //GIVEN
   //FileComponent_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_FileComponent_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property
      (
         FileComponent file
      )
      {
         //Arrange
         //Act
         var actual = file.CompareTo(null);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         1,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_FileComponent_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstFileComponent  = FileComponent.Create(args.first);
         var secondFileComponent = FileComponent.Create(args.second);

         //Act
         var actual = firstFileComponent.CompareTo(secondFileComponent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidPathComponentEqualToValidPathComponentCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_comparison_between_the_values_ordinal_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_FileComponent_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_comparison_between_the_values_ordinal_ignoring_case_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstFileComponent  = FileComponent.Create(args.first);
         var secondFileComponent = FileComponent.Create(args.second);

         //Act
         var actual = firstFileComponent.CompareTo(secondFileComponent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidPathComponentLessThanValidPathComponentCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_FileComponent_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_comparison_between_the_values_ordinal_ignoring_case_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstFileComponent  = FileComponent.Create(args.first);
         var secondFileComponent = FileComponent.Create(args.second);

         //Act
         var actual = firstFileComponent.CompareTo(secondFileComponent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidPathComponentGreaterThanValidPathComponentCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}