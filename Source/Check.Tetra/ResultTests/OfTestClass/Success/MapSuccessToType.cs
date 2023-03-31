using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_MapSuccessToType
{
   /* ------------------------------------------------------------ */
   // IResult<TNew, T> MapSuccessToType<TNew>(TNew whenSuccess);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success
   //WHEN
   //MapSuccessToType_AND_whenSuccess_is_a_Message
   //THEN
   //a_success_containing_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_WHEN_MapSuccessToType_AND_whenSuccess_is_a_Message_THEN_a_success_containing_whenSuccess_is_returned()
   {
      static Property Property(Message whenSuccess)
      {
         //Arrange
         var result = Result<TestClass>.Success();

         //Act
         var actual = result.MapSuccessToType(whenSuccess);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // IResult<TNew, T> MapSuccessToType<TNew>(Func<TNew> whenSuccess);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success
   //WHEN
   //MapSuccessToType_AND_whenSuccess_is_a_Func_of_Message
   //THEN
   //whenSuccess_was_invoked_once_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_Success_WHEN_MapSuccessToType_AND_whenSuccess_is_a_Func_of_Message_THEN_whenSuccess_was_invoked_once_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var whenSuccess = FakeFunction<Message>.Create(value);

         var result = Result<TestClass>.Success();

         //Act
         var actual = result.MapSuccessToType(whenSuccess.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           value,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               whenSuccess));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}