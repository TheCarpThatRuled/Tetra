using Tetra.Testing;

namespace Check;

public interface IWhenSomeFuncAsserts<T, TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<T, TReturn, TAsserts> WhenSome();

   /* ------------------------------------------------------------ */
}