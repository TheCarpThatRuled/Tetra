using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

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
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Asserts
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
}