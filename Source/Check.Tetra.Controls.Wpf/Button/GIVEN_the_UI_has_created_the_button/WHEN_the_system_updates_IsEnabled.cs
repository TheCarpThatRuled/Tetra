using Check.Check_Button;
using static Check.Data;

// ReSharper disable InconsistentNaming

namespace Check.Button.GIVEN_the_UI_has_created_the_button;

[TestClass]
public class WHEN_the_system_updates_IsEnabled : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_IsEnabled]
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

      foreach (var initial_IsEnabled in True_and_false)
      foreach (var updated_IsEnabled in True_and_false)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_button(The_UI_creates_a_button
                                                         .Factory()
                                                         .IsEnabled_is(initial_IsEnabled)
                                                         .Visibility_is_visible()))
                     .WHEN(The_system.Updates_IsEnabled(updated_IsEnabled))
                     .THEN(The_button.Matches(Expected_button
                                             .Factory()
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