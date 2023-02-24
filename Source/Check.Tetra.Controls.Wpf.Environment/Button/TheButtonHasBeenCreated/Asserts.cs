using Tetra;
using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class Asserts<TThen> : IAsserts
      where TThen : IAssertsInstance
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ButtonAsserts<Asserts<TThen>, AssertsInstance> The_button
         => new($"{nameof(The_button)}_",
                (characterisation,
                 then) => new(_factory,
                              _characterisation.Then(characterisation),
                              _then.Then(asserts => then(asserts.The_button))));

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
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(AAATest.DefineThen<TThen>                                  factory,
                       Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> characterisation,
                       Func<TThen, AssertsInstance>                               then)
      {
         _characterisation = characterisation;
         _factory          = factory;
         _then             = then;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> _characterisation;
      private readonly AAATest.DefineThen<TThen>                                  _factory;
      private readonly Func<TThen, AssertsInstance>                               _then;

      /* ------------------------------------------------------------ */
   }
}