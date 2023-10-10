using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasNotBeenCreated
{
   public sealed class Arranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Arranges() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TheTextBoxHasBeenCreated.Arranges The_UI_creates_the_text_box
      (
         The_UI_creates_a_text_box args
      )
      {
         var system = FakeSystem.Create(args);
         return new(FakeTextBox.Create(TextBoxContext.Create(TextBox
                                                            .Factory()
                                                            .Text(system.Text())
                                                            .IsEnabled(system.IsEnabled())
                                                            .Visibility(system.Visibility()))),
                    system);
      }

      /* ------------------------------------------------------------ */

      public Acts WHEN()
         => new();

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Arranges Create
      (
         AAA_test.Disposables _
      )
         => new();

      /* ------------------------------------------------------------ */
   }
}