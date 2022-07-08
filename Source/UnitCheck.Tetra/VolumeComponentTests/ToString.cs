using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
// ReSharper disable once InconsistentNaming
public class ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeComponent
   //WHEN
   //ToString
   //THEN
   //the_value_bounded_by_angle_brackets_is_returned

   [TestMethod]
   public void GIVEN_Volume_WHEN_ToString_THEN_the_value_bounded_by_angle_brackets_is_returned()
   {
      static Property Property(char asciiLetter)
      {
         //Arrange
         var volume = VolumeComponent.Create(asciiLetter);

         //Act
         var actual = volume.ToString();

         //Assert
         return AreEqual($"<{asciiLetter}:>",
                         actual);
      }

      Arb.Register<Libraries.AsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}