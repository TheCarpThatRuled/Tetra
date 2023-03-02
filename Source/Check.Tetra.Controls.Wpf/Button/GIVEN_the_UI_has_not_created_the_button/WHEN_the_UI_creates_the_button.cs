using Check.Check_Button;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;

namespace Check.Button.GIVEN_the_UI_has_not_created_the_button;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_UI_creates_the_button : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_UI_creates_the_button]
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

      foreach (var isEnabled in TrueAndFalse)
      foreach (var visibility in Visibilities)
      {
         yield return GIVEN
                     .The_UI_has_not_created_the_button()
                     .WHEN()
                     .The_UI_creates_the_button(The_UI_creates_a_button
                                               .Factory()
                                               .IsEnabled_is(isEnabled)
                                               .Visibility_is(visibility.tetra))
                     .THEN()
                     .The_button.Is_displayed(Expected_button
                                             .Factory()
                                             .IsEnabled_is(isEnabled)
                                             .Visibility_is(visibility.wpf))
                     .Crystallise();
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}