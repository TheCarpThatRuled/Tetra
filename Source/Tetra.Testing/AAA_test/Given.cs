namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class Given : IDisposable
   {
      private readonly Func<Disposables, Func<Action>> _arrange;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Disposables _disposables = Disposables.Create();

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Given
      (
         Func<Disposables, Func<Action>> arrange
      )
         => _arrange = arrange;
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
         => new(_arrange(_disposables));

      /* ------------------------------------------------------------ */
   }
}