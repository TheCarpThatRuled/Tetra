﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.VolumeComponent)]
// ReSharper disable once InconsistentNaming
public class GetHashCode
{
   /* ------------------------------------------------------------ */
   // public int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeComponent
   //WHEN
   //GetHashCode
   //THEN
   //the_ordinal_ignore_case_hash_code_of_the_value_is_returned

   [TestMethod]
   public void GIVEN_Volume_WHEN_GetHashCode_THEN_the_ordinal_ignore_case_hash_code_of_the_value_is_returned()
   {
      static Property Property
      (
         char asciiLetter
      )
      {
         //Arrange
         var volume = VolumeComponent.Create(asciiLetter);

         //Act
         var actual = volume.GetHashCode();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         StringComparer.OrdinalIgnoreCase
                                       .GetHashCode($"{asciiLetter}:"),
                         actual);
      }

      Arb.Register<Libraries.AsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}