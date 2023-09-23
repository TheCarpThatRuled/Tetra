using Tetra.Testing;

namespace Check;

public interface IWhenRightFuncAsserts<T0, T1, TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<T0, T1, TReturn, TAsserts> WhenRight();

   /* ------------------------------------------------------------ */
}