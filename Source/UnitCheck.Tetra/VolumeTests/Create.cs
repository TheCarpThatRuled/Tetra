using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Volume)]
public class Create
{
   /* ------------------------------------------------------------ */
   // Volume Create(char potentialVolume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_ASCII_letter
   //WHEN
   //Create
   //THEN
   //a_volume_with_a_value_of_the_letter_colon_is_returned

   [TestMethod]
   public void GIVEN_an_ASCII_letter_WHEN_Create_THEN_a_volume_with_a_value_of_the_letter_colon_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = Volume.Create(value);

         //Assert
         return AreEqual($"{value}:",
                         actual.Value());
      }

      Arb.Register<Libraries.AsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_non_ASCII_letter
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_non_ASCII_letter_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property(char value)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            Volume.Create(value);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                                $"'{value}' is not a valid volume label; a volume label must be an ASCII letter (Parameter 'potentialVolume')");
      }

      Arb.Register<Libraries.NonAsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}