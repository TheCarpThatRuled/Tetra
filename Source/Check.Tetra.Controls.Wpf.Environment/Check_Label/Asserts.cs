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
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Asserts
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
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Asserts Create
   (
      FakeLabel  label,
      FakeSystem system
   )
      => new(label,
             system);

   /* ------------------------------------------------------------ */
}