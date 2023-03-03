using Check.Check_TextBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.TextBox.Text;

namespace Check.TextBox.GIVEN_the_text_box_is_enabled_and_visible;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_user_enters_text : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_user_enters_text]
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

      foreach (var initialText in RepresentativeText)
      foreach (var updatedText in RepresentativeText)
      {
         yield return GIVEN
                     .The_UI_has_created_the_text_box(Text_boxes.Create_enabled_and_visible(initialText))
                     .WHEN()
                     .The_user_enters_text(updatedText)
                     .THEN()
                     .The_text_box.Is_displayed(Text_boxes.Enabled_and_visible(updatedText))
                     .And()
                     .The_system_Text_is(updatedText)
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}