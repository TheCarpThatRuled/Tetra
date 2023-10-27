using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   public sealed partial class TheClient
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      // ReSharper disable once InconsistentNaming
      public OnTheEither on_the_either { get; } = new();

      /* ------------------------------------------------------------ */
      // Given
      /* ------------------------------------------------------------ */

      public IArrange<TheEitherHasNotBeenCreated.Arrange> has_not_created_an_either()
         => AtomicArrange<TheEitherHasNotBeenCreated.Arrange>
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_either)}",
                   TheEitherHasNotBeenCreated.Arrange.Start);

      /* ------------------------------------------------------------ */

      public IArrange<TheEitherHasBeenCreated.Arrange> has_created_a_left_from
      (
         FakeLeft? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Left_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_left_from)} ""{content?.Characterisation}""");

      /* ------------------------------------------------------------ */

      public IArrange<TheEitherHasBeenCreated.Arrange> has_created_a_right_from
      (
         FakeRight? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Right_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_right_from)} ""{content?.Characterisation}""");

      /* ------------------------------------------------------------ */
      // Arrange
      /* ------------------------------------------------------------ */


      /* ------------------------------------------------------------ */
      // Arrange/Act
      /* ------------------------------------------------------------ */

      public IArrangeAct<TheEitherHasNotBeenCreated.Arrange, TheEitherHasBeenCreated.Arrange, EitherAsserts<FakeLeft, FakeRight, TestTerminus>>
         calls_Either_Left_with
         (
            FakeLeft? content
         )
         => AtomicArrangeAct<TheEitherHasNotBeenCreated.Arrange, TheEitherHasBeenCreated.Arrange, EitherAsserts<FakeLeft, FakeRight, TestTerminus>>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Either_Left_with)} ""{content?.Characterisation}""",
                   arrange => arrange.CallEitherLeft(content),
                   arrange => arrange
                             .ToActs()
                             .CallEitherLeft(content));

      /* ------------------------------------------------------------ */

      public IArrangeAct<TheEitherHasNotBeenCreated.Arrange, TheEitherHasBeenCreated.Arrange, EitherAsserts<FakeLeft, FakeRight, TestTerminus>>
         calls_Either_Right_with
         (
            FakeRight? content
         )
         => AtomicArrangeAct<TheEitherHasNotBeenCreated.Arrange, TheEitherHasBeenCreated.Arrange, EitherAsserts<FakeLeft, FakeRight, TestTerminus>>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Either_Right_with)} ""{content?.Characterisation}""",
                   arrange => arrange.CallEitherRight(content),
                   arrange => arrange
                             .ToActs()
                             .CallEitherRight(content));

      /* ------------------------------------------------------------ */
      // Assert
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
   }
}