using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class Given : IDisposable
   {
      /* ------------------------------------------------------------ */
      // IDisposable Methods
      /* ------------------------------------------------------------ */

      public void Dispose()
         => _disposables
           .Dispose();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public When Arrange(TState state)
         => new(_arrange(_disposables,
                         state));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Given(Func<Disposables, TState, Func<Func<Property>>> arrange)
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Disposables _disposables = Disposables.Create();

      private readonly Func<Disposables, TState, Func<Func<Property>>> _arrange;

      /* ------------------------------------------------------------ */
   }
}