using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.OptionEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_some;

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

      var content       = FakeType.Create("content");
      var externalState = FakeExternalState.Create();

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_ExpandSomeToLeft_with(FakeRight.Create("whenNone Value")))
                  .THEN(the_whenNone.for_ExpandSomeToLeft.was_not_invoked())
                  .And(the_return_value.is_a_left_containing<FakeType, FakeRight>(content))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_ExpandSomeToLeft_with(externalState,
                                                               FakeRight.Create("whenNone Value")))
                  .THEN(the_whenNone.for_ExpandSomeToLeft_with_externalState.was_not_invoked())
                  .And(the_return_value.is_a_left_containing<FakeType, FakeRight>(content))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}