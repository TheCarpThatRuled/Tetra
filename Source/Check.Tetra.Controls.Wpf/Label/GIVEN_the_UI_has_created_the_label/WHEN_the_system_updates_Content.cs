using Check.Check_Label;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;
using static Check.Label.Contents;

namespace Check.Label.GIVEN_the_UI_has_created_the_label;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_system_updates_Content : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Content]
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

      foreach (var initialContent in RepresentativeContents)
      foreach (var updatedContent in RepresentativeContents)
      {
         yield return GIVEN
                     .The_UI_has_created_the_label(The_UI_creates_a_label
                                                  .Factory()
                                                  .Content_is(initialContent)
                                                  .Visibility_is_visible())
                     .WHEN()
                     .The_system_updates_Content(updatedContent)
                     .THEN()
                     .The_label.Is_displayed(Expected_label
                                            .Factory()
                                            .Content_is(updatedContent)
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