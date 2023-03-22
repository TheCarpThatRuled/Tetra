using Check.Check_TextBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;
// ReSharper disable InconsistentNaming

namespace Check.TextBox.GIVEN_the_UI_has_created_the_text_box;

[TestClass]
public class WHEN_the_system_updates_Visibility : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Visibility]
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

      foreach (var (initial_Visibility, _) in Visibilities)
      foreach (var updated_Visibility in Visibilities)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_text_box(The_UI_creates_a_text_box
                                                           .Factory()
                                                           .Text_is_default()
                                                           .IsEnabled_is_enabled()
                                                           .Visibility_is(initial_Visibility)))
                     .WHEN(The_system.Updates_Visibility(updated_Visibility.tetra))
                     .THEN(The_text_box.Matches(Expected_text_box
                                               .Factory()
                                               .Text_is_default()
                                               .IsEnabled_is_enabled()
                                               .Visibility_is(updated_Visibility.wpf)))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}