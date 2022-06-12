using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Volume)]
// ReSharper disable once InconsistentNaming
public class CompareTo
{
   /* ------------------------------------------------------------ */
   // int CompareTo(Volume? other)
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
      static Property Property(char asciiLetter)
      {
         //Arrange
         var volume = Volume.Create(asciiLetter);

         //Act
         var actual = volume.CompareTo(null);

         //Assert
         return AreEqual(1,
                         actual);
      }

      Arb.Register<Libraries.AsciiLetters>();

      Prop.ForAll<char>(Property)
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
      static Property Property((char first, char second) args)
      {
         //Arrange
         var firstVolume  = Volume.Create(args.first);
         var secondVolume = Volume.Create(args.second);

         //Act
         var actual = firstVolume.CompareTo(secondVolume);

         //Assert
         return AreEqual(0,
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
      static Property Property((char first, char second) args)
      {
         //Arrange
         var firstVolume  = Volume.Create(args.first);
         var secondVolume = Volume.Create(args.second);

         //Act
         var actual = firstVolume.CompareTo(secondVolume);

         //Assert
         return AreEqual(char.ToLowerInvariant(args.first) - char.ToLowerInvariant(args.second),
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
      static Property Property((char first, char second) args)
      {
         //Arrange
         var firstVolume  = Volume.Create(args.first);
         var secondVolume = Volume.Create(args.second);

         //Act
         var actual = firstVolume.CompareTo(secondVolume);

         //Assert
         return AreEqual(char.ToLowerInvariant(args.first) - char.ToLowerInvariant(args.second),
                         actual);
      }

      Arb.Register<LocalLibraries.AsciiLetterGreaterThanAsciiLetterCaseInsensitive>();

      Prop.ForAll<(char, char)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}