using Tetra.Testing;
using static Tetra.Testing.AAA_test;

namespace Check;

partial class Steps
{
   partial class TheClient
   {
      public sealed class OnTheOption
      {
         /* ------------------------------------------------------------ */
         // Act
         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndDoWasCalledAsserts> calls_Do()
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndDoWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                      arrange => arrange
                                .ToActs()
                                .Do());

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts> calls_Do_with
         (
            FakeExternalState externalState
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndDoWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Do_with)} ""{externalState.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Do(externalState));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_Equals_with
         (
            object? other
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Equals_with)} ""{other}""",
                      arrange => arrange
                                .ToActs()
                                .Equals(other));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_Equals_with_self()
            => AtomicAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($"{nameof(the_Client)}_{nameof(calls_Equals_with_self)}",
                      arrange => arrange
                                .ToActs()
                                .EqualsSelf());

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, ObjectAsserts<int, TestTerminus>> calls_GetHashCode()
            => AtomicAct<TheOptionHasBeenCreated.Arrange, ObjectAsserts<int, TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_GetHashCode)}",
                      arrange => arrange
                                .ToActs()
                                .GetHashCode());

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_IsANone()
            => AtomicAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_IsANone)}",
                      arrange => arrange
                                .ToActs()
                                .IsANone());

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>> calls_IsASome()
            => AtomicAct<TheOptionHasBeenCreated.Arrange, BooleanAsserts<TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_IsASome)}",
                      arrange => arrange
                                .ToActs()
                                .IsASome());

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts> calls_ExpandSomeToLeft_with
         (
            FakeRight whenNoneValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} ""{whenNoneValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .ExpandSomeToLeft(whenNoneValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts> calls_ExpandSomeToLeft_with
         (
            FakeExternalState externalState,
            FakeRight         whenNoneValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToLeftWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} ""{externalState.Characterisation}"", ""{whenNoneValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .ExpandSomeToLeft(externalState,
                                                  whenNoneValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts> calls_ExpandSomeToRight_with
         (
            FakeLeft whenNoneValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} ""{whenNoneValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .ExpandSomeToRight(whenNoneValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts> calls_ExpandSomeToRight_with
         (
            FakeExternalState externalState,
            FakeLeft          whenNoneValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndExpandSomeToRightWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} ""{externalState.Characterisation}"", ""{whenNoneValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .ExpandSomeToRight(externalState,
                                                   whenNoneValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndMapWasCalledAsserts> calls_Map_with
         (
            FakeNewType whenSomeValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndMapWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{whenSomeValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Map(whenSomeValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts> calls_Map_with
         (
            FakeExternalState externalState,
            FakeNewType       whenSomeValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndMapWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{externalState.Characterisation}"", ""{whenSomeValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Map(externalState,
                                     whenSomeValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts> calls_Unify_with
         (
            FakeNewType whenSomeValue,
            FakeNewType whenNoneValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndUnifyWasCalledAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{whenSomeValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Unify(whenSomeValue,
                                       whenNoneValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts> calls_Unify_with
         (
            FakeExternalState externalState,
            FakeNewType       whenSomeValue,
            FakeNewType       whenNoneValue
         )
            => AtomicAct<TheOptionHasBeenCreated.Arrange, TheOptionHasBeenCreated.AndUnifyWasCalledWithExternalStateAsserts>
              .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{externalState.Characterisation}"", ""{whenSomeValue.Characterisation}""",
                      arrange => arrange
                                .ToActs()
                                .Unify(externalState,
                                       whenSomeValue,
                                       whenNoneValue));

         /* ------------------------------------------------------------ */

         public IAct<TheOptionHasBeenCreated.Arrange, ObjectAsserts<string?, TestTerminus>> calls_ToString()
            => AtomicAct<TheOptionHasBeenCreated.Arrange, ObjectAsserts<string?, TestTerminus>>
              .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                      arrange => arrange
                                .ToActs()
                                .ToString());

         /* ------------------------------------------------------------ */
      }
   }
}