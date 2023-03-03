using Check.Check_TextBox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.TextBox.Text;

namespace Check.TextBox.GIVEN_the_UI_has_created_the_text_box;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_system_updates_Text : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Text]
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
                     .The_UI_has_created_the_text_box(The_UI_creates_a_text_box
                                                     .Factory()
                                                     .Text_is(initialText)
                                                     .IsEnabled_is_enabled()
                                                     .Visibility_is_visible())
                     .WHEN()
                     .The_system_updates_Text(updatedText)
                     .THEN()
                     .The_text_box.Is_displayed(Expected_text_box
                                               .Factory()
                                               .Text_is(updatedText)
                                               .IsEnabled_is_enabled()
                                               .Visibility_is_visible())
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}