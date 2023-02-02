namespace Tetra.Testing;

partial class AAATest
{
   public sealed class DefineThen<TThen>
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
                              var when = given();

                              return () => actualThen(when);
                           };
                        },
                        _characteriser.Finish());
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal DefineThen(Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> create,
                          Func<Disposables, Func<TThen>>                                given,
                          ThenCharacteriser                                             characteriser)
      {
         _characteriser = characteriser;
         _create        = create;
         _given         = given;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ThenCharacteriser                                             _characteriser;
      private readonly Func<Func<Disposables, Func<Action>>, Characteriser, AAATest> _create;
      private readonly Func<Disposables, Func<TThen>>                                _given;

      /* ------------------------------------------------------------ */
   }
}