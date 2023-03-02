using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class AssertsInstance : IAssertsInstance
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public LabelAssertsInstance<AssertsInstance> The_label
         => new("System under test",
                _label,
                this);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal AssertsInstance(FakeLabel label,
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