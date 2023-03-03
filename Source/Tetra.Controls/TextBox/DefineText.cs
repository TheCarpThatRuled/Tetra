namespace Tetra;

partial class TextBox
{
   public sealed class DefineText
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineIsEnabled Text(ITwoWayBinding<string> text)
         => new(text);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineText() { }

      /* ------------------------------------------------------------ */
   }
}