using Check.Check_Button;
using static Check.Data;
using static Check.Check_Button.Steps;


// ReSharper disable InconsistentNaming

namespace Check.Button.GIVEN_the_UI_has_created_the_button;

[TestClass]
public class WHEN_the_system_updates_Visibility : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Visibility]
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

      foreach (var (initial_Visibility, _) in Visibilities)
      foreach (var updated_Visibility in Visibilities)
      {
         yield return AAA_test1
                     .GIVEN(The_UI.has_created_the_button(The_UI_creates_a_button
                                                         .Factory()
                                                         .IsEnabled_is_enabled()
                                                         .Visibility_is(initial_Visibility)))
                     .WHEN(The_system.updates_Visibility(updated_Visibility.tetra))
                     .THEN(The_button.matches(Expected_button
                                             .Factory()
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