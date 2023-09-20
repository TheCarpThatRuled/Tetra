using Tetra.Testing;

namespace Check;

public interface IWhenNoneFuncAsserts<TReturn, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public FuncAsserts<TReturn, TAsserts> WhenNone();

   /* ------------------------------------------------------------ */
}