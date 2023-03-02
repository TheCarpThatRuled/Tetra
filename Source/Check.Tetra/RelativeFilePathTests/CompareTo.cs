using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeFilePath)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // public int CompareTo(RelativeFilePath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_RelativeFilePath_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property(RelativeFilePath path)
      {
         //Arrange
         //Act
         var actual = path.CompareTo(null);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         1,
                         actual);
      }

      Arb.Register<Libraries.RelativeFilePath>();

      Prop.ForAll<RelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_RelativeFilePath_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstRelativeFilePath  = RelativeFilePath.Create(args.first);
         var secondRelativeFilePath = RelativeFilePath.Create(args.second);

         //Act
         var actual = firstRelativeFilePath.CompareTo(secondRelativeFilePath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidRelativeFilePathEqualToValidRelativeFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeFilePath_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstRelativeFilePath  = RelativeFilePath.Create(args.first);
         var secondRelativeFilePath = RelativeFilePath.Create(args.second);

         //Act
         var actual = firstRelativeFilePath.CompareTo(secondRelativeFilePath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidRelativeFilePathLessThanValidRelativeFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_RelativeFilePath_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstRelativeFilePath  = RelativeFilePath.Create(args.first);
         var secondRelativeFilePath = RelativeFilePath.Create(args.second);

         //Act
         var actual = firstRelativeFilePath.CompareTo(secondRelativeFilePath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidRelativeFilePathGreaterThanValidRelativeFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}