using Tetra.Testing;

namespace Check;

public interface IWhenNoneActionAsserts<TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<TAsserts> WhenNone();

   /* ------------------------------------------------------------ */
}