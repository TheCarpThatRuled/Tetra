using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class Asserts<TThen> : Asserts<TThen, AssertsInstance>
      where TThen : IAssertsInstance
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public LabelAsserts<Asserts<TThen>, AssertsInstance> The_label
         => new($"{nameof(The_label)}_",
                (characterisation,
                 then) => Add(Create,
                              characterisation,
                              asserts => then(asserts.The_label)));

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