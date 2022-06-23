using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // int CompareTo(VolumeRootedFilePath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var volumeRootedFilePath = VolumeRootedFilePath.Create(path);

         //Act
         var actual = volumeRootedFilePath.CompareTo(null);

         //Assert
         return AreEqual(1,
                         actual);
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_other_contains_a_value_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_AND_other_contains_a_value_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstVolumeRootedFilePath  = VolumeRootedFilePath.Create(args.first);
         var secondVolumeRootedFilePath = VolumeRootedFilePath.Create(args.second);

         //Act
         var actual = firstVolumeRootedFilePath.CompareTo(secondVolumeRootedFilePath);

         //Assert
         return AreEqual(0,
                         actual);
      }

      Arb.Register<LocalLibraries.ValidVolumeRootedFilePathEqualToValidVolumeRootedFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_other_contains_a_value_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_AND_other_contains_a_value_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstVolumeRootedFilePath  = VolumeRootedFilePath.Create(args.first);
         var secondVolumeRootedFilePath = VolumeRootedFilePath.Create(args.second);

         //Act
         var actual = firstVolumeRootedFilePath.CompareTo(secondVolumeRootedFilePath);

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidVolumeRootedFilePathLessThanValidVolumeRootedFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_other_contains_a_value_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_values_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_AND_other_contains_a_value_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_values_ignoring_case_is_returned()
   {
      static Property Property((string first, string second) args)
      {
         //Arrange
         var firstVolumeRootedFilePath  = VolumeRootedFilePath.Create(args.first);
         var secondVolumeRootedFilePath = VolumeRootedFilePath.Create(args.second);

         //Act
         var actual = firstVolumeRootedFilePath.CompareTo(secondVolumeRootedFilePath);

         //Assert
         return AreEqual(StringComparer.OrdinalIgnoreCase
                                       .Compare(args.first,
                                                args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.ValidVolumeRootedFilePathGreaterThanValidVolumeRootedFilePathCaseInsensitive>();

      Prop.ForAll<(string, string)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}