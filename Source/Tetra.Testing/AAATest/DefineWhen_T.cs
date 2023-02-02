namespace Tetra.Testing;

partial class AAATest
{
   public sealed class DefineWhen<TWhen>
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen<TThen> When<TThen>(Func<WhenCharacteriser, Func<TWhen, TThen>> when)
         where TThen : IAsserts
      {
         var actualWhen = when(_characteriser);

         return new(_create,
                    disposables =>
                    {
                       var given = _given(disposables);
                       return () => actualWhen(given);
                    },
                    _characteriser.Then());
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineWhen(Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> create,
                          Func<Disposables, TWhen>                                      given,
                          WhenCharacteriser                                             characteriser)
      {
         _characteriser = characteriser;
         _create        = create;
         _given         = given;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly WhenCharacteriser                                             _characteriser;
      private readonly Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> _create;
      private readonly Func<Disposables, TWhen>                                      _given;

      /* ------------------------------------------------------------ */
   }
}