﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.EitherEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_right;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_ReduceLeftToOption : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_ReduceLeftToOption]
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

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_right_from(FakeRight.Create("Content")))
                  .WHEN(the_Client.calls_ReduceLeftToOption())
                  .THEN(the_return_value.is_a_none<FakeLeft>())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}