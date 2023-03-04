using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class Asserts<TThen> : Asserts<TThen, AssertsInstance>
      where TThen : IAssertsInstance
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ButtonAsserts<Asserts<TThen>, AssertsInstance> The_button
         => new($"{nameof(The_button)}_",
                (characterisation,
                 then) => Add(Create,
                              characterisation,
                              asserts => then(asserts.The_button)));

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts<TThen> The_Click_callback_was_invoked(uint numberOfClicks = 1)
      {
         Add(characterisation
                => characterisation.AddClauseToCharacterisation($"{nameof(The_Click_callback_was_invoked)}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}"),
             then => then.The_Click_callback_was_invoked(numberOfClicks));

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Asserts<TThen> Create(AAATest.DefineThen<TThen>                                  factory,
                                            Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> characterisation,
                                            Func<TThen, AssertsInstance>                               then)
         => new(factory,
                characterisation,
                then);

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Asserts(AAATest.DefineThen<TThen>                                  factory,
                      Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> characterisation,
                      Func<TThen, AssertsInstance>                               then)
         : base(factory,
                characterisation,
                then) { }

      /* ------------------------------------------------------------ */
   }
}