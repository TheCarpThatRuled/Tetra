using Tetra;
using Tetra.Testing;

namespace Check.Check_Text_Box;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Field
   /* ------------------------------------------------------------ */

   public readonly TwoWayBindingAsserts<bool, Asserts>       IsEnabled;
   public readonly TwoWayBindingAsserts<string, Asserts>     Text;
   public readonly TextBoxAsserts<Asserts>                   TextBox;
   public readonly TwoWayBindingAsserts<Visibility, Asserts> Visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Asserts
   (
      FakeTextBox textBox,
      FakeSystem  system
   )
   {
      IsEnabled = TwoWayBindingAsserts<bool, Asserts>.Create("IsEnabled",
                                                             system.IsEnabled(),
                                                             () => this);

      Text = TwoWayBindingAsserts<string, Asserts>.Create("Text",
                                                          system.Text(),
                                                          () => this);

      TextBox = TextBoxAsserts<Asserts>.Create("TextBox",
                                               textBox,
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
      FakeTextBox textBox,
      FakeSystem  system
   )
      => new(textBox,
             system);

   /* ------------------------------------------------------------ */
}