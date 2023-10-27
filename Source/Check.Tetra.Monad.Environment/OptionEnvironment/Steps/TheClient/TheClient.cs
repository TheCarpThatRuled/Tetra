using Tetra.Testing;
using static Check.Names;
using static Tetra.Testing.AAA_test<Check.OptionEnvironment.Actions, Check.OptionEnvironment.Asserts>;

namespace Check.OptionEnvironment;

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
                   OptionEnvironment.Actions.Start);

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
      // Arrange
      /* ------------------------------------------------------------ */


      /* ------------------------------------------------------------ */
      // Arrange/Act
      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Option_Some_T_with
      (
         FakeType? content
      )
         => AtomicArrangeAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_Some_T_with)} ""{content}""",
                   arrange => arrange.CallOptionSome(This,
                                                     content!));

      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Option_T_None()
         => AtomicArrangeAct
           .Create($"{nameof(the_Client)}_{nameof(calls_Option_T_None)}",
                   arrange => arrange.CallOptionTNone(This));

      /* ------------------------------------------------------------ */

      public IArrangeAct calls_Option_T_Some_with
      (
         FakeType? content
      )
         => AtomicArrangeAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Option_T_Some_with)} ""{content}""",
                  arrange => arrange.CallOptionTSome(This,
                                                     content!));

      /* ------------------------------------------------------------ */
      // Act
      /* ------------------------------------------------------------ */

      public IAct calls_Do()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do)}",
                   arrange => arrange.CallDo(This,
                                             WhenNone,
                                             WhenSome));

      /* ------------------------------------------------------------ */

      public IAct calls_Do_with
      (
         FakeExternalState externalState
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Do_with)} ""{externalState}""",
                   arrange => arrange.CallDo(This,
                                             WhenNone,
                                             WhenSome,
                                             externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_Equals_with
      (
         object? other
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Equals_with)} ""{other}""",
                   arrange => arrange.CallEquals(This,
                                                 other));

      /* ------------------------------------------------------------ */

      public IAct calls_Equals_with_self()
         => AtomicAct
           .Create($"{nameof(the_Client)}_{nameof(calls_Equals_with_self)}",
                   arrange => arrange.CallEqualsWithSelf(This));


      /* ------------------------------------------------------------ */

      public IAct calls_GetHashCode()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_GetHashCode)}",
                   arrange => arrange.CallGetHashCode(This));

      /* ------------------------------------------------------------ */

      public IAct calls_IsANone()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsANone)}",
                   arrange => arrange.CallIsANone(This));

      /* ------------------------------------------------------------ */

      public IAct calls_IsASome()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_IsASome)}",
                   arrange => arrange.CallIsASome(This));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToLeft_with
      (
         FakeRight whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToLeft(This,
                                                            WhenNone,
                                                            whenNoneValue));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToLeft_with
      (
         FakeExternalState externalState,
         FakeRight whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToLeft_with)} ""{externalState}"", ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToLeft(This,
                                                            WhenNone,
                                                            whenNoneValue,
                                                            externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToRight_with
      (
         FakeLeft whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToRight(This,
                                                            WhenNone,
                                                            whenNoneValue));

      /* ------------------------------------------------------------ */

      public IAct calls_ExpandSomeToRight_with
      (
         FakeExternalState externalState,
         FakeLeft whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ExpandSomeToRight_with)} ""{externalState}"", ""{whenNoneValue}""",
                   arrange => arrange.CallExpandSomeToRight(This,
                                                            WhenNone,
                                                            whenNoneValue,
                                                            externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_Map_with
      (
         FakeNewType whenSomeValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{whenSomeValue}""",
                   arrange => arrange.CallMap(This,
                                              WhenSome,
                                              whenSomeValue));

      /* ------------------------------------------------------------ */

      public IAct calls_Map_with
      (
         FakeExternalState externalState,
         FakeNewType whenSomeValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Map_with)} ""{externalState}"", ""{whenSomeValue}""",
                   arrange => arrange.CallMap(This,
                                              WhenSome,
                                              whenSomeValue,
                                              externalState));

      /* ------------------------------------------------------------ */

      public IAct calls_ToString()
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_ToString)}",
                   arrange => arrange.CallToString(This));

      /* ------------------------------------------------------------ */

      public IAct calls_Unify_with
      (
         FakeNewType whenSomeValue,
         FakeNewType whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{whenSomeValue}""",
                   arrange => arrange.CallUnify(This,
                                                WhenNone,
                                                whenNoneValue,
                                                WhenSome,
                                                whenSomeValue));

      /* ------------------------------------------------------------ */

      public IAct calls_Unify_with
      (
         FakeExternalState externalState,
         FakeNewType whenSomeValue,
         FakeNewType whenNoneValue
      )
         => AtomicAct
           .Create($@"{nameof(the_Client)}_{nameof(calls_Unify_with)} ""{externalState}"", ""{whenSomeValue}""",
                   arrange => arrange.CallUnify(This,
                                                WhenNone,
                                                whenNoneValue,
                                                WhenSome,
                                                whenSomeValue,
                                                externalState));

      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // Assert
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
   }
}