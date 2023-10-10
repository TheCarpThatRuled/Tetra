using Check.Check_Button;

// ReSharper disable InconsistentNaming

namespace Check.Button.GIVEN_the_button_is_enabled_and_visible;

[TestClass]
public class WHEN_the_user_clicks_the_button : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_user_clicks_the_button]
   public void Run
   (
      AAA_test test
   )
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

      foreach (var number_of_clicks in Enumerable
                                      .Range(1,
                                             10)
                                      .Select(x => (uint) x))
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_button(Buttons.Create_enabled_and_visible))
                     .WHEN(The_user.Clicks_the_button(number_of_clicks))
                     .THEN(The_button.Matches(Buttons.Enabled_and_visible))
                     .And(The_Click_callback.Was_invoked(number_of_clicks))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}