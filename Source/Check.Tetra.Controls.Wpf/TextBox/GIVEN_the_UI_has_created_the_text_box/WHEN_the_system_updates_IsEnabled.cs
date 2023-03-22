using Check.Check_TextBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;
// ReSharper disable InconsistentNaming

namespace Check.TextBox.GIVEN_the_UI_has_created_the_text_box;

[TestClass]
public class WHEN_the_system_updates_IsEnabled : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_IsEnabled]
   public void Run(AAA_test test)
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

   protected override IEnumerable<AAA_test> GetTests()
   {
      /* ------------------------------------------------------------ */

      foreach (var initial_IsEnabled in True_and_false)
      foreach (var updated_IsEnabled in True_and_false)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_text_box(The_UI_creates_a_text_box
                                                           .Factory()
                                                           .Text_is_default()
                                                           .IsEnabled_is(initial_IsEnabled)
                                                           .Visibility_is_visible()))
                     .WHEN(The_system.Updates_IsEnabled(updated_IsEnabled))
                     .THEN(The_text_box.Matches(Expected_text_box
                                               .Factory()
                                               .Text_is_default()
                                               .IsEnabled_is(updated_IsEnabled)
                                               .Visibility_is_visible()))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}