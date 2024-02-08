using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed partial class Actions : TestEnvironment<Actions, Asserts>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private IActions _actions;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Actions()
      => _actions = new HasNotBeenCreated(this,
                                          actions => _actions = actions);

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Actions Start()
      => new();

   /* ------------------------------------------------------------ */
   // Protected Overridden TestEnvironment<Actions, Asserts> Methods
   /* ------------------------------------------------------------ */

   protected override Asserts CreateAsserts()
      => _actions
        .Asserts();

   /* ------------------------------------------------------------ */

   protected override Actions PerformFinalise()
      => this;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public TwoWayBindingActions<object, Actions> Content
      => _actions
        .Content;

   /* ------------------------------------------------------------ */

   public TwoWayBindingActions<Visibility, Actions> Visibility
      => _actions
        .Visibility;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CreateLabel
   (
      The_UI_creates_a_label args
   )
   {
      _actions.CreateLabel(args);

      return this;
   }

   /* ------------------------------------------------------------ */
}