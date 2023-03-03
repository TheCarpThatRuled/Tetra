namespace Tetra;

partial class TextBox
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled(IOneWayBinding<bool> isEnabled)
         => new(isEnabled,
                _text);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled(ITwoWayBinding<string> text)
         => _text = text;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ITwoWayBinding<string> _text;

      /* ------------------------------------------------------------ */
   }
}