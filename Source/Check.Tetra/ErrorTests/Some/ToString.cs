using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class Some_ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //ToString
   //THEN
   //Some_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Some_WHEN_ToString_THEN_Some_brackets_the_content_to_string_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var error = Error.Some(value);

         //Act
         var actual = error.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Some ({value})",
                         actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}