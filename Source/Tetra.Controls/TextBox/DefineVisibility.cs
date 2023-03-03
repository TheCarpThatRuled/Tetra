namespace Tetra;

partial class TextBox
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TextBox Visibility(IOneWayBinding<Visibility> visibility)
         => new(_isEnabled,
                _text,
                visibility);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility(IOneWayBinding<bool>   isEnabled,
                                ITwoWayBinding<string> text)
      {
         _isEnabled = isEnabled;
         _text      = text;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOneWayBinding<bool>   _isEnabled;
      private readonly ITwoWayBinding<string> _text;

      /* ------------------------------------------------------------ */
   }
}