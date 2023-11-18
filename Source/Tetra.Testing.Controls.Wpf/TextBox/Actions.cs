namespace Tetra.Testing;

public sealed class TextBoxActions<TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string      _descriptionHeader;
   private readonly Func<TNext> _next;
   private readonly FakeTextBox _textBox;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TextBoxActions
   (
      string      descriptionHeader,
      Func<TNext> next,
      FakeTextBox textBox
   )
   {
      _textBox           = textBox;
      _descriptionHeader = descriptionHeader;
      _next              = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TextBoxActions<TNext> Create
   (
      string      descriptionHeader,
      FakeTextBox textBox,
      Func<TNext> next
   )
      => new(descriptionHeader,
             next,
             textBox);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TextBoxActions<TNext> EnterText
   (
      string text
   )
   {
      if (!_textBox.IsEnabled())
      {
         throw Failed.Assert($"{_descriptionHeader} could not receive text as it is not enabled");
      }

      _textBox.EnterText(text);

      return this;
   }

   /* ------------------------------------------------------------ */

   public TNext Next()
      => _next();

   /* ------------------------------------------------------------ */
}