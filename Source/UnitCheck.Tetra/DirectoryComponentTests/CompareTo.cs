﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DirectoryComponent)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // int CompareTo(DirectoryComponent? other)
   /* ------------------------------------------------------------ */


   //GIVEN
   //DirectoryComponent_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_DirectoryComponent_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var directoryComponent = DirectoryComponent.Create(value);

         //Act
         var actual = directoryComponent.CompareTo(null);

         //Assert
         return AreEqual(1,
                         actual);
      }

      Arb.Register<Libraries.ValidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_DirectoryComponent_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstDirectoryComponent  = DirectoryComponent.Create(args.first);
         var secondDirectoryComponent = DirectoryComponent.Create(args.second);

         //Act
         var actual = firstDirectoryComponent.CompareTo(secondDirectoryComponent);

         //Assert
         return AreEqual(0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidPathComponentEqualToValidPathComponentCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //DirectoryComponent_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_DirectoryComponent_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstDirectoryComponent  = DirectoryComponent.Create(args.first);
         var secondDirectoryComponent = DirectoryComponent.Create(args.second);

         //Act
         var actual = firstDirectoryComponent.CompareTo(secondDirectoryComponent);

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
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
   //DirectoryComponent_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_DirectoryComponent_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstDirectoryComponent  = DirectoryComponent.Create(args.first);
         var secondDirectoryComponent = DirectoryComponent.Create(args.second);

         //Act
         var actual = firstDirectoryComponent.CompareTo(secondDirectoryComponent);

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
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