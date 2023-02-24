using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_MapFailure
{
   /* ------------------------------------------------------------ */
   // IResult<T> MapFailure(Func<Failure, Message> whenFailure)
   /* ------------------------------------------------------------ */

   //GIVEN
   //int
   //WHEN
   //MapFailure_AND_whenFailure_is_a_Func_of_Failure_to_Message
   //THEN
   //whenFailure_was_not_invoked_AND_this_is_returned

   [TestMethod]
   public void
      GIVEN_int_WHEN_MapFailure_AND_whenFailure_is_a_Func_of_Failure_to_Message_THEN_whenFailure_was_not_invoked_AND_this_is_returned()
   {
      static Property Property(int     content,
                               Message whenFailure)
      {
         //Arrange
         var whenFailureFunc = FakeFunction<Failure, Message>.Create(whenFailure);

         var result = Result.Success(content);

         //Act
         var actual = result.MapFailure(whenFailureFunc.Func);

         //Assert
         return AreReferenceEqual(AssertMessages.ReturnValue,
                                  result,
                                  actual)
           .And(WasNotInvoked(nameof(whenFailure),
                              whenFailureFunc));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<int, Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}