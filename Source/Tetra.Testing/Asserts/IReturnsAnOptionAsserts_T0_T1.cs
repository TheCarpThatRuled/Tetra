namespace Tetra.Testing;

public interface IReturnsAnOptionAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public OptionAsserts<T, TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}