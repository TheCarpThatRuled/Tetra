namespace Tetra;

partial class Button
{
   public sealed class DefineIsEnabled
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineVisibility IsEnabled(IOneWayBinding<bool> isEnabled)
         => new(_onClick,
                isEnabled);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineIsEnabled(Action onClick)
         => _onClick = onClick;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Action _onClick;

      /* ------------------------------------------------------------ */
   }
}