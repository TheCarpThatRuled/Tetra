using Check.Check_Label;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Data;
using static Check.Label.Contents;

namespace Check.Label.GIVEN_the_UI_has_not_created_the_label;

[TestClass]
// ReSharper disable once InconsistentNaming
public class WHEN_the_UI_creates_the_label : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_UI_creates_the_label]
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

      foreach (var content in RepresentativeContents)
      foreach (var visibility in Visibilities)
      {
         yield return GIVEN
                     .The_UI_has_not_created_the_label()
                     .WHEN()
                     .The_UI_creates_the_label(The_UI_creates_a_label
                                              .Factory()
                                              .Content_is(content)
                                              .Visibility_is(visibility.tetra))
                     .THEN()
                     .The_label.Is_displayed(Expected_label
                                            .Factory()
                                            .Content_is(content)
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