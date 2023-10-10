namespace Tetra;

partial class Button
{
   public sealed class DefineOnClick
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineOnClick() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineIsEnabled OnClick
      (
         Action onClick
      )
         => new(onClick);

      /* ------------------------------------------------------------ */
   }
}