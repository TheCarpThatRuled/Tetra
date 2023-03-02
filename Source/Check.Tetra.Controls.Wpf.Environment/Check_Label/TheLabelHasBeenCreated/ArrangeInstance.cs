using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new(_label,
                _system);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_Content(object content)
      {
         _system.Content()
                .Push(content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance(FakeLabel label,
                               FakeSystem system)
      {
         _label = label;
         _system = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeLabel _label;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
   }
}