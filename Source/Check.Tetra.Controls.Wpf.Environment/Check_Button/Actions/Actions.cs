using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed partial class Actions : TestEnvironment<Actions, Asserts>
{
   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   public static Actions Start()
      => new();

   /* ------------------------------------------------------------ */
   // Protected Overridden TestEnvironment<Actions, Asserts> Methods
   /* ------------------------------------------------------------ */

   protected override Asserts CreateAsserts()
      =>_actions
        .Asserts();

   /* ------------------------------------------------------------ */

   protected override Actions PerformFinalise()
      => this;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ButtonActions<Actions> Button
      => _actions
        .Button;

   /* ------------------------------------------------------------ */

   public TwoWayBindingActions<bool, Actions> IsEnabled
      => _actions
        .IsEnabled;

   /* ------------------------------------------------------------ */

   public TwoWayBindingActions<Visibility, Actions> Visibility
      => _actions
        .Visibility;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CreateButton
   (
      The_UI_creates_a_button args
   )
   {
      _actions.CreateButton(args);

      return this;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private IActions _actions;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Actions()
      => _actions = HasNotBeenCreated.Create(this,
                                             actions => _actions = actions);

   /* ------------------------------------------------------------ */
}