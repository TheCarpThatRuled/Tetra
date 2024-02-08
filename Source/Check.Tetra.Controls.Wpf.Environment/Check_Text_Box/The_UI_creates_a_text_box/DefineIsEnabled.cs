// ReSharper disable InconsistentNaming

namespace Check.Check_Text_Box;

partial class The_UI_creates_a_text_box
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly string _text;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled
      (
         string text
      )
         => _text = text;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled_is
      (
         bool isEnabled
      )
         => new(isEnabled,
                _text);

      /* ------------------------------------------------------------ */
   }
}