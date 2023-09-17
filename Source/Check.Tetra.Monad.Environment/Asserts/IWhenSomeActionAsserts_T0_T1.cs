using Tetra.Testing;

namespace Check;

public interface IWhenSomeActionAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T, TAsserts> WhenSome();

   /* ------------------------------------------------------------ */
}