using System.Windows;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Expected_text_box
{
   public sealed class ExceptCarrier<T>
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Expected_text_box, T> _createParent;
      private readonly Expected_text_box          _source;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ExceptCarrier
      (
         Func<Expected_text_box, T> createParent,
         Expected_text_box          source
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
                         .Text_is(_source._text)
                         .IsEnabled_is(isEnabled)
                         .Visibility_is(_source._visibility));

      /* ------------------------------------------------------------ */

      public T Text_is
      (
         string text
      )
         => _createParent(Factory()
                         .Text_is(text)
                         .IsEnabled_is(_source._isEnabled)
                         .Visibility_is(_source._visibility));

      /* ------------------------------------------------------------ */

      public T Visibility_is
      (
         Visibility visibility
      )
         => _createParent(Factory()
                         .Text_is(_source._text)
                         .IsEnabled_is(_source._isEnabled)
                         .Visibility_is(visibility));

      /* ------------------------------------------------------------ */
   }
}