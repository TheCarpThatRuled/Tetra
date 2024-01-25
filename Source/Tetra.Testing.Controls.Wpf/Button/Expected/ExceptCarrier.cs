using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class ExpectedButton
{
   public sealed class ExceptCarrier<T>
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<ExpectedButton, T> _createParent;
      private readonly ExpectedButton          _source;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ExceptCarrier
      (
         Func<ExpectedButton, T> createParent,
         ExpectedButton          source
      )
      {
         _createParent = createParent;
         _source       = source;
      }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public T IsEnabled_is
      (
         bool isEnabled
      )
         => _createParent(Factory()
                         .IsEnabled_is(isEnabled)
                         .Visibility_is(_source._visibility));

      /* ------------------------------------------------------------ */

      public T Visibility_is
      (
         Visibility visibility
      )
         => _createParent(Factory()
                         .IsEnabled_is(_source._isEnabled)
                         .Visibility_is(visibility));

      /* ------------------------------------------------------------ */
   }
}