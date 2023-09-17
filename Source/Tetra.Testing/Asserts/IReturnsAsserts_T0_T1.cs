namespace Tetra.Testing;

public interface IReturns<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ReturnsAsserts<T, TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}