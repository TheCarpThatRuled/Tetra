using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_right;

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

      var content = FakeRight.Create("content");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Do())
                  .THEN(the_whenLeft.for_Do.was_not_invoked())
                  .And(the_whenRight.for_Do.was_invoked_once_with(content))
                  .And(the_return_value.for_either.Do.is_this())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Do_with(externalState))
                  .THEN(the_whenLeft.for_Do_with_externalState.was_not_invoked())
                  .And(the_whenRight.for_Do_with_externalState.was_invoked_once_with(externalState,
                                                                                     content))
                  .And(the_return_value.for_either.Do_with_externalState.is_this())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}