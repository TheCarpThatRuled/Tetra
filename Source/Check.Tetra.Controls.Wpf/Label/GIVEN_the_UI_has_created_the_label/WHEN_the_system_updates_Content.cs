using Check.Check_Label;
using static Check.Check_Label.Steps;
using static Check.Label.Contents;

// ReSharper disable InconsistentNaming

namespace Check.Label.GIVEN_the_UI_has_created_the_label;

[TestClass]
public class WHEN_the_system_updates_Content : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_system_updates_Content]
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

      foreach (var initial_Content in Representative_contents)
      foreach (var updated_Content in Representative_contents)
      {
         yield return AAA_test
                     .GIVEN(The_UI.Has_created_the_label(The_UI_creates_a_label
                                                        .Factory()
                                                        .Content_is(initial_Content)
                                                        .Visibility_is_visible()))
                     .WHEN(The_system.Updates_Content(updated_Content))
                     .THEN(The_label.Matches(Expected_label
                                            .Factory()
                                            .Content_is(updated_Content)
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