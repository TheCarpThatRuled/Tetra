using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
{
   public sealed class Asserts<TThen> : Asserts<TThen, AssertsInstance>
      where TThen : IAssertsInstance
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public TextBoxAsserts<Asserts<TThen>, AssertsInstance> The_text_box
         => new($"{nameof(The_text_box)}_",
                (characterisation,
                 then) => Add(Create,
                              characterisation,
                              asserts => then(asserts.The_text_box)));

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts<TThen> The_system_Text_is(string expected)
      {
         Add(characterisation => characterisation.AddClauseToCharacterisation($@"{nameof(The_system_Text_is)}: ""{expected}"""),
             then => then.The_system_Text_is(expected));

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
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(AAATest.DefineThen<TThen>                                  factory,
                       Func<AAATest.ThenCharacteriser, AAATest.ThenCharacteriser> characterisation,
                       Func<TThen, AssertsInstance>                               then)
         : base(factory,
                characterisation,
                then) { }

      /* ------------------------------------------------------------ */
   }
}