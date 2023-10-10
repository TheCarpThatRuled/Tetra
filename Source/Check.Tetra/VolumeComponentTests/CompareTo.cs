using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.VolumeComponent)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // public int CompareTo(VolumeComponent? other)
   /* ------------------------------------------------------------ */


   //GIVEN
   //Volume_AND_other_is_null
   //WHEN
   //CompareTo
   //THEN
   //one_is_returned

   [TestMethod]
   public void GIVEN_Volume_AND_other_is_null_WHEN_CompareTo_THEN_one_is_returned()
   {
      static Property Property
      (
         VolumeComponent volume
      )
      {
         //Arrange
         //Act
         var actual = volume.CompareTo(null);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         1,
                         actual);
      }

      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Volume_AND_other_contains_a_letter_that_is_equal_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_Volume_AND_other_contains_a_letter_that_is_equal_ignoring_case_WHEN_CompareTo_THEN_zero_is_returned()
   {
      static Property Property
      (
         (char first, char second) args
      )
      {
         //Arrange
         var firstVolume  = VolumeComponent.Create(args.first);
         var secondVolume = VolumeComponent.Create(args.second);

         //Act
         var actual = firstVolume.CompareTo(secondVolume);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         0,
                         actual);
      }

      Arb.Register<LocalLibraries.AsciiLetterEqualToAsciiLetterCaseInsensitive>();

      Prop.ForAll<(char, char)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Volume_AND_other_contains_a_letter_that_is_greater_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_letters_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_Volume_AND_other_contains_a_letter_that_is_greater_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_letters_ignoring_case_is_returned()
   {
      static Property Property
      (
         (char first, char second) args
      )
      {
         //Arrange
         var firstVolume  = VolumeComponent.Create(args.first);
         var secondVolume = VolumeComponent.Create(args.second);

         //Act
         var actual = firstVolume.CompareTo(secondVolume);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         char.ToLowerInvariant(args.first) - char.ToLowerInvariant(args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.AsciiLetterLessThanAsciiLetterCaseInsensitive>();

      Prop.ForAll<(char, char)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Volume_AND_other_contains_a_letter_that_is_less_than_ignoring_case
   //WHEN
   //CompareTo
   //THEN
   //the_difference_between_the_letters_ignoring_case_is_returned

   [TestMethod]
   public void GIVEN_Volume_AND_other_contains_a_letter_that_is_less_than_ignoring_case_WHEN_CompareTo_THEN_the_difference_between_the_letters_ignoring_case_is_returned()
   {
      static Property Property
      (
         (char first, char second) args
      )
      {
         //Arrange
         var firstVolume  = VolumeComponent.Create(args.first);
         var secondVolume = VolumeComponent.Create(args.second);

         //Act
         var actual = firstVolume.CompareTo(secondVolume);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         char.ToLowerInvariant(args.first) - char.ToLowerInvariant(args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.AsciiLetterGreaterThanAsciiLetterCaseInsensitive>();

      Prop.ForAll<(char, char)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}