namespace Tetra.Testing;

public interface IReturnsThisAsserts<TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ReturnsThisAsserts<TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}