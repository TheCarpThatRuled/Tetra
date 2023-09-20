using Tetra.Testing;

namespace Check;

public interface IWhenSomeFuncAsserts<T0, T1, TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<T0, T1, TReturn, TAsserts> WhenSome();

   /* ------------------------------------------------------------ */
}