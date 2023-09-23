using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_none;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_ExpandSomeToRight : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_ExpandSomeToRight]
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

      var whenNone      = FakeLeft.Create("whenNone Value");
      var externalState = FakeExternalState.Create();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_ExpandSomeToRight_with(whenNone))
                  .THEN(the_whenNone.for_Option.ExpandSomeToRight.was_invoked_once())
                  .And(the_return_value.for_Option.ExpandSomeToRight.is_a_left_containing(whenNone))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_ExpandSomeToRight_with(externalState,
                                                                whenNone))
                  .THEN(the_whenNone.for_Option.ExpandSomeToRight_with_externalState.was_invoked_once_with(externalState))
                  .And(the_return_value.for_Option.ExpandSomeToRight_with_externalState.is_a_left_containing(whenNone))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}