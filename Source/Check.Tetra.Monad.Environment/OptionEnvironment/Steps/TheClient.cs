using Tetra.Testing;

namespace Check.OptionEnvironment;

using static Names;
using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheClient
   {
      /* ------------------------------------------------------------ */
      // Given
      /* ------------------------------------------------------------ */

      public IInitialArrange has_not_created_an_option()
         => AtomicInitialArrange
           .Create($"{nameof(the_Client)}_{nameof(has_not_created_an_option)}",
                   Actions.Start);

      /* ------------------------------------------------------------ */

      public IInitialArrange has_created_a_none()
         => has_not_created_an_option()
           .And(calls_Option_T_None())
           .Recharacterise($"{nameof(the_Client)}_{nameof(has_created_a_none)}");

      /* ------------------------------------------------------------ */

      public IInitialArrange has_created_a_some_from
      (
         FakeType? content
      )
         => has_not_created_an_option()
           .And(calls_Option_T_Some_with(content))
           .Recharacterise($@"{nameof(the_Client)}_{nameof(has_created_a_some_from)} ""{content}""");

      /* ------------------------------------------------------------ */
      // Arrange/Act
      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Option_Some_T_with
      (
         FakeType? content
      )
         => AtomicArrangeAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_Some_T_with)} ""{content}""",
                   arrange => arrange.CallOptionSome(content!));

      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Option_T_None()
         => AtomicArrangeAct
           .Create($"{nameof(the_Client)}_{nameof(calls_Option_T_None)}",
                   arrange => arrange.CallOptionTNone());

      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Option_T_Some_with
      (
         FakeType? content
      )
         => AtomicArrangeAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_T_Some_with)} ""{content}""",
                   arrange => arrange.CallOptionTSome(content!));

      /* ------------------------------------------------------------ */
      // Act
      /* ------------------------------------------------------------ */

      public IAct calls_Do()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                   arrange => arrange.CallDo(WhenNone,
                                             WhenSome));

      /* ------------------------------------------------------------ */

      public IAct calls_Do_with
      (
         FakeExternalState externalState
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do_with)} ""{externalState}""",
                   arrange => arrange.CallDo(WhenNone,
                                             WhenSome,
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

      public IAct calls_IsANone()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsANone)}",
                   arrange => arrange.CallIsANone());

      /* ------------------------------------------------------------ */

      public IAct calls_IsASome()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsASome)}",
                   arrange => arrange.CallIsASome());

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToLeft_with
      (
         FakeRight whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToLeft(WhenNone,
                                                           whenNoneValue));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToLeft_with
      (
         FakeExternalState externalState,
         FakeRight         whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} ""{externalState}"", ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToLeft(WhenNone,
                                                           whenNoneValue,
                                                           externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToRight_with
      (
         FakeLeft whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToRight(WhenNone,
                                                            whenNoneValue));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToRight_with
      (
         FakeExternalState externalState,
         FakeLeft          whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} ""{externalState}"", ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToRight(WhenNone,
                                                            whenNoneValue,
                                                            externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_Map_with
      (
         FakeNewType whenSomeValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{whenSomeValue}""",
                   arrange => arrange.CallMap(WhenSome,
                                              whenSomeValue));

      /* ------------------------------------------------------------ */

      public IAct calls_Map_with
      (
         FakeExternalState externalState,
         FakeNewType       whenSomeValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{externalState}"", ""{whenSomeValue}""",
                   arrange => arrange.CallMap(WhenSome,
                                              whenSomeValue,
                                              externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_ToString()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                   arrange => arrange.CallToString());

      /* ------------------------------------------------------------ */

      public IAct calls_Unify_with
      (
         FakeNewType whenSomeValue,
         FakeNewType whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{whenSomeValue}""",
                   arrange => arrange.CallUnify(WhenNone,
                                                whenNoneValue,
                                                WhenSome,
                                                whenSomeValue));

      /* ------------------------------------------------------------ */

      public IAct calls_Unify_with
      (
         FakeExternalState externalState,
         FakeNewType       whenSomeValue,
         FakeNewType       whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{externalState}"", ""{whenSomeValue}""",
                   arrange => arrange.CallUnify(WhenNone,
                                                whenNoneValue,
                                                WhenSome,
                                                whenSomeValue,
                                                externalState));

      /* ------------------------------------------------------------ */
   }
}