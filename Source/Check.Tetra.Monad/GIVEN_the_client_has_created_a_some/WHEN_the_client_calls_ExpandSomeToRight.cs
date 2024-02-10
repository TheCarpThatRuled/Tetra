using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.OptionEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_some;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_ExpandSomeToRight : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_ExpandSomeToRight]
   public void Run
   (
      AAA_test test
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

   protected override IEnumerable<AAA_test> GetTests()
   {
      /* ------------------------------------------------------------ */

      var content       = FakeType.Create("content");
      var externalState = FakeExternalState.Create();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_ExpandSomeToRight_with(FakeLeft.Create("whenNone Value")))
                  .THEN(the_whenNone.for_ExpandSomeToRight.was_not_invoked())
                  .And(the_return_value.is_a_right_containing<FakeLeft, FakeType>(content))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_ExpandSomeToRight_with(externalState,
                                                                FakeLeft.Create("whenNone Value")))
                  .THEN(the_whenNone.for_ExpandSomeToRight_with_externalState.was_not_invoked())
                  .And(the_return_value.is_a_right_containing<FakeLeft, FakeType>(content))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}