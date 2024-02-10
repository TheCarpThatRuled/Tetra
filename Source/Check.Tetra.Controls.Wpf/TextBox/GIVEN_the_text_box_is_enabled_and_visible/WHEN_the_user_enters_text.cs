using static Check.Check_Text_Box.Steps;
using static Check.TextBox.Text;

// ReSharper disable InconsistentNaming

namespace Check.TextBox.GIVEN_the_text_box_is_enabled_and_visible;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_user_enters_text : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_user_enters_text]
   public void Run
   (
      AAA_test test
   )
   {
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

      foreach (var initial_text in Representative_text)
      foreach (var updated_text in Representative_text)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_text_box(Text_boxes.Create_enabled_and_visible(initial_text)))
                     .WHEN(The_user.Enters_text(updated_text))
                     .THEN(The_text_box.Matches(Text_boxes.Enabled_and_visible(updated_text)))
                     .And(The_system.Text_is(updated_text))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}