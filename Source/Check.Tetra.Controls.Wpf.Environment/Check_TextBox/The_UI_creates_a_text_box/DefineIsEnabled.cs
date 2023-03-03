// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

partial class The_UI_creates_a_text_box
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled_is(bool isEnabled)
         => new(isEnabled,
                _text);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled(string text)
         => _text = text;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly string _text;

      /* ------------------------------------------------------------ */
   }
}