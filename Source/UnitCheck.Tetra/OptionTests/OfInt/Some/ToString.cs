using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //ToString
   //THEN
   //Some_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_ToString_THEN_Some_brackets_the_content_to_string_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.ToString();

         //Assert
         return AreEqual($"Some ({value})",
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}