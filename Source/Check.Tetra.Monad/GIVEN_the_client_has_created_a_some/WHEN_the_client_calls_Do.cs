using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_some;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Do : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Do]
   public void Run(AAA_test test)
   {
      using var given = test.Create();
      var       when  = given.Arrange();
      var       then  = when.Act();
      then.Assert();
   }

   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   protected override IEnumerable<AAA_test> GetTests()
   {
      /* ------------------------------------------------------------ */

      var content = FakeType.Create("content");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_Do())
                  .THEN(the_whenNone_Action.was_not_invoked<DoWasCalled.Asserts>())
                  .And(the_whenSome_Action.was_invoked_once_with<FakeType, DoWasCalled.Asserts>(content))
                  .And(the_return_value.is_this<DoWasCalled.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_Do_with(externalState))
                  .THEN(the_whenNone_Action.was_not_invoked<FakeExternalState, DoWasCalledWithExternalState.Asserts>())
                  .And(the_whenSome_Action.was_invoked_once_with<FakeExternalState, FakeType, DoWasCalledWithExternalState.Asserts>(
                          externalState,
                          content))
                  .And(the_return_value.is_this<DoWasCalledWithExternalState.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}