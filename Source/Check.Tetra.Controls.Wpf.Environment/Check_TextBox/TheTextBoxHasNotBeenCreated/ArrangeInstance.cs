using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasNotBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TheTextBoxHasBeenCreated.ArrangeInstance The_UI_creates_the_text_box(The_UI_creates_a_text_box args)
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
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance() { }

      /* ------------------------------------------------------------ */
   }
}