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
      // Map T => TNew
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.on_the_option.calls_Map_with(FakeNewType.Create("whenSome value")))
                  .THEN(the_whenSome.for_Map.was_not_invoked())
                  .And(the_return_value.for_option.Map.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.on_the_option.calls_Map_with(FakeExternalState.Create(),
                                                  FakeNewType.Create("whenSome value")))
                  .THEN(the_whenSome.for_Map_with_externalState.was_not_invoked())
                  .And(the_return_value.for_option.Map_with_externalState.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */
      // Map T => IOption<TNew>
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.on_the_option.calls_Map_with(Option.Some(FakeNewType.Create("whenSome value"))))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption.was_not_invoked())
                  .And(the_return_value.for_option.Map_with_func_to_IOption.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.on_the_option.calls_Map_with(Option<FakeNewType>.None()))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption.was_not_invoked())
                  .And(the_return_value.for_option.Map_with_func_to_IOption.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.on_the_option.calls_Map_with(FakeExternalState.Create(),
                                                  Option.Some(FakeNewType.Create("whenSome value"))))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption_and_externalState.was_not_invoked())
                  .And(the_return_value.for_option.Map_with_func_to_IOption_and_externalState.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.on_the_option.calls_Map_with(FakeExternalState.Create(),
                                                  Option<FakeNewType>.None()))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption_and_externalState.was_not_invoked())
                  .And(the_return_value.for_option.Map_with_func_to_IOption_and_externalState.is_a_none())
                  .Crystallise();

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}