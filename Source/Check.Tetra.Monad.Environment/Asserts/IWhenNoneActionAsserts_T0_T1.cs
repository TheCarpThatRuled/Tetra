using Tetra.Testing;

namespace Check;

public interface IWhenNoneActionAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<T, TAsserts> WhenNone();

   /* ------------------------------------------------------------ */
}