﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // int CompareTo(AbsoluteDirectoryPath? other);
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property
      (
         AbsoluteDirectoryPath path
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

      Arb.Register<Libraries.AbsoluteDirectoryPath>();

      Prop.ForAll<AbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteDirectoryPath_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstAbsoluteDirectoryPath  = AbsoluteDirectoryPath.Create(args.first);
         var secondAbsoluteDirectoryPath = AbsoluteDirectoryPath.Create(args.second);

         //Act
         var actual = firstAbsoluteDirectoryPath.CompareTo(secondAbsoluteDirectoryPath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidAbsoluteDirectoryPathEqualToValidAbsoluteDirectoryPathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteDirectoryPath_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstAbsoluteDirectoryPath  = AbsoluteDirectoryPath.Create(args.first);
         var secondAbsoluteDirectoryPath = AbsoluteDirectoryPath.Create(args.second);

         //Act
         var actual = firstAbsoluteDirectoryPath.CompareTo(secondAbsoluteDirectoryPath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidAbsoluteDirectoryPathLessThanValidAbsoluteDirectoryPathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteDirectoryPath_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteDirectoryPath_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property
      (
         (string first, string second) args
      )
      {
         //Arrange
         var firstAbsoluteDirectoryPath  = AbsoluteDirectoryPath.Create(args.first);
         var secondAbsoluteDirectoryPath = AbsoluteDirectoryPath.Create(args.second);

         //Act
         var actual = firstAbsoluteDirectoryPath.CompareTo(secondAbsoluteDirectoryPath);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidAbsoluteDirectoryPathGreaterThanValidAbsoluteDirectoryPathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}