using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Field
   /* ------------------------------------------------------------ */

   public readonly TwoWayBindingAsserts<object, Asserts>     Content;
   public readonly LabelAsserts<Asserts>                     Label;
   public readonly TwoWayBindingAsserts<Visibility, Asserts> Visibility;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Asserts
   (
      FakeLabel  label,
      FakeSystem system
   )
   {
      Content = TwoWayBindingAsserts<object, Asserts>.Create("Content",
                                                             system.Content(),
                                                             () => this);

      Label = LabelAsserts<Asserts>.Create("Label",
                                           label,
                                           () => this);

      Visibility = TwoWayBindingAsserts<Visibility, Asserts>.Create("Visibility",
                                                                    system.Visibility(),
                                                                    () => this);
   }

   /* ------------------------------------------------------------ */
}