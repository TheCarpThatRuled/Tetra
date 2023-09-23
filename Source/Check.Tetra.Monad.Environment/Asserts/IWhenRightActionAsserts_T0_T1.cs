using Tetra.Testing;

namespace Check;

public interface IWhenRightActionAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T, TAsserts> WhenRight();

   /* ------------------------------------------------------------ */
}