namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test1
{
   public sealed class Disposables
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<IDisposable> _disposables = new();

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Disposables() { }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Register
      (
         IDisposable disposable
      )
         => _disposables
           .Add(disposable);

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Disposables Create()
         => new();

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      internal void Dispose()
      {
         foreach (var disposable in _disposables)
         {
            disposable.Dispose();
         }
      }

      /* ------------------------------------------------------------ */
   }
}