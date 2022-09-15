namespace Tetra;

internal sealed class LockedResult<T> : IOpenFileResult<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */


   public static LockedResult<T> Create(Message          message,
                                        AbsoluteFilePath path)
      => new(new(message,
                 path));

   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Methods
   /* ------------------------------------------------------------ */

   public IOpenFileResult<T> Do(Action<Locked>  whenLocked,
                                Action<Missing> whenMissing,
                                Action<T>       whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen)
      => new LockedResult<TNew>(Content);

   /* ------------------------------------------------------------ */

   public TNew Reduce<TNew>(Func<Locked, TNew>  whenLocked,
                            Func<Missing, TNew> whenMissing,
                            Func<T, TNew>       whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   internal readonly Locked Content;

   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   private LockedResult(Locked content)
      => Content = content;

   /* ------------------------------------------------------------ */
}