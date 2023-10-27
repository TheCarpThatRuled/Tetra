using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.OptionEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_none;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_ExpandSomeToLeft : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_ExpandSomeToLeft]
   public void Run
   (
      AAA_test1 test
   )
   {
      using var given = test.Create();
      var       when  = given.Arrange();
      var       then  = when.Act();
      then.Assert();
   }

   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   protected override IEnumerable<AAA_test1> GetTests()
   {
      /* ------------------------------------------------------------ */

      var whenNone      = FakeRight.Create("whenNone Value");
      var externalState = FakeExternalState.Create();

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_ExpandSomeToLeft_with(whenNone))
                  .THEN(the_whenNone.for_ExpandSomeToLeft.was_invoked_once())
                  .And(the_return_value.is_a_right_containing<FakeType, FakeRight>(whenNone))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_ExpandSomeToLeft_with(externalState,
                                                               whenNone))
                  .THEN(the_whenNone.for_ExpandSomeToLeft_with_externalState.was_invoked_once_with(externalState))
                  .And(the_return_value.is_a_right_containing<FakeType, FakeRight>(whenNone))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}