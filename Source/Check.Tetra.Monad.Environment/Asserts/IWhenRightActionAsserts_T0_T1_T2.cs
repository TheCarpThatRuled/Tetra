using Tetra.Testing;

namespace Check;

public interface IWhenRightActionAsserts<T0, T1, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T0, T1, TAsserts> WhenRight();

   /* ------------------------------------------------------------ */
}