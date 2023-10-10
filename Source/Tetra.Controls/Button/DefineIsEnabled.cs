namespace Tetra;

partial class Button
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Action _onClick;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled
      (
         Action onClick
      )
         => _onClick = onClick;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled
      (
         IOneWayBinding<bool> isEnabled
      )
         => new(_onClick,
                isEnabled);

      /* ------------------------------------------------------------ */
   }
}