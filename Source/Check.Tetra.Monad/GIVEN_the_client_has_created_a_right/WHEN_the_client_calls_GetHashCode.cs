﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.EitherEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_right;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_GetHashCode : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_GetHashCode]
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
                  .GIVEN(the_Client.has_created_a_right_from(default!))
                  .WHEN(the_Client.calls_GetHashCode())
                  .THEN(the_return_value.is_equal_to(0))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      foreach (var content in new[] {FakeRight.Create(""), FakeRight.Create("1"), FakeRight.Create("2"), FakeRight.Create("3"), FakeRight.Create("Content"),})
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test1
                     .GIVEN(the_Client.has_created_a_right_from(content))
                     .WHEN(the_Client.calls_GetHashCode())
                     .THEN(the_return_value.is_equal_to(content.GetHashCode()))
                     .Crystallise();

         /* ------------------------------------------------------------ */
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}