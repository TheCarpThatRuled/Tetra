using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters>
{
   public sealed class Given : IDisposable
   {

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Disposables _disposables = Disposables.Create();

      private readonly Func<TParameters, Disposables, Func<Func<Property>>> _arrange;
      private readonly TParameters                                          _parameters;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Given
      (
         TParameters                                          parameters,
         Func<TParameters, Disposables, Func<Func<Property>>> arrange
      )
      {
         _arrange    = arrange;
         _parameters = parameters;
      }

      /* ------------------------------------------------------------ */
      // IDisposable Methods
      /* ------------------------------------------------------------ */

      public void Dispose()
         => _disposables
           .Dispose();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public When Arrange()
         => new(_arrange(_parameters,
                         _disposables));

      /* ------------------------------------------------------------ */
   }
}