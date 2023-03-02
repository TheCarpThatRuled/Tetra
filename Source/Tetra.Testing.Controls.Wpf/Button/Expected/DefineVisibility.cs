// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

partial class Expected_button
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Expected_button Visibility_is(Visibility visibility)
         => new($"({_isEnabled}, {visibility})",
                $"{{{Environment.NewLine}IsEnabled: {_isEnabled}{Environment.NewLine}Visibility: {visibility}{Environment.NewLine}}}",
                _isEnabled,
                visibility);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly bool _isEnabled;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility(bool isEnabled)
         => _isEnabled = isEnabled;

      /* ------------------------------------------------------------ */
   }
}