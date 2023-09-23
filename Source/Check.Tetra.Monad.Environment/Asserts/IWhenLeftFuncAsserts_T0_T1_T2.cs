using Tetra.Testing;

namespace Check;

public interface IWhenLeftFuncAsserts<T, TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<T, TReturn, TAsserts> WhenLeft();

   /* ------------------------------------------------------------ */
}