namespace Tetra;

internal sealed class OpenResult<T> : IOpenFileResult<T>
{
   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   internal readonly T Content;
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   public OpenResult
   (
      T content
   )
      => Content = content;

   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Methods
   /* ------------------------------------------------------------ */

   public IOpenFileResult<T> Do
   (
      Action<Locked>  whenLocked,
      Action<Missing> whenMissing,
      Action<T>       whenOpen
   )
   {
      whenOpen(Content);

      return this;
   }

   /* ------------------------------------------------------------ */

   public IOpenFileResult<TNew> Map<TNew>
   (
      Func<T, TNew> whenOpen
   )
      => new OpenResult<TNew>(whenOpen(Content));

   /* ------------------------------------------------------------ */

   public TNew Reduce<TNew>
   (
      Func<Locked, TNew>  whenLocked,
      Func<Missing, TNew> whenMissing,
      Func<T, TNew>       whenOpen
   )
      => whenOpen(Content);

   /* ------------------------------------------------------------ */
}