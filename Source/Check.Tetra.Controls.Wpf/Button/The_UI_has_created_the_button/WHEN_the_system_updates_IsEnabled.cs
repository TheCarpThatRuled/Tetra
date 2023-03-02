using Check.Check_Button;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;

namespace Check.Button.The_UI_has_created_the_button;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_system_updates_IsEnabled : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_IsEnabled]
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

      foreach (var initialIsEnabled in TrueAndFalse)
      foreach (var updatedIsEnabled in TrueAndFalse)
      {
         yield return GIVEN
                     .The_UI_has_created_the_button(The_UI_creates_a_button
                                                   .Factory()
                                                   .IsEnabled_is(initialIsEnabled)
                                                   .Visibility_is_visible())
                     .WHEN()
                     .The_system_updates_IsEnabled(updatedIsEnabled)
                     .THEN()
                     .The_button.Is_displayed(Expected_button
                                             .Factory()
                                             .IsEnabled_is(updatedIsEnabled)
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