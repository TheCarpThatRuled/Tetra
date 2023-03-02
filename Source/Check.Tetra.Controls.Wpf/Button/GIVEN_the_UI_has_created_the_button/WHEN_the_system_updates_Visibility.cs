using Check.Check_Button;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;

namespace Check.Button.GIVEN_the_UI_has_created_the_button;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_system_updates_Visibility : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Visibility]
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

      foreach (var (initialVisibility, _) in Visibilities)
      foreach (var updatedVisibility in Visibilities)
      {
         yield return GIVEN
                     .The_UI_has_created_the_button(The_UI_creates_a_button
                                                   .Factory()
                                                   .IsEnabled_is_enabled()
                                                   .Visibility_is(initialVisibility))
                     .WHEN()
                     .The_system_updates_Visibility(updatedVisibility.tetra)
                     .THEN()
                     .The_button.Is_displayed(Expected_button
                                             .Factory()
                                             .IsEnabled_is_enabled()
                                             .Visibility_is(updatedVisibility.wpf))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}