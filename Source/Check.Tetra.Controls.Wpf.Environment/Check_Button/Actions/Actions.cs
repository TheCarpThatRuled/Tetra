using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed partial class Actions
{
   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   public static Actions Start()
      => new();

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

   public Asserts Asserts()
      => _actions
        .Asserts();

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

   public Actions FinishArrange()
   {
      _actions.FinishArrange();

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