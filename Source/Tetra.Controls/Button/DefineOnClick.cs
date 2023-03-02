namespace Tetra;

partial class Button
{
   public sealed class DefineOnClick
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineIsEnabled OnClick(Action onClick)
         => new(onClick);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineOnClick() { }

      /* ------------------------------------------------------------ */
   }
}