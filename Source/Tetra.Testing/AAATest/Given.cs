namespace Tetra.Testing;

partial class AAATest
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

      public When Arrange()
         => new(_arrange(_disposables));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Given(Func<Disposables, Func<Action>> arrange)
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Disposables _disposables = Disposables.Create();

      private readonly Func<Disposables, Func<Action>> _arrange;

      /* ------------------------------------------------------------ */
   }
}