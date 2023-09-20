using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_none;

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

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Map_with(FakeNewType.Create("whenSome value")))
                  .THEN(the_whenSome_Func.was_not_invoked<FakeType, FakeNewType, MapWasCalled.Asserts>())
                  .And(the_return_value.is_a_none<FakeNewType, MapWasCalled.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Map_with(FakeExternalState.Create(),
                                                  FakeNewType.Create("whenSome value")))
                  .THEN(the_whenSome_Func.was_not_invoked<FakeExternalState, FakeType, FakeNewType, MapWasCalledWithExternalState.Asserts>())
                  .And(the_return_value.is_a_none<FakeNewType, MapWasCalledWithExternalState.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Map_with(Option.Some(FakeNewType.Create("whenSome value"))))
                  .THEN(the_whenSome_Func.was_not_invoked<FakeType, IOption<FakeNewType>, MapToOptionWasCalled.Asserts>())
                  .And(the_return_value.is_a_none<FakeNewType, MapToOptionWasCalled.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Map_with(Option<FakeNewType>.None()))
                  .THEN(the_whenSome_Func.was_not_invoked<FakeType, IOption<FakeNewType>, MapToOptionWasCalled.Asserts>())
                  .And(the_return_value.is_a_none<FakeNewType, MapToOptionWasCalled.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Map_with(FakeExternalState.Create(),
                                                  Option.Some(FakeNewType.Create("whenSome value"))))
                  .THEN(the_whenSome_Func.was_not_invoked<FakeExternalState, FakeType, IOption<FakeNewType>, MapToOptionWasCalledWithExternalState.Asserts>())
                  .And(the_return_value.is_a_none<FakeNewType, MapToOptionWasCalledWithExternalState.Asserts>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Map_with(FakeExternalState.Create(),
                                                  Option<FakeNewType>.None()))
                  .THEN(the_whenSome_Func.was_not_invoked<FakeExternalState, FakeType, IOption<FakeNewType>, MapToOptionWasCalledWithExternalState.Asserts>())
                  .And(the_return_value.is_a_none<FakeNewType, MapToOptionWasCalledWithExternalState.Asserts>())
                  .Crystallise();

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}