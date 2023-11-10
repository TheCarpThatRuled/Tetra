namespace Tetra.Testing;

public sealed class ButtonActions<TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeButton  _button;
   private readonly string      _descriptionHeader;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ButtonActions
   (
      FakeButton  button,
      string      descriptionHeader,
      Func<TNext> next
   )
   {
      _button            = button;
      _descriptionHeader = descriptionHeader;
      _next              = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ButtonActions<TNext> Create
   (
      string      descriptionHeader,
      FakeButton  button,
      Func<TNext> next
   )
      => new(button,
             descriptionHeader,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ButtonActions<TNext> Click
   (
      uint numberOfClicks = 1
   )
   {
      if (!_button.IsEnabled())
      {
         throw Failed.Assert($"{_descriptionHeader} could not be clicked as it is not enabled");
      }

      _button.Click(numberOfClicks);

      return this;
   }

   /* ------------------------------------------------------------ */

   public TNext Next()
      => _next();

   /* ------------------------------------------------------------ */
}