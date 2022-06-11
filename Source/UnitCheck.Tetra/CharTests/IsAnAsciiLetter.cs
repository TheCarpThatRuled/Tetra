using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.CharTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Char)]
public class IsAnAsciiLetter
{
   /* ------------------------------------------------------------ */
   // bool IsAnAsciiLetter(char character)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_ASCII_letter
   //WHEN
   //IsAnAsciiLetter
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_an_ASCII_letter_WHEN_IsAnAsciiLetter_THEN_true_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = value.IsAnAsciiLetter();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.AsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_non_ASCII_letter
   //WHEN
   //IsAnAsciiLetter
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_non_ASCII_letter_WHEN_IsAnAsciiLetter_THEN_false_is_returned()
   {
      static Property Property(char value)
      {
         //Act
         var actual = value.IsAnAsciiLetter();
         
         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.NonAsciiLetters>();

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}