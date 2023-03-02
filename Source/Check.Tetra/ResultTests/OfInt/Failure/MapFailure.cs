using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_MapFailure
{
   /* ------------------------------------------------------------ */
   // IResult<T> MapFailure(Func<Failure, Message> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //MapFailure_AND_whenFailure_is_a_Func_of_Failure_to_Message
   //THEN
   //whenFailure_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned

   [TestMethod]
   public void
      GIVEN_Failure_of_int_WHEN_MapFailure_AND_whenFailure_is_a_Func_of_Failure_to_Message_THEN_whenFailure_was_invoked_once_with_the_content_AND_a_failure_containing_the_return_value_of_whenFailure_is_returned()
   {
      static Property Property((Message content, Message whenFailure) args)
      {
         //Arrange
         var whenFailure = FakeFunction<Failure, Message>.Create(args.whenFailure);

         var result = Result<int>.Failure(args.content);

         //Act
         var actual = result.MapFailure(whenFailure.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           args.whenFailure,
                           actual)
           .And(WasInvokedOnce(nameof(whenFailure),
                               args.content,
                               whenFailure));
      }

      Arb.Register<Libraries.TwoUniqueMessages>();

      Prop.ForAll<(Message, Message)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}