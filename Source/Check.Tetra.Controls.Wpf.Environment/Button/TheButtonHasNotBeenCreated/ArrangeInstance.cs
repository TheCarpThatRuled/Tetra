using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check;

public sealed partial class TheButtonHasNotBeenCreated
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

      public TheButtonHasBeenCreated.ArrangeInstance The_UI_developer_creates_the_button(The_UI_creates_a_button theUiCreatesAButton)
         => new(FakeButton.Create(ButtonContext.Create(Button.Factory())));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance() { }

      /* ------------------------------------------------------------ */
   }
}