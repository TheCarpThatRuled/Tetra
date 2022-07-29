using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class None_Map
{
   /* ------------------------------------------------------------ */
   // Error Map(Func<Message, Message> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_Message_to_Message
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_Map_AND_whenSome_is_a_Func_of_Message_to_Message_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var whenSome = FakeFunction<Message, Message>.Create(value);

         var error = Error.None();

         //Act
         var actual = error.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Error Map(Func<Message, Error> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_Message_to_Error
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_Message_to_Error_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      //Arrange
      var whenSome = FakeFunction<Message, Error>.Create(Error.None());

      var error = Error.None();

      //Act
      var actual = error.Map(whenSome.Func);

      //Assert
      Assert.That
            .IsANone("Return value",
                     actual)
            .WasNotInvoked(nameof(whenSome),
                           whenSome);

   }/* ------------------------------------------------------------ */

   //GIVEN
   //None_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_Message_to_Error
   //THEN
   //whenSome_was_not_invoked_AND_a_none_is_returned

   [TestMethod]
   public void
      GIVEN_None_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_Message_to_Error_THEN_whenSome_was_not_invoked_AND_a_none_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var whenSome = FakeFunction<Message, Error>.Create(value);

         var error = Error.None();

         //Act
         var actual = error.Map(whenSome.Func);

         //Assert
         return IsANone(actual)
           .And(WasNotInvoked(whenSome));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}