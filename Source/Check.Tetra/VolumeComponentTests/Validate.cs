using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.VolumeComponent)]
public class Validate
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   private sealed class TestVolumeComponent : VolumeComponent
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static IOption<Message> TestValidate(char   potentialVolume,
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
   // protected static VolumeComponent Validate(char potentialVolume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_ASCII_letter
   //WHEN
   //Validate
   //THEN
   //a_success_is_returned

   [TestMethod]
   public void GIVEN_an_ASCII_letter_WHEN_Validate_THEN_a_success_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = TestVolumeComponent.TestValidate(value,
                                                       nameof(TestVolumeComponent));

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
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
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_non_ASCII_letter_WHEN_Validate_THEN_a_failure_is_returned()
   {
      static Property Property(char value)
      {
         //Arrange
         //Act
         var actual = TestVolumeComponent.TestValidate(value,
                                                       nameof(TestVolumeComponent));

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        Message.Create(Messages.IsNotValidBecauseAVolumeLabelMustBeAnASCIILetter(value,
                                                                                                 nameof(TestVolumeComponent))),
                        actual);
      }

      Arb.Register<Libraries.NonAsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}