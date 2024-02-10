namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test
{
   public sealed class Given : IDisposable
   {

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Disposables _disposables = Disposables.Create();

      private readonly Func<Parameters, Disposables, Func<Func<Property>>> _arrange;
      private readonly Parameters                                          _parameters;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Given
      (
         Parameters                                          parameters,
         Func<Parameters, Disposables, Func<Func<Property>>> arrange
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