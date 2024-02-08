using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly ButtonAsserts<Asserts>                    Button;
   public readonly TwoWayBindingAsserts<bool, Asserts>       IsEnabled;
   public readonly ActionAsserts<Asserts>                    OnClick;
   public readonly TwoWayBindingAsserts<Visibility, Asserts> Visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Asserts
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
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Asserts Create
   (
      FakeButton button,
      FakeSystem system
   )
      => new(button,
             system);

   /* ------------------------------------------------------------ */
}