using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasNotBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TheLabelHasBeenCreated.ArrangeInstance The_UI_creates_the_label(The_UI_creates_a_label args)
      {
         var system = FakeSystem.Create(args);
         return new(FakeLabel.Create(LabelContext.Create(Label
                                                        .Factory()
                                                        .Content(system.Content())
                                                        .Visibility(system.Visibility()))),
                    system);
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance() { }

      /* ------------------------------------------------------------ */
   }
}