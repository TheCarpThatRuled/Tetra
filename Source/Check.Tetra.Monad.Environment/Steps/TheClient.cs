using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   public sealed class TheClient
   {
      /* ------------------------------------------------------------ */
      // Given
      /* ------------------------------------------------------------ */

      public IArrange<TheOptionHasNotBeenCreated.Arrange> has_not_created_an_option()
         => AtomicArrange<TheOptionHasNotBeenCreated.Arrange>
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_option)}",
                   TheOptionHasNotBeenCreated.Arrange.Start);

      /* ------------------------------------------------------------ */

      public IArrange<TheOptionHasBeenCreated.Arrange> has_created_a_none()
         => has_not_created_an_option()
           .And(calls_Option_T_None())
           .Recharacterise($"{nameof(the_Client)}_{nameof(has_created_a_none)}");

      /* ------------------------------------------------------------ */

      public IArrange<TheOptionHasBeenCreated.Arrange> has_created_a_some_from(FakeType content)
         => has_not_created_an_option()
           .And(calls_Option_T_Some_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_some_from)} ""{content.Characterisation}""");

      /* ------------------------------------------------------------ */
      // Arrange
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // Act
      /* ------------------------------------------------------------ */

      public IAct<TheOptionHasBeenCreated.Arrange, DoWasCalled.Asserts> calls_Do()
         => AtomicAct<TheOptionHasBeenCreated.Arrange, DoWasCalled.Asserts>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                   arrange => arrange
                             .ToActs()
                             .Do());

      /* ------------------------------------------------------------ */

      public IAct<TheOptionHasBeenCreated.Arrange, DoWasCalledWithExternalState.Asserts> calls_Do_with(FakeExternalState externalState)
         => AtomicAct<TheOptionHasBeenCreated.Arrange, DoWasCalledWithExternalState.Asserts>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do_with)} ""{externalState.Characterisation}""",
                   arrange => arrange
                             .ToActs()
                             .Do(externalState));

      /* ------------------------------------------------------------ */
      // Arrange/Act
      /* ------------------------------------------------------------ */

      public IArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.Asserts> calls_Option_Some_T_with(FakeType content)
         => AtomicArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.Asserts>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_Some_T_with)} ""{content.Characterisation}""",
                   arrange => arrange.CallOptionSomeT(content),
                   arrange => arrange
                             .ToActs()
                             .CallOptionSomeT(content));

      /* ------------------------------------------------------------ */

      public IArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.Asserts> calls_Option_T_None()
         => AtomicArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.Asserts>
           .Create($"{nameof(the_Client)}_{nameof(calls_Option_T_None)}",
                   arrange => arrange.CallOptionTNone(),
                   arrange => arrange
                             .ToActs()
                             .CallOptionTNone());

      /* ------------------------------------------------------------ */

      public IArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.Asserts> calls_Option_T_Some_with(FakeType content)
         => AtomicArrangeAct<TheOptionHasNotBeenCreated.Arrange, TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.Asserts>
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_T_Some_with)} ""{content.Characterisation}""",
                   arrange => arrange.CallOptionTSome(content),
                   arrange => arrange
                             .ToActs()
                             .CallOptionTSome(content));

      /* ------------------------------------------------------------ */
      // Assert
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
   }
}