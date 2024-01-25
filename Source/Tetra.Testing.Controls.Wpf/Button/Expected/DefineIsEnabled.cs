// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class ExpectedButton
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled() { }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled_is
      (
         bool isEnabled
      )
         => new(isEnabled);

      /* ------------------------------------------------------------ */
   }
}