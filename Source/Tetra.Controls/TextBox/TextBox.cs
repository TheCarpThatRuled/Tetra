namespace Tetra;

public sealed partial class TextBox
{
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private readonly IOneWayBinding<bool>       _isEnabled;
   private readonly ITwoWayBinding<string>     _text;
   private readonly IOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TextBox
   (
      IOneWayBinding<bool>       isEnabled,
      ITwoWayBinding<string>     text,
      IOneWayBinding<Visibility> visibility
   )
   {
      _isEnabled  = isEnabled;
      _text       = text;
      _visibility = visibility;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineText Factory()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public IOneWayBinding<bool> IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public ITwoWayBinding<string> Text()
      => _text;

   /* ------------------------------------------------------------ */

   public IOneWayBinding<Visibility> Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
}