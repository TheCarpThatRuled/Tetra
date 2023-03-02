// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Label;

partial class The_UI_creates_a_label
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public The_UI_creates_a_label Visibility_is(Visibility visibility)
         => new(string.Empty,
                _content,
                string.Empty,
                visibility);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly object _content;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility(object content)
      {
         _content   = content;
      }

      /* ------------------------------------------------------------ */
   }
}