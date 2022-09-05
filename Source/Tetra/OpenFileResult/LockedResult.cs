namespace Tetra;

internal sealed class LockedResult<T> : IOpenFileResult<T>
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Methods
   /* ------------------------------------------------------------ */

   public IOpenFileResult<T> Do(Action<Locked>  whenLocked,
                                Action<Missing> whenMissing,
                                Action<T>       whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public TNew Reduce<TNew>(Func<Locked, TNew>  whenLocked,
                            Func<Missing, TNew> whenMissing,
                            Func<T, TNew>       whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */
}