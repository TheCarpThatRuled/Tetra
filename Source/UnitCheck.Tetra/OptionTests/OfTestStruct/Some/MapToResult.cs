using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_MapToResult
{
   /* ------------------------------------------------------------ */
   // Result<T> MapToResult(Message whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_Message
   //THEN
   //a_success_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_Message_THEN_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content, Message whenNone)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.MapToResult(whenNone);

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> MapToResult(Func<Message> whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_Message
   //THEN
   //whenNone_was_not_invoked_AND_a_success_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_Func_of_Message_THEN_whenNone_was_not_invoked_AND_a_success_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content, Message value)
      {
         //Arrange
         var whenNone = FakeFunction<Message>.Create(value);

         var option = Option.Some(content);

         //Act
         var actual = option.MapToResult(whenNone.Func);

         //Assert
         return IsASuccess(content,
                           actual)
           .And(WasNotInvoked(whenNone));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, Message>(Property)
          .QuickCheckThrowOnFailure();
   }
   
   /* ------------------------------------------------------------ */
}