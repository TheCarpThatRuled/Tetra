﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.OptionEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_none;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Unify : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Unify]
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

      var whenNone = FakeNewType.Create("whenNone value");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Unify_with(FakeNewType.Create("whenSome value"),
                                                    whenNone))
                  .THEN(the_whenNone.for_Unify.was_invoked_once())
                  .And(the_whenSome.for_Unify.was_not_invoked())
                  .And(the_return_value.is_equal_to(whenNone))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Unify_with(externalState,
                                                    FakeNewType.Create("whenSome value"),
                                                    whenNone))
                  .THEN(the_whenNone.for_Unify_with_externalState.was_invoked_once_with(externalState))
                  .And(the_whenSome.for_Unify_with_externalState.was_not_invoked())
                  .And(the_return_value.is_equal_to(whenNone))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}