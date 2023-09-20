using Tetra.Testing;

namespace Check;

public interface IWhenNoneFuncAsserts<T, TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<T, TReturn, TAsserts> WhenNone();

   /* ------------------------------------------------------------ */
}