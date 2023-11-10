using static Check.Check_Button.Steps;

// ReSharper disable InconsistentNaming

namespace Check.Button.GIVEN_the_button_is_enabled_and_visible;

[TestClass]
public class WHEN_the_user_clicks_the_button : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_user_clicks_the_button]
   public void Run
   (
      AAA_test1 test
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

   protected override IEnumerable<AAA_test1> GetTests()
   {
      /* ------------------------------------------------------------ */

      foreach (var number_of_clicks in Enumerable
                                      .Range(1,
                                             10)
                                      .Select(x => (uint) x))
      {
         yield return AAA_test1
                     .GIVEN(The_UI.has_created_the_button(Buttons.Create_enabled_and_visible))
                     .WHEN(The_user.clicks_the_button(number_of_clicks))
                     .THEN(The_button.matches(Buttons.Enabled_and_visible))
                     .And(The_Click_callback.was_invoked(number_of_clicks))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}