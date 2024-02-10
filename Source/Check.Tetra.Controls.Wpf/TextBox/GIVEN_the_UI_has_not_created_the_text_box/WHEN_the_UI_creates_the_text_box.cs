using Check.Check_Text_Box;
using static Check.Data;
using static Check.Check_Text_Box.Steps;
using static Check.TextBox.Text;

namespace Check.TextBox.GIVEN_the_UI_has_not_created_the_text_box;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_UI_creates_the_text_box : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_UI_creates_the_text_box]
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

      foreach (var isEnabled in True_and_false)
      foreach (var text in Representative_text)
      foreach (var visibility in Visibilities)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_not_created_the_text_box())
                     .WHEN(The_UI.Creates_the_text_box(The_UI_creates_a_text_box
                                                      .Factory()
                                                      .Text_is(text)
                                                      .IsEnabled_is(isEnabled)
                                                      .Visibility_is(visibility.tetra)))
                     .THEN(The_text_box.Matches(Expected_text_box
                                               .Factory()
                                               .Text_is(text)
                                               .IsEnabled_is(isEnabled)
                                               .Visibility_is(visibility.wpf)))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}