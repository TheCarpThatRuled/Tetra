using Tetra.Testing;

namespace Check;

public interface IWhenSomeActionAsserts<T0, T1, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T0, T1, TAsserts> WhenSome();

   /* ------------------------------------------------------------ */
}