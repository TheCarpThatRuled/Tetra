using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

partial class Actions
{
   private sealed class HasBeenCreated : IActions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _button;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      private HasBeenCreated
      (
         FakeButton button,
         Actions    parent,
         FakeSystem system
      )
      {
         _button = button;
         _system = system;

         Button = ButtonActions<Actions>.Create("Button",
                                                button,
                                                () => parent);

         IsEnabled = TwoWayBindingActions<bool, Actions>.Create("IsEnabled",
                                                                system.IsEnabled(),
                                                                () => parent);

         Visibility = TwoWayBindingActions<Visibility, Actions>.Create("Visibility",
                                                                       system.Visibility(),
                                                                       () => parent);
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static HasBeenCreated Create
      (
         Actions    parent,
         FakeButton button,
         FakeSystem system
      )
         => new(button,
                parent,
                system);

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public ButtonActions<Actions> Button { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => Check_Button
           .Asserts
           .Create(_button,
                   _system);

      /* ------------------------------------------------------------ */

      public void CreateButton
      (
         The_UI_creates_a_button args
      )
         => throw Failed
                 .CannotPerformAnAssert("create the button",
                                        "it has already been created")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */
   }
}