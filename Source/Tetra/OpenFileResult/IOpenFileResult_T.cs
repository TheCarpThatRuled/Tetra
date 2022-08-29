namespace Tetra;

public interface IOpenFileResult<out T>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   IOpenFileResult<T> Do(Action<Locked>  whenLocked,
                         Action<Missing> whenMissing,
                         Action<IOpen>   whenOpen);

   /* ------------------------------------------------------------ */

   IOpenFileResult<TNew> Map<TNew>(Func<IOpen, TNew> whenOpen);

   /* ------------------------------------------------------------ */

   IOpenFileResult<TNew> Map<TNew>(Func<IOpen, IResult<TNew>> whenOpen);

   /* ------------------------------------------------------------ */

   TNew Reduce<TNew>(Func<Locked, TNew>  whenLocked,
                     Func<Missing, TNew> whenMissing,
                     Func<IOpen, TNew> whenOpen);

   /* ------------------------------------------------------------ */

   public interface IOpen
   {
      /* ------------------------------------------------------------ */

      public T Content();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}