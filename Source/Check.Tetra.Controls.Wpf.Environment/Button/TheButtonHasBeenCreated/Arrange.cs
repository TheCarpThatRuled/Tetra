using Tetra.Testing;
using static Tetra.Testing.AAATest;

// ReSharper disable InconsistentNaming

namespace Check;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class Arrange : Arrange<Act, ArrangeInstance, ActInstance>
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static Arrange Create(DefineGiven                                  factory,
                                   Func<GivenCharacteriser, GivenCharacteriser> characterisation,
                                   Func<Disposables, ArrangeInstance>           given)
         => new(factory,
                characterisation,
                given);

      /* ------------------------------------------------------------ */
      // Arrange<Act, ArrangeInstance, ActInstance> Overridden Methods
      /* ------------------------------------------------------------ */

      protected override Act CreateAct(DefineWhen<ActInstance> factory)
         => new(factory);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Arrange(DefineGiven                                  factory,
                      Func<GivenCharacteriser, GivenCharacteriser> characterisation,
                      Func<Disposables, ArrangeInstance>           given) : base(factory,
                                                                                 characterisation,
                                                                                 given) { }

      /* ------------------------------------------------------------ */
   }
}