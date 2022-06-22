using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.StringTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.String)]
public class IsAValidVolumeLabel
{
   /* ------------------------------------------------------------ */
   // bool IsAValidVolumeLabel(this string value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //IsAValidVolumeLabel
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_IsAValidVolumeLabel_THEN_true_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         //Act
         var actual = value.IsAValidVolumeLabel();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.ValidVolumeLabel>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_the_wrong_number_of_characters
   //WHEN
   //IsAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_the_wrong_number_of_characters_WHEN_IsAValidVolumeLabel_THEN_false_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsAValidVolumeLabel();

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.InvalidVolumeLabelWrongNumberOfCharacters>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_an_invalid_first_character
   //WHEN
   //IsAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_first_character_WHEN_IsAValidVolumeLabel_THEN_false_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsAValidVolumeLabel();
         
         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.InvalidVolumeLabelInvalidFirstCharacter>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_an_invalid_second_character
   //WHEN
   //IsAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_second_character_WHEN_IsAValidVolumeLabel_THEN_false_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsAValidVolumeLabel();

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.InvalidVolumeLabelInvalidSecondCharacter>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}