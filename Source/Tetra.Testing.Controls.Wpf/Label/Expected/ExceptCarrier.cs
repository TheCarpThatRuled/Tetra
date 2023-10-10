using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Expected_label
{
   public sealed class ExceptCarrier<T>
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Expected_label, T> _createParent;
      private readonly Expected_label          _source;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ExceptCarrier
      (
         Func<Expected_label, T> createParent,
         Expected_label          source
      )
      {
         _createParent = createParent;
         _source       = source;
      }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public T Content_is
      (
         object content
      )
         => _createParent(Factory()
                         .Content_is(content)
                         .Visibility_is(_source._visibility));

      /* ------------------------------------------------------------ */

      public T Visibility_is
      (
         Visibility visibility
      )
         => _createParent(Factory()
                         .Content_is(_source._content)
                         .Visibility_is(visibility));

      /* ------------------------------------------------------------ */
   }
}