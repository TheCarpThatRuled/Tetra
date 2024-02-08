using Tetra;
using Tetra.Testing;

namespace Check.Check_Text_Box;

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

   public TwoWayBindingActions<bool, Actions> IsEnabled
      => _actions
        .IsEnabled;

   /* ------------------------------------------------------------ */

   public TwoWayBindingActions<string, Actions> Text
      => _actions
        .Text;

   /* ------------------------------------------------------------ */

   public TextBoxActions<Actions> TextBox
      => _actions
        .TextBox;

   /* ------------------------------------------------------------ */

   public TwoWayBindingActions<Visibility, Actions> Visibility
      => _actions
        .Visibility;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CreateTextBox
   (
      The_UI_creates_a_text_box args
   )
   {
      _actions.CreateTextBox(args);

      return this;
   }

   /* ------------------------------------------------------------ */
}