using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.EitherEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_left;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Map : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Map]
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

      var content       = FakeLeft.Create("content");
      var externalState = FakeExternalState.Create();

      var whenLeft  = FakeNewLeft.Create("whenLeft Value");
      var whenRight = FakeNewRight.Create("whenRight value");

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.calls_Map_with(whenLeft,
                                                  whenRight))
                  .THEN(the_whenLeft.for_Map.was_invoked_once_with(content))
                  .And(the_whenRight.for_Map.was_not_invoked())
                  .And(the_return_value.is_a_left_containing<FakeNewLeft, FakeNewRight>(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.calls_Map_with(externalState,
                                                  whenLeft,
                                                  whenRight))
                  .THEN(the_whenLeft.for_Map_with_externalState.was_invoked_once_with(externalState,
                                                                                      content))
                  .And(the_whenRight.for_Map_with_externalState.was_not_invoked())
                  .And(the_return_value.is_a_left_containing<FakeNewLeft, FakeNewRight>(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}