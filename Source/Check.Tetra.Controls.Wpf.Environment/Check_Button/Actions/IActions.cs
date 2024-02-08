using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

partial class Actions
{
   private interface IActions
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ButtonActions<Actions> Button { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts();

      /* ------------------------------------------------------------ */

      public void CreateButton
      (
         The_UI_creates_a_button args
      );

      /* ------------------------------------------------------------ */
   }
}