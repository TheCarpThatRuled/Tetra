namespace Tetra.Testing;


partial class AAATest
{
   public sealed class Disposables
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Register(IDisposable disposable)
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
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<IDisposable> _disposables = new();

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Disposables() { }

      /* ------------------------------------------------------------ */
   }
}