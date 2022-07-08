using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
public class Validate
{
   /* ------------------------------------------------------------ */

   private sealed class TestVolumeComponent : VolumeComponent
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Error TestValidate(char   potentialVolume,
                                       string volumeType)
         => Validate(potentialVolume,
                     volumeType);

      /* ------------------------------------------------------------ */
      // Constructor
      /* ------------------------------------------------------------ */

      private TestVolumeComponent()
         : base('\0') { }

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // VolumeComponent Validate(char potentialVolume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_ASCII_letter
   //WHEN
   //Validate
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_an_ASCII_letter_WHEN_Validate_THEN_a_none_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = TestVolumeComponent.TestValidate(value,
                                                       nameof(TestVolumeComponent));

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.AsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_non_ASCII_letter
   //WHEN
   //Validate
   //THEN
   //a_some_is_returned

   [TestMethod]
   public void GIVEN_a_non_ASCII_letter_WHEN_Validate_THEN_a_some_is_returned()
   {
      static Property Property(char value)
      {
         //Arrange
         //Act
         var actual = TestVolumeComponent.TestValidate(value,
                                                       nameof(TestVolumeComponent));

         //Assert
         return IsASome(Message.Create(Messages.IsNotAValidVolumeLabel(value,
                                                                       nameof(TestVolumeComponent))),
                        actual);
      }

      Arb.Register<Libraries.NonAsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}