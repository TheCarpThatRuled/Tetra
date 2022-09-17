namespace Tetra;

internal sealed class OpenResult<T> : IOpenFileResult<T>
{
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   public OpenResult(T content)
      => Content = content;

   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Methods
   /* ------------------------------------------------------------ */

   public IOpenFileResult<T> Do(Action<Locked>  whenLocked,
                                Action<Missing> whenMissing,
                                Action<T>       whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen)
      => new OpenResult<TNew>(whenOpen(Content));

   /* ------------------------------------------------------------ */

   public TNew Reduce<TNew>(Func<Locked, TNew>  whenLocked,
                            Func<Missing, TNew> whenMissing,
                            Func<T, TNew>       whenOpen)
      => whenOpen(Content);

   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   internal readonly T Content;

   /* ------------------------------------------------------------ */
}