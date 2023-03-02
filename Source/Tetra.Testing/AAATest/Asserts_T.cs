// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public abstract class Asserts<TThen, TAssertsInstance> : IAsserts
   where TThen : IAssertsInstance
   where TAssertsInstance : IAssertsInstance
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public AAATest Crystallise()
      => _factory.Then(characteriser =>
      {
         _characterisation(characteriser);

         return when => _then(when);
      });

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected Asserts(AAATest.DefineThen<TThen>                                  factory,
                     Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> characterisation,
                     Func<TThen, TAssertsInstance>                              then)
   {
      _characterisation = characterisation;
      _factory          = factory;
      _then             = then;
   }

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected void Add(Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> characterisation,
                      Func<TAssertsInstance, TAssertsInstance>                   assert)
   {
      _characterisation = _characterisation.Then(characterisation);
      _then             = _then.Then(assert);
   }

   /* ------------------------------------------------------------ */

   protected TNewAsserts Add<TNewAsserts, TNewAssertsInstance>(
      Func<AAATest.DefineThen<TThen>, Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>, Func<TThen, TNewAssertsInstance>, TNewAsserts> create,
      Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>                                                                                 characterisation,
      Func<TAssertsInstance, TNewAssertsInstance>                                                                                                assert)

      => create(_factory,
                _characterisation.Then(characterisation),
                _then.Then(assert));

   /* ------------------------------------------------------------ */

   protected TNewAsserts Add<TNewAsserts>(
      Func<AAATest.DefineThen<TThen>, Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>, Func<TThen, TAssertsInstance>, TNewAsserts> create,
      Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser>                                                                              characterisation,
      Action<TAssertsInstance>                                                                                                                action)

      => create(_factory,
                _characterisation.Then(characterisation),
                _then.Then(action));

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly AAATest.DefineThen<TThen> _factory;

   //Mutable
   private Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> _characterisation;
   private Func<TThen, TAssertsInstance>                              _then;

   /* ------------------------------------------------------------ */
}