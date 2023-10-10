namespace Tetra;

public sealed partial class Button
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOneWayBinding<bool>       _isEnabled;
   private readonly Action                     _onClick;
   private readonly IOneWayBinding<Visibility> _visibility;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Button
   (
      IOneWayBinding<bool>       isEnabled,
      Action                     onClick,
      IOneWayBinding<Visibility> visibility
   )
   {
      _isEnabled  = isEnabled;
      _onClick    = onClick;
      _visibility = visibility;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineOnClick Factory()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public IOneWayBinding<bool> IsEnabled()
      => _isEnabled;

   /* ------------------------------------------------------------ */

   public IOneWayBinding<Visibility> Visibility()
      => _visibility;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void Click()
      => _onClick();

   /* ------------------------------------------------------------ */
}