using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // Result<VolumeComponent> Parse(char potentialVolume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_ASCII_letter
   //WHEN
   //Parse
   //THEN
   //a_success_containing_a_volume_with_a_value_of_the_letter_colon_is_returned

   [TestMethod]
   public void GIVEN_an_ASCII_letter_WHEN_Parse_THEN_a_success_containing_a_volume_with_a_value_of_the_letter_colon_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = VolumeComponent.Parse(value);

         //Assert
         return IsASuccessAnd(actualVolume => $"{value}:"
                                           == actualVolume
                                             .Content()
                                             .Value(),
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
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_non_ASCII_letter_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = VolumeComponent.Parse(value);

         //Assert
         return IsAFailure(Message.Create(IsNotAValidVolumeLabel(value,
                                                                 HumanReadableName.Volume)),
                           actual);
      }

      Arb.Register<Libraries.NonAsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}