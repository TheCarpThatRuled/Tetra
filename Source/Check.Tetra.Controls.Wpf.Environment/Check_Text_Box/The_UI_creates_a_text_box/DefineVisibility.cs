// ReSharper disable InconsistentNaming

using Tetra;

namespace Check.Check_Text_Box;

partial class The_UI_creates_a_text_box
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly bool   _isEnabled;
      private readonly string _text;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility
      (
         bool   isEnabled,
         string text
      )
      {
         _isEnabled = isEnabled;
         _text      = text;
      }
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public The_UI_creates_a_text_box Visibility_is
      (
         Visibility visibility
      )
         => new($"""({_isEnabled}, "{_text}", {visibility})""",
                $$"""{{{Environment.NewLine}}IsEnabled: {{_isEnabled}}{{Environment.NewLine}}Text: "{{_text}}"{{Environment.NewLine}}Visibility: {{visibility}}{{Environment.NewLine}}}""",
                _isEnabled,
                _text,
                visibility);

      /* ------------------------------------------------------------ */
   }
}