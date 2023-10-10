using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheClient
   {
      public sealed class OnTheEither
      {
         /* ------------------------------------------------------------ */
         // Act
         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndDoWasCalledAsserts> calls_Do()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndDoWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                      arrange => arrange
                                .ToActs()
                                .Do());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> calls_Do_with
         (
            FakeExternalState externalState
         )
            => AtomicAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Do_with)} ""{externalState.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Do(externalState));

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_Equals_with
         (
            object? other
         )
            => AtomicAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Equals_with)} ""{other}""",
                      arrange => arrange
                                .ToActs()
                                .Equals(other));

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_Equals_with_self()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($"{nameof(the_Client)}_{nameof(calls_Equals_with_self)}",
                      arrange => arrange
                                .ToActs()
                                .EqualsSelf());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, ObjectAsserts<int, TestTerminus>> calls_GetHashCode()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, ObjectAsserts<int, TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_GetHashCode)}",
                      arrange => arrange
                                .ToActs()
                                .GetHashCode());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_IsALeft()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_IsALeft)}",
                      arrange => arrange
                                .ToActs()
                                .IsALeft());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_IsARight()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_IsARight)}",
                      arrange => arrange
                                .ToActs()
                                .IsARight());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndMapWasCalledAsserts> calls_Map_with
         (
            FakeNewLeft  whenLeftValue,
            FakeNewRight whenRightValue
         )
            => AtomicAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndMapWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{whenLeftValue.Characterisation}"", ""{whenRightValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Map(whenLeftValue,
                                     whenRightValue));

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> calls_Map_with
         (
            FakeExternalState externalState,
            FakeNewLeft       whenLeftValue,
            FakeNewRight      whenRightValue
         )
            => AtomicAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>
              .Create(
                  $@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{externalState.Characterisation}"", ""{whenLeftValue.Characterisation}"", ""{whenRightValue.Characterisation}""",
                  arrange => arrange
                            .ToActs()
                            .Map(externalState,
                                 whenLeftValue,
                                 whenRightValue));

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts> calls_Unify_with
         (
            FakeNewType whenLeftValue,
            FakeNewType whenRightValue
         )
            => AtomicAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndUnifyWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{whenLeftValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Unify(whenLeftValue,
                                       whenRightValue));

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts> calls_Unify_with
         (
            FakeExternalState externalState,
            FakeNewType       whenLeftValue,
            FakeNewType       whenRightValue
         )
            => AtomicAct<TheEitherHasBeenCreated.Arrange, TheEitherHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{externalState.Characterisation}"", ""{whenLeftValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Unify(externalState,
                                       whenLeftValue,
                                       whenRightValue));

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, OptionAsserts<FakeLeft, TestTerminus>> calls_ReduceLeftToOption()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, OptionAsserts<FakeLeft, TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ReduceLeftToOption)}",
                      arrange => arrange
                                .ToActs()
                                .ReduceLeftToOption());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, OptionAsserts<FakeRight, TestTerminus>> calls_ReduceRightToOption()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, OptionAsserts<FakeRight, TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ReduceRightToOption)}",
                      arrange => arrange
                                .ToActs()
                                .ReduceRightToOption());

         /* ------------------------------------------------------------ */

         public IAct<TheEitherHasBeenCreated.Arrange, ObjectAsserts<string?, TestTerminus>> calls_ToString()
            => AtomicAct<TheEitherHasBeenCreated.Arrange, ObjectAsserts<string?, TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                      arrange => arrange
                                .ToActs()
                                .ToString());

         /* ------------------------------------------------------------ */
      }
   }
}