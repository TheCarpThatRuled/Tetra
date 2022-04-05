using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.MessageTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Message)]
// ReSharper disable once InconsistentNaming
public class Content
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Content
   //THEN
   //the_content_is_returned

   [TestMethod]
   public void GIVEN_Message_WHEN_Content_THEN_the_content_are_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var message = Message.Create(value);

         //Act
         var actual = message.Content();

         //Assert
         return AreEqual(value,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}