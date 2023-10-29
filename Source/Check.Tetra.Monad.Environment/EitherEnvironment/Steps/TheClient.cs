using Tetra.Testing;

namespace Check.EitherEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheClient
   {
      /* ------------------------------------------------------------ */
      // Given
      /* ------------------------------------------------------------ */

      public IInitialArrange has_not_created_an_either()
         => AtomicInitialArrange
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_either)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialArrange has_created_a_left_from
      (
         FakeLeft? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Left_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_left_from)} ""{content}""");

      /* ------------------------------------------------------------ */

      public IInitialArrange has_created_a_right_from
      (
         FakeRight? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Right_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_right_from)} ""{content}""");

      /* ------------------------------------------------------------ */
      // Arrange/Act
      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Either_Left_with
      (
         FakeLeft? content
      )
         => AtomicArrangeAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Either_Left_with)} ""{content}""",
                   arrange => arrange.CallEitherLeft(content!));

      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Either_Right_with
      (
         FakeRight? content
      )
         => AtomicArrangeAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Either_Right_with)} ""{content}""",
                   arrange => arrange.CallEitherRight(content!));

      /* ------------------------------------------------------------ */
      // Act
      /* ------------------------------------------------------------ */

      public IAct calls_Do()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                   arrange => arrange.CallDo(WhenLeft,
                                             WhenRight));

      /* ------------------------------------------------------------ */

      public IAct calls_Do_with
      (
         FakeExternalState externalState
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do_with)} ""{externalState}""",
                   arrange => arrange.CallDo(WhenLeft,
                                             WhenRight,
                                             externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_Equals_with
      (
         object? other
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Equals_with)} ""{other}""",
                   arrange => arrange.CallEquals(other));

      /* ------------------------------------------------------------ */

      public IAct calls_Equals_with_self()
         => AtomicAct
           .Create($"{nameof(the_Client)}_{nameof(calls_Equals_with_self)}",
                   arrange => arrange.CallEqualsWithSelf());

      /* ------------------------------------------------------------ */

      public IAct calls_GetHashCode()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_GetHashCode)}",
                   arrange => arrange.CallGetHashCode());

      /* ------------------------------------------------------------ */

      public IAct calls_IsALeft()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsALeft)}",
                   arrange => arrange.CallIsALeft());

      /* ------------------------------------------------------------ */

      public IAct calls_IsARight()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsARight)}",
                   arrange => arrange.CallIsARight());

      /* ------------------------------------------------------------ */

      public IAct calls_Map_with
      (
         FakeNewLeft  whenLeftValue,
         FakeNewRight whenRightValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{whenLeftValue}"", ""{whenRightValue}""",
                   arrange => arrange.CallMap(WhenLeft,
                                              whenLeftValue,
                                              WhenRight,
                                              whenRightValue));

      /* ------------------------------------------------------------ */

      public IAct calls_Map_with
      (
         FakeExternalState externalState,
         FakeNewLeft       whenLeftValue,
         FakeNewRight      whenRightValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{externalState}"", ""{whenLeftValue}"", ""{whenRightValue}""",
                   arrange => arrange.CallMap(WhenLeft,
                                              whenLeftValue,
                                              WhenRight,
                                              whenRightValue,
                                              externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_Unify_with
      (
         FakeNewType whenLeftValue,
         FakeNewType whenRightValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{whenLeftValue}""",
                   arrange => arrange.CallUnify(WhenLeft,
                                                whenLeftValue,
                                                WhenRight,
                                                whenRightValue));

      /* ------------------------------------------------------------ */

      public IAct calls_Unify_with
      (
         FakeExternalState externalState,
         FakeNewType       whenLeftValue,
         FakeNewType       whenRightValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{externalState}"", ""{whenLeftValue}""",
                   arrange => arrange.CallUnify(WhenLeft,
                                                whenLeftValue,
                                                WhenRight,
                                                whenRightValue,
                                                externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_ReduceLeftToOption()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ReduceLeftToOption)}",
                   arrange => arrange.CallReduceLeftToOption());

      /* ------------------------------------------------------------ */

      public IAct calls_ReduceRightToOption()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ReduceRightToOption)}",
                   arrange => arrange.CallReduceRightToOption());

      /* ------------------------------------------------------------ */

      public IAct calls_ToString()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                   arrange => arrange.CallToString());

      /* ------------------------------------------------------------ */
   }
}