namespace Tetra.Testing;

public interface IReturnsABooleanAsserts< TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public BooleanAsserts<TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}