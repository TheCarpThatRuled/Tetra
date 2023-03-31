using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.MessageTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Message)]
// ReSharper disable once InconsistentNaming
public class Content
{
   /* ------------------------------------------------------------ */
   // public string Content()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Message
   //WHEN
   //Content
   //THEN
   //the_content_is_returned

   [TestMethod]
   public void GIVEN_Message_WHEN_Content_THEN_the_content_is_returned()
   {
      static Property Property(string value)
      {
         //Arrange
         var message = Message.Create(value);

         //Act
         var actual = message.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         value,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}