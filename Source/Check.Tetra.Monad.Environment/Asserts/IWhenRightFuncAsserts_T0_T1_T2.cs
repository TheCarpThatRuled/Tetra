using Tetra.Testing;

namespace Check;

public interface IWhenRightFuncAsserts<T, TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<T, TReturn, TAsserts> WhenRight();

   /* ------------------------------------------------------------ */
}