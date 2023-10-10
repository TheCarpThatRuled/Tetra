// ReSharper disable InconsistentNaming

using System.Windows;

namespace Tetra.Testing;

partial class Expected_label
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly object _content;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility
      (
         object content
      )
         => _content = content;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Expected_label Visibility_is
      (
         Visibility visibility
      )
         => new($@"(""{_content}"", {visibility})",
                _content,
                $"{{{Environment.NewLine}Content: {_content}{Environment.NewLine}Visibility: {visibility}{Environment.NewLine}}}",
                visibility);

      /* ------------------------------------------------------------ */
   }
}