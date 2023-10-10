namespace Tetra;

partial class TextBox
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ITwoWayBinding<string> _text;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled
      (
         ITwoWayBinding<string> text
      )
         => _text = text;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled
      (
         IOneWayBinding<bool> isEnabled
      )
         => new(isEnabled,
                _text);

      /* ------------------------------------------------------------ */
   }
}