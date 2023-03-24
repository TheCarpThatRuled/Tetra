using Check.Check_Button;
using static Check.Data;
// ReSharper disable InconsistentNaming

namespace Check.Button.GIVEN_the_UI_has_not_created_the_button;

[TestClass]
public class WHEN_the_UI_creates_the_button : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_UI_creates_the_button]
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

      foreach (var isEnabled in True_and_false)
      foreach (var visibility in Visibilities)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_not_created_the_button())
                     .WHEN(The_UI.Creates_the_button(The_UI_creates_a_button
                                                    .Factory()
                                                    .IsEnabled_is(isEnabled)
                                                    .Visibility_is(visibility.tetra)))
                     .THEN(The_button.Matches(Expected_button
                                             .Factory()
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