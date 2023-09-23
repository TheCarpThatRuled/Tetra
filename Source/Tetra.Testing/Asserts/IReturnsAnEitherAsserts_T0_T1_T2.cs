namespace Tetra.Testing;

public interface IReturnsAnEitherAsserts<TLeft, TRight, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public EitherAsserts<TLeft, TRight, TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}