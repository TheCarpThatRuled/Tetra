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
public class None_MapToResult
{
   /* ------------------------------------------------------------ */
   // Result<T> MapToResult(Message whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_an_Message
   //THEN
   //a_failure_containing_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_Message_THEN_a_failure_containing_whenNone_is_returned()
   {
      static Property Property(Message whenNone)
      {
         //Arrange
         var option = Option<int>.None();

         //Act
         var actual = option.MapToResult(whenNone);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           whenNone,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> MapToResult(Func<Message> whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_Message
   //THEN
   //whenNone_was_invoked_once_AND_a_failure_containing_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_Func_of_Message_THEN_whenNone_was_invoked_once_AND_a_failure_containing_the_return_value_of_whenNone_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var whenNone = FakeFunction<Message>.Create(value);

         var option = Option<int>.None();

         //Act
         var actual = option.MapToResult(whenNone.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           value,
                           actual)
           .And(WasInvokedOnce(nameof(whenNone),
                               whenNone));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}