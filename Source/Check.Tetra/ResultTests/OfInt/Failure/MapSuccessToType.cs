using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_MapSuccessToType
{
   /* ------------------------------------------------------------ */
   // IResult<TNew, T> MapSuccessToType<TNew>(TNew whenSuccess);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure
   //WHEN
   //MapSuccessToType_AND_whenSuccess_is_a_Message
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_WHEN_MapSuccessToType_AND_whenSuccess_is_a_Message_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(int     content,
                               Message whenSuccess)
      {
         //Arrange
         var result = Tetra.Result.Failure(content);

         //Act
         var actual = result.MapSuccessToType(whenSuccess);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // IResult<TNew, T> MapSuccessToType<TNew>(Func<TNew> whenSuccess);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure
   //WHEN
   //MapSuccessToType_AND_whenSuccess_is_a_Func_of_Message
   //THEN
   //whenSuccess_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_WHEN_MapSuccessToType_AND_whenSuccess_is_a_Func_of_Message_THEN_whenSuccess_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property(int     content,
                               Message value)
      {
         //Arrange
         var whenSuccess = FakeFunction<Message>.Create(value);

         var result = Tetra.Result.Failure(content);

         //Act
         var actual = result.MapSuccessToType(whenSuccess.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenSuccess),
                              whenSuccess));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}