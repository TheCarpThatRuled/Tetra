using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // public int CompareTo(RelativeDirectoryPath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property
      (
         RelativeDirectoryPath path
      )
      {
         //Arrange
         //Act
         var actual = path.CompareTo(null);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         1,
                         actual);
      }

      Arb.Register<Libraries.RelativeDirectoryPath>();

      Prop.ForAll<RelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_RelativeDirectoryPath_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstRelativeDirectoryPath  = RelativeDirectoryPath.Create(args.first);
         var secondRelativeDirectoryPath = RelativeDirectoryPath.Create(args.second);

         //Act
         var actual = firstRelativeDirectoryPath.CompareTo(secondRelativeDirectoryPath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidRelativeDirectoryPathEqualToValidRelativeDirectoryPathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeDirectoryPath_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstRelativeDirectoryPath  = RelativeDirectoryPath.Create(args.first);
         var secondRelativeDirectoryPath = RelativeDirectoryPath.Create(args.second);

         //Act
         var actual = firstRelativeDirectoryPath.CompareTo(secondRelativeDirectoryPath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidRelativeDirectoryPathLessThanValidRelativeDirectoryPathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeDirectoryPath_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeDirectoryPath_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstRelativeDirectoryPath  = RelativeDirectoryPath.Create(args.first);
         var secondRelativeDirectoryPath = RelativeDirectoryPath.Create(args.second);

         //Act
         var actual = firstRelativeDirectoryPath.CompareTo(secondRelativeDirectoryPath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidRelativeDirectoryPathGreaterThanValidRelativeDirectoryPathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}