namespace Tetra.Testing;

partial class AAATest
{
   public sealed class DefineThen<TWhen, TThen>
      where TThen : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public AAATest Then(Func<ThenCharacteriser, Action<TThen>> then)
      {
         var actualThen = then(_characteriser);

         return _create(disposables =>
                        {
                           var given = _given(disposables);
                           return () =>
                           {
                              var when = _when(given);

                              return () => actualThen(when);
                           };
                        },
                        _characteriser.Finish());
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineThen(Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> create,
                          Func<Disposables, TWhen>                                      given,
                          Func<TWhen, TThen>                                            when,
                          ThenCharacteriser                                             characteriser)
      {
         _characteriser = characteriser;
         _create        = create;
         _given         = given;
         _when          = when;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ThenCharacteriser                                             _characteriser;
      private readonly Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> _create;
      private readonly Func<Disposables, TWhen>                                      _given;
      private readonly Func<TWhen, TThen>                                            _when;

      /* ------------------------------------------------------------ */
   }
}