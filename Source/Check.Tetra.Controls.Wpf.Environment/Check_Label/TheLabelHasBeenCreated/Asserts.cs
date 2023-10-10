using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class Asserts : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeLabel  _label;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts
      (
         FakeLabel  label,
         FakeSystem system
      )
      {
         _label  = label;
         _system = system;
      }
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public LabelAsserts<Asserts> The_label
         => new("System under test",
                _label,
                this);

      /* ------------------------------------------------------------ */
   }
}