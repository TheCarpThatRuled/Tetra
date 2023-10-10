namespace Tetra;

partial class TextBox
{
   public sealed class DefineText
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineText() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineIsEnabled Text
      (
         ITwoWayBinding<string> text
      )
         => new(text);

      /* ------------------------------------------------------------ */
   }
}