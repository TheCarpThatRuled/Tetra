using Tetra.Testing;

namespace Check;

public interface IWhenLeftActionAsserts<T0, T1, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T0, T1, TAsserts> WhenLeft();

   /* ------------------------------------------------------------ */
}