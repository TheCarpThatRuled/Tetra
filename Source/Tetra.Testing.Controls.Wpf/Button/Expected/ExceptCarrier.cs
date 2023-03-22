using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Expected_button
{
   public sealed class ExceptCarrier<T>
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public T IsEnabled_is(bool isEnabled)
         => _createParent(Factory()
                         .IsEnabled_is(isEnabled)
                         .Visibility_is(_source._visibility));

      /* ------------------------------------------------------------ */

      public T Visibility_is(Visibility visibility)
         => _createParent(Factory()
                         .IsEnabled_is(_source._isEnabled)
                         .Visibility_is(visibility));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ExceptCarrier(Func<Expected_button, T> createParent,
                             Expected_button          source)
      {
         _createParent = createParent;
         _source       = source;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Expected_button, T> _createParent;
      private readonly Expected_button          _source;

      /* ------------------------------------------------------------ */
   }
}