// ReSharper disable InconsistentNaming

using Tetra;

namespace Check;

partial class The_UI_creates_a_button
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public The_UI_creates_a_button Visibility_is(Visibility visibility)
         => new(string.Empty,
                string.Empty,
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