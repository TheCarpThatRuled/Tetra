using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_some;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Map : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Map]
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

      var content  = FakeType.Create("content");
      var whenSome = FakeNewType.Create("whenSome");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_Map_with(whenSome))
                  .THEN(the_whenSome_Func.was_invoked_once_with<FakeType, FakeNewType, MapWasCalled.Asserts>(content))
                  .And(the_return_value.is_a_some_containing<FakeNewType, MapWasCalled.Asserts>(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_Map_with(externalState,
                                                  whenSome))
                  .THEN(the_whenSome_Func.was_invoked_once_with<FakeExternalState, FakeType, FakeNewType, MapWasCalledWithExternalState.Asserts>(
                           externalState,
                           content))
                  .And(the_return_value.is_a_some_containing<FakeNewType, MapWasCalledWithExternalState.Asserts>(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}