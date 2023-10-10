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

      // ReSharper disable once InconsistentNaming
      public OnTheOption on_the_option { get; } = new();

      /* ------------------------------------------------------------ */
      // Given
      /* ------------------------------------------------------------ */

      public IArrange<TheEitherHasNotBeenCreated.Arrange> has_not_created_an_either()
         => AtomicArrange<TheEitherHasNotBeenCreated.Arrange>
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_either)}",
                   TheEitherHasNotBeenCreated.Arrange.Start);

      /* ------------------------------------------------------------ */

      public IArrange<TheOptionHasNotBeenCreated.Arrange> has_not_created_an_option()
         => AtomicArrange<TheOptionHasNotBeenCreated.Arrange>
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_option)}",
                   TheOptionHasNotBeenCreated.Arrange.Start);

      /* ------------------------------------------------------------ */

      public IArrange<TheEitherHasBeenCreated.Arrange> has_created_a_left_from
      (
         FakeLeft? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Left_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_left_from)} ""{content?.Characterisation}""");

      /* ------------------------------------------------------------ */

      public IArrange<TheOptionHasBeenCreated.Arrange> has_created_a_none()
         => has_not_created_an_option()
           .And(calls_Option_T_None())
           .Recharacterise($"{nameof(the_Client)}_{nameof(has_created_a_none)}");

      /* ------------------------------------------------------------ */

      public IArrange<TheEitherHasBeenCreated.Arrange> has_created_a_right_from
      (
         FakeRight? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Right_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_right_from)} ""{content?.Characterisation}""");

      /* ------------------------------------------------------------ */

      public IArrange<TheOptionHasBeenCreated.Arrange> has_created_a_some_from
      (
         FakeType? content
      )
         => has_not_created_an_option()
           .And(calls_Option_T_Some_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_some_from)} ""{content?.Characterisation}""");

      /* ------------------------------------------------------------ */
      // Arrange
      /* ------------------------------------------------------------ */


      /* ------------------------------------------------------------ */
      // Arrange/Act
      /* ------------------------------------------------------------ */

      public IArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, OptionAsserts<FakeType, TestTerminus>> calls_Option_Some_T_with
      (
         FakeType? content
      )
         => AtomicArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, OptionAsserts<FakeType, TestTerminus>>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_Some_T_with)} ""{content?.Characterisation}""",
                   arrange => arrange.CallOptionSomeT(content!),
                   arrange => arrange
                             .ToActs()
                             .CallOptionSomeT(content!));

      /* ------------------------------------------------------------ */

      public IArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, OptionAsserts<FakeType, TestTerminus>> calls_Option_T_None()
         => AtomicArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, OptionAsserts<FakeType, TestTerminus>>
           .Create($"{nameof(the_Client)}_{nameof(calls_Option_T_None)}",
                   arrange => arrange.CallOptionTNone(),
                   arrange => arrange
                             .ToActs()
                             .CallOptionTNone());

      /* ------------------------------------------------------------ */

      public IArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, OptionAsserts<FakeType, TestTerminus>> calls_Option_T_Some_with
      (
         FakeType? content
      )
         => AtomicArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, OptionAsserts<FakeType, TestTerminus>>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_T_Some_with)} ""{content?.Characterisation}""",
                   arrange => arrange.CallOptionTSome(content),
                   arrange => arrange
                             .ToActs()
                             .CallOptionTSome(content));

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