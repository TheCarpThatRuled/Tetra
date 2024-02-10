using Tetra.Testing;

namespace Check.EitherEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheClient
   {
      /* ------------------------------------------------------------ */
      // Givens
      /* ------------------------------------------------------------ */

      public IInitialAction has_not_created_an_either()
         => AtomicInitialAction
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_either)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialAction has_created_a_left_from
      (
         FakeLeft? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Left_with(content))
           .Recharacterise($"""
                            {nameof(the_Client)}_{nameof(has_created_a_left_from)} "{content}"
                            """);

      /* ------------------------------------------------------------ */

      public IInitialAction has_created_a_right_from
      (
         FakeRight? content
      )
         => has_not_created_an_either()
           .And(calls_Either_Right_with(content))
           .Recharacterise($"""
                            {nameof(the_Client)}_{nameof(has_created_a_right_from)} "{content}"
                            """);

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction calls_Either_Left_with
      (
         FakeLeft? content
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Either_Left_with)} "{content}"
                    """,
                   arrange => arrange.CallEitherLeft(content!));

      /* ------------------------------------------------------------ */

      public IAction calls_Either_Right_with
      (
         FakeRight? content
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Either_Right_with)} "{content}"
                    """,
                   arrange => arrange.CallEitherRight(content!));

      /* ------------------------------------------------------------ */

      public IAction calls_Do()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                   arrange => arrange.CallDo(WhenLeft,
                                             WhenRight));

      /* ------------------------------------------------------------ */

      public IAction calls_Do_with
      (
         FakeExternalState externalState
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Do_with)} "{externalState}"
                    """,
                   arrange => arrange.CallDo(WhenLeft,
                                             WhenRight,
                                             externalState));

      /* ------------------------------------------------------------ */

      public IAction calls_Equals_with
      (
         object? other
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Equals_with)} "{other}"
                    """,
                   arrange => arrange.CallEquals(other));

      /* ------------------------------------------------------------ */

      public IAction calls_Equals_with_self()
         => AtomicAction
           .Create($"{nameof(the_Client)}_{nameof(calls_Equals_with_self)}",
                   arrange => arrange.CallEqualsWithSelf());

      /* ------------------------------------------------------------ */

      public IAction calls_GetHashCode()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_GetHashCode)}",
                   arrange => arrange.CallGetHashCode());

      /* ------------------------------------------------------------ */

      public IAction calls_IsALeft()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsALeft)}",
                   arrange => arrange.CallIsALeft());

      /* ------------------------------------------------------------ */

      public IAction calls_IsARight()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsARight)}",
                   arrange => arrange.CallIsARight());

      /* ------------------------------------------------------------ */

      public IAction calls_Map_with
      (
         FakeNewLeft  whenLeftValue,
         FakeNewRight whenRightValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Map_with)} "{whenLeftValue}", "{whenRightValue}"
                    """,
                   arrange => arrange.CallMap(WhenLeft,
                                              whenLeftValue,
                                              WhenRight,
                                              whenRightValue));

      /* ------------------------------------------------------------ */

      public IAction calls_Map_with
      (
         FakeExternalState externalState,
         FakeNewLeft       whenLeftValue,
         FakeNewRight      whenRightValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Map_with)} "{externalState}", "{whenLeftValue}", "{whenRightValue}"
                    """,
                   arrange => arrange.CallMap(WhenLeft,
                                              whenLeftValue,
                                              WhenRight,
                                              whenRightValue,
                                              externalState));

      /* ------------------------------------------------------------ */

      public IAction calls_Unify_with
      (
         FakeNewType whenLeftValue,
         FakeNewType whenRightValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Unify_with)} "{whenLeftValue}"
                    """,
                   arrange => arrange.CallUnify(WhenLeft,
                                                whenLeftValue,
                                                WhenRight,
                                                whenRightValue));

      /* ------------------------------------------------------------ */

      public IAction calls_Unify_with
      (
         FakeExternalState externalState,
         FakeNewType       whenLeftValue,
         FakeNewType       whenRightValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Unify_with)} "{externalState}", "{whenLeftValue}"
                    """,
                   arrange => arrange.CallUnify(WhenLeft,
                                                whenLeftValue,
                                                WhenRight,
                                                whenRightValue,
                                                externalState));

      /* ------------------------------------------------------------ */

      public IAction calls_ReduceLeftToOption()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_ReduceLeftToOption)}",
                   arrange => arrange.CallReduceLeftToOption());

      /* ------------------------------------------------------------ */

      public IAction calls_ReduceRightToOption()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_ReduceRightToOption)}",
                   arrange => arrange.CallReduceRightToOption());

      /* ------------------------------------------------------------ */

      public IAction calls_ToString()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                   arrange => arrange.CallToString());

      /* ------------------------------------------------------------ */
   }
}