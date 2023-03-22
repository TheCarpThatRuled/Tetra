using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasNotBeenCreated
{
   public sealed class Acts : IActs
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<TheTextBoxHasBeenCreated.Asserts> The_UI_creates_the_text_box(The_UI_creates_a_text_box args)
         => new(() => Create_the_text_box(args));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Acts() { }

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private TheTextBoxHasBeenCreated.Asserts Create_the_text_box(The_UI_creates_a_text_box args)
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
   }
}