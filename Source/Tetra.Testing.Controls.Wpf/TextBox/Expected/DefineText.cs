// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class Expected_text_box
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

      public DefineIsEnabled Text_is
      (
         string text
      )
         => new(text);

      /* ------------------------------------------------------------ */
   }
}