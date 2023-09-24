using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
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

      var content       = FakeType.Create("content");
      var whenSome      = FakeNewType.Create("whenSome Value");
      var externalState = FakeExternalState.Create();

      /* ------------------------------------------------------------ */
      // Map T => TNew
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.on_the_option.calls_Map_with(whenSome))
                  .THEN(the_whenSome.for_Map.was_invoked_once_with(content))
                  .And(the_return_value.for_option.Map.is_a_some_containing(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.on_the_option.calls_Map_with(externalState,
                                                  whenSome))
                  .THEN(the_whenSome.for_Map_with_externalState.was_invoked_once_with(externalState,
                                                                                             content))
                  .And(the_return_value.for_option.Map_with_externalState.is_a_some_containing(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var someWhenSome = Option.Some(whenSome);
      var noneWhenSome = Option<FakeNewType>.None();

      /* ------------------------------------------------------------ */
      // Map T => IOption<TNew>
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.on_the_option.calls_Map_with(someWhenSome))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption.was_invoked_once_with(content))
                  .And(the_return_value.for_option.Map_with_func_to_IOption.is_a_some_containing(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.on_the_option.calls_Map_with(noneWhenSome))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption.was_invoked_once_with(content))
                  .And(the_return_value.for_option.Map_with_func_to_IOption.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.on_the_option.calls_Map_with(externalState,
                                                  someWhenSome))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption_and_externalState.was_invoked_once_with(externalState,
                                                                                                                 content))
                  .And(the_return_value.for_option.Map_with_func_to_IOption_and_externalState.is_a_some_containing(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.on_the_option.calls_Map_with(externalState,
                                                  noneWhenSome))
                  .THEN(the_whenSome.for_Map_with_func_to_IOption_and_externalState.was_invoked_once_with(externalState,
                                                                                                                 content))
                  .And(the_return_value.for_option.Map_with_func_to_IOption_and_externalState.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}