﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_left;

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

      var content  = FakeLeft.Create("content");
      var whenLeft = FakeNewType.Create("whenLeft value");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Reduce_with(whenLeft,
                                                                   FakeNewType.Create("whenRight value")))
                  .THEN(the_whenLeft.for_Reduce.was_invoked_once_with(content))
                  .And(the_whenRight.for_Reduce.was_not_invoked())
                  .And(the_return_value.for_either.Reduce.is_equal_to(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var externalState = FakeExternalState.Create();

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Reduce_with(externalState,
                                                                   whenLeft,
                                                                   FakeNewType.Create("whenRight value")))
                  .THEN(the_whenLeft.for_Reduce_with_externalState.was_invoked_once_with(externalState,
                                                                                         content))
                  .And(the_whenRight.for_Reduce_with_externalState.was_not_invoked())
                  .And(the_return_value.for_either.Reduce_with_externalState.is_equal_to(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}