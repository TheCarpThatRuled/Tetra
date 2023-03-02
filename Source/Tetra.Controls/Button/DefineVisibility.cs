namespace Tetra;

partial class Button
{
   public sealed class DefineVisibility
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Button Visibility(IOneWayBinding<Visibility> visibility)
         => new(_isEnabled,
                _onClick,
                visibility);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineVisibility(Action               onClick,
                                IOneWayBinding<bool> isEnabled)
      {
         _isEnabled = isEnabled;
         _onClick   = onClick;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOneWayBinding<bool> _isEnabled;
      private readonly Action               _onClick;

      /* ------------------------------------------------------------ */
   }
}