namespace Tetra;

public interface IOpenFileResult<out T>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   IOpenFileResult<T> Do
   (
      Action<Locked>  whenLocked,
      Action<Missing> whenMissing,
      Action<T>       whenOpen
   );

   /* ------------------------------------------------------------ */

   IOpenFileResult<TNew> Map<TNew>
   (
      Func<T, TNew> whenOpen
   );

   /* ------------------------------------------------------------ */

   TNew Reduce<TNew>
   (
      Func<Locked, TNew>  whenLocked,
      Func<Missing, TNew> whenMissing,
      Func<T, TNew>       whenOpen
   );

   /* ------------------------------------------------------------ */
}