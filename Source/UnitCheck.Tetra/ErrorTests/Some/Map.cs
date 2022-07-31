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
public class Some_Map
{
   /* ------------------------------------------------------------ */
   // Error Map(Func<Message, Message> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_Message_to_Message
   //THEN
   //whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned

   [TestMethod]
   public void GIVEN_Some_WHEN_Map_AND_whenSome_is_a_Func_of_Message_to_Message_THEN_whenSome_was_invoked_with_the_content_AND_a_some_containing_the_return_value_of_whenSome_is_returned()
   {
      static Property Property((Message value,Message whenSome) args)
      {
         //Arrange
         var whenSome = FakeFunction<Message, Message>.Create(args.whenSome);

         var error = Error.Some(args.value);

         //Act
         var actual = error.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        args.whenSome,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               args.value,
                               whenSome));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message,Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Error Map(Func<Message, Error> whenSome)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_AND_whenSome_returns_a_none
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_Message_to_Error
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_AND_whenSome_returns_a_none_WHEN_Map_AND_whenSome_is_a_Func_of_Message_to_Error_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property(Message value)
      {
         //Arrange
         var whenSome = FakeFunction<Message, Error>.Create(Error.None());

         var error = Error.Some(value);

         //Act
         var actual = error.Map(whenSome.Func);

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               value,
                               whenSome));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_AND_whenSome_returns_a_some
   //WHEN
   //Map_AND_whenSome_is_a_Func_of_Message_to_Error
   //THEN
   //whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return

   [TestMethod]
   public void
      GIVEN_Some_AND_whenSome_returns_a_some_WHEN_Map_AND_whenSome_is_a_Func_of_Message_to_Error_THEN_whenSome_was_invoked_once_with_the_content_AND_the_return_value_of_whenSome_is_return()
   {
      static Property Property((Message value, Message newValue) args)
      {
         //Arrange
         var whenSome = FakeFunction<Message, Error>.Create(args.newValue);

         var error = Error.Some(args.value);

         //Act
         var actual = error.Map(whenSome.Func);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        args.newValue,
                        actual)
           .And(WasInvokedOnce(nameof(whenSome),
                               args.value,
                               whenSome));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message,Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}