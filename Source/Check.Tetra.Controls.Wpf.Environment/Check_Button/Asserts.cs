using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Asserts
   (
      FakeButton button,
      FakeSystem system
   )
   {
      Button = ButtonAsserts<Asserts>.Create("Button",
                                             button,
                                             () => this);

      IsEnabled = TwoWayBindingAsserts<bool, Asserts>.Create("IsEnabled",
                                                             system.IsEnabled(),
                                                             () => this);

      OnClick = ActionAsserts<Asserts>.Create("OnClick",
                                              system.OnClick(),
                                              () => this);

      Visibility = TwoWayBindingAsserts<Visibility, Asserts>.Create("Visibility",
                                                                    system.Visibility(),
                                                                    () => this);
   }

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ButtonAsserts<Asserts> Button { get; }

   /* ------------------------------------------------------------ */

   public TwoWayBindingAsserts<bool, Asserts> IsEnabled { get; }

   /* ------------------------------------------------------------ */

   public ActionAsserts<Asserts> OnClick { get; }

   /* ------------------------------------------------------------ */

   public TwoWayBindingAsserts<Visibility, Asserts> Visibility { get; }

   /* ------------------------------------------------------------ */
}