using Tetra;
using Tetra.Testing;
using static Tetra.Testing.AAATest;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class Arrange : Arrange<Act, ArrangeInstance, ActInstance>
   {
      /* ------------------------------------------------------------ */
      // Arrange<Act, ArrangeInstance, ActInstance> Overridden Methods
      /* ------------------------------------------------------------ */

      protected override Act CreateAct(DefineWhen<ActInstance> factory)
         => new(factory);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Arrange The_system_updates_Content(object content)
      {
         Add(characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_system_updates_Content)}: {content}"),
             given => given.The_system_updates_Content(content));

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arrange The_system_updates_Visibility(Visibility visibility)
      {
         Add(characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_system_updates_Visibility)}: {visibility}"),
             given => given.The_system_updates_Visibility(visibility));

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Arrange Create(DefineGiven                                  factory,
                                     Func<GivenCharacteriser, GivenCharacteriser> characterisation,
                                     Func<Disposables, ArrangeInstance>           given)
         => new(factory,
                characterisation,
                given);

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