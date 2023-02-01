namespace Tetra.Testing;

partial class AAATest
{
   public sealed class DefineGiven
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineWhen<T> Given<T>(Func<GivenCharacteriser, Func<Disposables, T>> given)
      {
         var actualGiven = given(_characteriser);

         return new(_create,
                    actualGiven,
                    _characteriser.When());
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineGiven(Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> create)
         => _create = create;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly GivenCharacteriser _characteriser = GivenCharacteriser.Create();

      private readonly Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> _create;

      /* ------------------------------------------------------------ */
   }
}