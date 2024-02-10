using Check.Check_Label;
using static Check.Data;
using static Check.Check_Label.Steps;

using static Check.Label.Contents;

// ReSharper disable InconsistentNaming

namespace Check.Label.GIVEN_the_UI_has_not_created_the_label;

[TestClass]
public class WHEN_the_UI_creates_the_label : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_UI_creates_the_label]
   public void Run
   (
      AAA_test test
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

   protected override IEnumerable<AAA_test> GetTests()
   {
      /* ------------------------------------------------------------ */

      foreach (var content in Representative_contents)
      foreach (var visibility in Visibilities)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_not_created_the_label())
                     .WHEN(The_UI.Creates_the_label(The_UI_creates_a_label
                                                   .Factory()
                                                   .Content_is(content)
                                                   .Visibility_is(visibility.tetra)))
                     .THEN(The_label.Matches(Expected_label
                                            .Factory()
                                            .Content_is(content)
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