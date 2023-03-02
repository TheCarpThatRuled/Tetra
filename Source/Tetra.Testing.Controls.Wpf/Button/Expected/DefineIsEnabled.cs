// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

partial class Expected_button
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled_is(bool isEnabled)
         => new(isEnabled);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled() { }

      /* ------------------------------------------------------------ */
   }
}