using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // int CompareTo(AbsoluteFilePath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property(AbsoluteFilePath path)
      {
         //Arrange
         //Act
         var actual = path.CompareTo(null);

         //Assert
         return AreEqual(1,
                         actual);
      }

      Arb.Register<Libraries.AbsoluteFilePath>();

      Prop.ForAll<AbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstAbsoluteFilePath  = AbsoluteFilePath.Create(args.first);
         var secondAbsoluteFilePath = AbsoluteFilePath.Create(args.second);

         //Act
         var actual = firstAbsoluteFilePath.CompareTo(secondAbsoluteFilePath);

         //Assert
         return AreEqual(0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidAbsoluteFilePathEqualToValidAbsoluteFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteFilePath_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstAbsoluteFilePath  = AbsoluteFilePath.Create(args.first);
         var secondAbsoluteFilePath = AbsoluteFilePath.Create(args.second);

         //Act
         var actual = firstAbsoluteFilePath.CompareTo(secondAbsoluteFilePath);

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidAbsoluteFilePathLessThanValidAbsoluteFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstAbsoluteFilePath  = AbsoluteFilePath.Create(args.first);
         var secondAbsoluteFilePath = AbsoluteFilePath.Create(args.second);

         //Act
         var actual = firstAbsoluteFilePath.CompareTo(secondAbsoluteFilePath);

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidAbsoluteFilePathGreaterThanValidAbsoluteFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}