using Check.Check_TextBox;
using static Check.TextBox.Text;
// ReSharper disable InconsistentNaming

namespace Check.TextBox.GIVEN_the_UI_has_created_the_text_box;

[TestClass]
public class WHEN_the_system_updates_Text : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Text]
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

      foreach (var initial_Text in Representative_text)
      foreach (var updated_Text in Representative_text)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_text_box(The_UI_creates_a_text_box
                                                           .Factory()
                                                           .Text_is(initial_Text)
                                                           .IsEnabled_is_enabled()
                                                           .Visibility_is_visible()))
                     .WHEN(The_system.Updates_Text(updated_Text))
                     .THEN(The_text_box.Matches(Expected_text_box
                                               .Factory()
                                               .Text_is(updated_Text)
                                               .IsEnabled_is_enabled()
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