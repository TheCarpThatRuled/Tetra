using Tetra.Testing;

namespace Check.OptionEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheClient
   {
      /* ------------------------------------------------------------ */
      // Givens
      /* ------------------------------------------------------------ */

      public IInitialAction has_not_created_an_option()
         => AtomicInitialAction
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_option)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialAction has_created_a_none()
         => has_not_created_an_option()
           .And(calls_Option_T_None())
           .Recharacterise($"{nameof(the_Client)}_{nameof(has_created_a_none)}");

      /* ------------------------------------------------------------ */

      public IInitialAction has_created_a_some_from
      (
         FakeType? content
      )
         => has_not_created_an_option()
           .And(calls_Option_T_Some_with(content))
           .Recharacterise($"""
                            {nameof(the_Client)}_{nameof(has_created_a_some_from)} "{content}"
                            """);

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction calls_Option_Some_T_with
      (
         FakeType? content
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Option_Some_T_with)} "{content}"
                    """,
                   arrange => arrange.CallOptionSome(content!));

      /* ------------------------------------------------------------ */

      public IAction calls_Option_T_None()
         => AtomicAction
           .Create($"{nameof(the_Client)}_{nameof(calls_Option_T_None)}",
                   arrange => arrange.CallOptionTNone());

      /* ------------------------------------------------------------ */

      public IAction calls_Option_T_Some_with
      (
         FakeType? content
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Option_T_Some_with)} "{content}"
                    """,
                   arrange => arrange.CallOptionTSome(content!));

      /* ------------------------------------------------------------ */

      public IAction calls_Do()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                   arrange => arrange.CallDo(WhenNone,
                                             WhenSome));

      /* ------------------------------------------------------------ */

      public IAction calls_Do_with
      (
         FakeExternalState externalState
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Do_with)} "{externalState}"
                    """,
                   arrange => arrange.CallDo(WhenNone,
                                             WhenSome,
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

      public IAction calls_IsANone()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsANone)}",
                   arrange => arrange.CallIsANone());

      /* ------------------------------------------------------------ */

      public IAction calls_IsASome()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsASome)}",
                   arrange => arrange.CallIsASome());

      /* ------------------------------------------------------------ */

      public IAction calls_ExpandSomeToLeft_with
      (
         FakeRight whenNoneValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} "{whenNoneValue}"
                    """,
                   arrange => arrange.CallExpandSomeToLeft(WhenNone,
                                                           whenNoneValue));

      /* ------------------------------------------------------------ */

      public IAction calls_ExpandSomeToLeft_with
      (
         FakeExternalState externalState,
         FakeRight         whenNoneValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} "{externalState}", "{whenNoneValue}"
                    """,
                   arrange => arrange.CallExpandSomeToLeft(WhenNone,
                                                           whenNoneValue,
                                                           externalState));

      /* ------------------------------------------------------------ */

      public IAction calls_ExpandSomeToRight_with
      (
         FakeLeft whenNoneValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} "{whenNoneValue}"
                    """,
                   arrange => arrange.CallExpandSomeToRight(WhenNone,
                                                            whenNoneValue));

      /* ------------------------------------------------------------ */

      public IAction calls_ExpandSomeToRight_with
      (
         FakeExternalState externalState,
         FakeLeft          whenNoneValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} "{externalState}", "{whenNoneValue}"
                    """,
                   arrange => arrange.CallExpandSomeToRight(WhenNone,
                                                            whenNoneValue,
                                                            externalState));

      /* ------------------------------------------------------------ */

      public IAction calls_Map_with
      (
         FakeNewType whenSomeValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Map_with)} "{whenSomeValue}"
                    """,
                   arrange => arrange.CallMap(WhenSome,
                                              whenSomeValue));

      /* ------------------------------------------------------------ */

      public IAction calls_Map_with
      (
         FakeExternalState externalState,
         FakeNewType       whenSomeValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Map_with)} "{externalState}", "{whenSomeValue}"
                    """,
                   arrange => arrange.CallMap(WhenSome,
                                              whenSomeValue,
                                              externalState));

      /* ------------------------------------------------------------ */

      public IAction calls_ToString()
         => AtomicAction
           .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                   arrange => arrange.CallToString());

      /* ------------------------------------------------------------ */

      public IAction calls_Unify_with
      (
         FakeNewType whenSomeValue,
         FakeNewType whenNoneValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Unify_with)} "{whenSomeValue}"
                    """,
                   arrange => arrange.CallUnify(WhenNone,
                                                whenNoneValue,
                                                WhenSome,
                                                whenSomeValue));

      /* ------------------------------------------------------------ */

      public IAction calls_Unify_with
      (
         FakeExternalState externalState,
         FakeNewType       whenSomeValue,
         FakeNewType       whenNoneValue
      )
         => AtomicAction
           .Create($"""
                    {nameof(the_Client)}_{nameof(calls_Unify_with)} "{externalState}", "{whenSomeValue}"
                    """,
                   arrange => arrange.CallUnify(WhenNone,
                                                whenNoneValue,
                                                WhenSome,
                                                whenSomeValue,
                                                externalState));

      /* ------------------------------------------------------------ */
   }
}