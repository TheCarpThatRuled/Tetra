using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class Arranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_Content(object content)
      {
         _system.Content()
                .Push(content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Acts WHEN()
         => new(_label,
                _system);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arranges(FakeLabel  label,
                        FakeSystem system)
      {
         _label  = label;
         _system = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeLabel  _label;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
   }
}