// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

partial class Expected_button
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly bool _isEnabled;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility
      (
         bool isEnabled
      )
         => _isEnabled = isEnabled;

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Expected_button Visibility_is
      (
         Visibility visibility
      )
         => new(_isEnabled,
                visibility);

      /* ------------------------------------------------------------ */
   }
}