﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_none;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Do : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Do]
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
                  .WHEN(the_Client.calls_Do())
                  .THEN(the_whenNone.for_Option.Do.was_invoked_once())
                  .And(the_whenSome.for_Option.Do.was_not_invoked())
                  .And(the_return_value.for_Option.Do.is_this())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_none())
                  .WHEN(the_Client.calls_Do_with(externalState))
                  .THEN(the_whenNone.for_Option.Do_with_externalState.was_invoked_once_with(externalState))
                  .And(the_whenSome.for_Option.Do_with_externalState.was_not_invoked())
                  .And(the_return_value.for_Option.Do_with_externalState.is_this())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}