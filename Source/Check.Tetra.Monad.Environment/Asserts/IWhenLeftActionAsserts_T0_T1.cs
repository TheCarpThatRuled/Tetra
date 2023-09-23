using Tetra.Testing;

namespace Check;

public interface IWhenLeftActionAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T, TAsserts> WhenLeft();

   /* ------------------------------------------------------------ */
}