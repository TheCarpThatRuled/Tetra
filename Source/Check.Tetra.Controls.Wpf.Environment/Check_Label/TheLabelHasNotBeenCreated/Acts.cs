using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed partial class TheLabelHasNotBeenCreated
{
   public sealed class Acts : IActs
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<TheLabelHasBeenCreated.Asserts> The_UI_creates_the_label(The_UI_creates_a_label args)
         => new(() => Create_the_label(args));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Acts() { }

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private TheLabelHasBeenCreated.Asserts Create_the_label(The_UI_creates_a_label args)
      {
         var system = FakeSystem.Create(args);
         return new(FakeLabel.Create(LabelContext.Create(Label
                                                        .Factory()
                                                        .Content(system.Content())
                                                        .Visibility(system.Visibility()))),
                    system);
      }

      /* ------------------------------------------------------------ */
   }
}