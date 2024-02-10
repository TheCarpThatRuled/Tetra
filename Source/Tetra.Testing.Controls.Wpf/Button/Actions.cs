namespace Tetra.Testing;

public sealed class ButtonActions<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeButton _button;
   private readonly string     _descriptionHeader;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ButtonActions
   (
      FakeButton button,
      string     descriptionHeader,
      Func<T>    next
   ) : base(next)
   {
      _button            = button;
      _descriptionHeader = descriptionHeader;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ButtonActions<T> Create
   (
      string     descriptionHeader,
      FakeButton button,
      Func<T>    next
   )
      => new(button,
             descriptionHeader,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ButtonActions<T> Click
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
}