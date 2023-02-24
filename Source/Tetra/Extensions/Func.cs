namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Func_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Func<TIn, TOut> Then<TIn, TIntermediate, TOut>(this Func<TIn, TIntermediate> first,
                                                                Func<TIntermediate, TOut>     second)
   {
      TOut Func(TIn @in)
         => second(first(@in));

      return Func;
   }

   /* ------------------------------------------------------------ */

   public static Func<TIn, TOut> Then<TIn, TOut>(this Func<TIn, TOut> first,
                                                 Action<TOut>         second)
   {
      TOut Func(TIn @in)
      {
         var @out = first(@in);
         second(@out);
         return @out;
      }

      return Func;
   }

   /* ------------------------------------------------------------ */
}