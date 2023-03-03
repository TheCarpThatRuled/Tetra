﻿using Check.Check_Button;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;

namespace Check.Button.GIVEN_the_button_is_enabled_and_visible;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_user_clicks_the_button : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_user_clicks_the_button]
   public void Run(AAATest test)
   {
      Log.ToStandardOutput(test.FullCharacterisation());

      using var given = test.Create();

      var when = given.Arrange();

      var then = when.Act();

      then.Assert();
   }

   /* ------------------------------------------------------------ */
   // Overridden AAATestDataSource Methods
   /* ------------------------------------------------------------ */

   protected override IEnumerable<AAATest> GetTests()
   {
      /* ------------------------------------------------------------ */

      foreach (var numberOfClicks in Enumerable
                                    .Range(1,
                                           10)
                                    .Select(x => (uint) x))
      {
         yield return GIVEN
                     .The_UI_has_created_the_button(Buttons.Create_enabled_and_visible)
                     .WHEN()
                     .The_user_clicks_the_button(numberOfClicks)
                     .THEN()
                     .The_button.Is_displayed(Buttons.Enabled_and_visible)
                     .And()
                     .The_Click_callback_was_invoked(numberOfClicks)
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}