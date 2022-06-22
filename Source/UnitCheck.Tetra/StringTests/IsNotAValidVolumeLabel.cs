using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.StringTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.String)]
public class IsNotAValidVolumeLabel
{
   /* ------------------------------------------------------------ */
   // bool IsNotAValidVolumeLabel(this string value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //IsNotAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_IsNotAValidVolumeLabel_THEN_false_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         //Act
         var actual = value.IsNotAValidVolumeLabel();

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.ValidVolumeLabel>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_the_wrong_number_of_characters
   //WHEN
   //IsNotAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_the_wrong_number_of_characters_WHEN_IsNotAValidVolumeLabel_THEN_true_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsNotAValidVolumeLabel();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.InvalidVolumeLabelWrongNumberOfCharacters>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_an_invalid_first_character
   //WHEN
   //IsNotAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_first_character_WHEN_IsNotAValidVolumeLabel_THEN_true_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsNotAValidVolumeLabel();
         
         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.InvalidVolumeLabelInvalidFirstCharacter>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_an_invalid_second_character
   //WHEN
   //IsNotAValidVolumeLabel
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_second_character_WHEN_IsNotAValidVolumeLabel_THEN_true_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsNotAValidVolumeLabel();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.InvalidVolumeLabelInvalidSecondCharacter>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}