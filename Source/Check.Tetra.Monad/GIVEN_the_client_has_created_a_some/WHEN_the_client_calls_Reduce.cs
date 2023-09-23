using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_some;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Reduce : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Reduce]
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
      var whenSome = FakeNewType.Create("whenSome value");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_Reduce_with(whenSome,
                                                     FakeNewType.Create("whenNone value")))
                  .THEN(the_whenNone.for_Option.Reduce.was_not_invoked())
                  .And(the_whenSome.for_Option.Reduce.was_invoked_once_with(content))
                  .And(the_return_value.for_Option.Reduce.is_equal_to(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(content))
                  .WHEN(the_Client.calls_Reduce_with(externalState,
                                                     whenSome,
                                                     FakeNewType.Create("whenNone value")))
                  .THEN(the_whenNone.for_Option.Reduce_with_externalState.was_not_invoked())
                  .And(the_whenSome.for_Option.Reduce_with_externalState.was_invoked_once_with(externalState,
                                                                                               content))
                  .And(the_return_value.for_Option.Reduce_with_externalState.is_equal_to(whenSome))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}