﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.OptionEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_some;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_GetHashCode : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_GetHashCode]
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

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_some_from(default!))
                  .WHEN(the_Client.calls_GetHashCode())
                  .THEN(the_return_value.is_equal_to(0))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      foreach (var content in new[] {FakeType.Create(""), FakeType.Create("1"), FakeType.Create("2"), FakeType.Create("3"), FakeType.Create("Content"),})
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(the_Client.has_created_a_some_from(content))
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