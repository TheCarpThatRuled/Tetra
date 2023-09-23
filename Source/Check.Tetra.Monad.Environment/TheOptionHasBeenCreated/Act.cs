using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheOptionHasBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public DoWasCalled.Asserts Do()
      {
         var whenNone = FakeAction.Create();
         var whenSome = FakeAction<FakeType>.Create();

         var returnValue = _option.Do(whenSome.Action,
                                      whenNone.Action);

         return new(_option,
                    whenSome,
                    whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public DoWasCalledWithExternalState.Asserts Do(FakeExternalState externalState)
      {
         var whenNone = FakeAction<FakeExternalState>.Create();
         var whenSome = FakeAction<FakeExternalState, FakeType>.Create();

         var returnValue = _option.Do(externalState,
                                      whenSome.Action,
                                      whenNone.Action);

         return new(_option,
                    whenSome,
                    whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public ExpandSomeToLeftWasCalled.Asserts ExpandSomeToLeft(FakeRight whenNoneValue)
      {
         var whenNone = FakeFunction<FakeRight>.Create(whenNoneValue);

         var returnValue = _option.ExpandSomeToLeft(whenNone.Func);

         return new(whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public ExpandSomeToLeftWasCalledWithExternalState.Asserts ExpandSomeToLeft(FakeExternalState externalState,
                                                                                 FakeRight         whenNoneValue)
      {
         var whenNone = FakeFunction<FakeExternalState, FakeRight>.Create(whenNoneValue);

         var returnValue = _option.ExpandSomeToLeft(externalState,
                                                    whenNone.Func);

         return new(whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public ExpandSomeToRightWasCalled.Asserts ExpandSomeToRight(FakeLeft whenNoneValue)
      {
         var whenNone = FakeFunction<FakeLeft>.Create(whenNoneValue);

         var returnValue = _option.ExpandSomeToRight(whenNone.Func);

         return new(whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public ExpandSomeToRightWasCalledWithExternalState.Asserts ExpandSomeToRight(FakeExternalState externalState,
                                                                                   FakeLeft          whenNoneValue)
      {
         var whenNone = FakeFunction<FakeExternalState, FakeLeft>.Create(whenNoneValue);

         var returnValue = _option.ExpandSomeToRight(externalState,
                                                     whenNone.Func);

         return new(whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public new BooleanAsserts<TestTerminus> Equals(object? other)
      {
         var actual = _option.Equals(other);

         return BooleanAsserts<TestTerminus>.Create("Return Value",
                                                    actual,
                                                    TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public BooleanAsserts<TestTerminus> EqualsSelf()
         => Equals(_option);

      /* ------------------------------------------------------------ */

      public new ObjectAsserts<int, TestTerminus> GetHashCode()
      {
         var actual = _option.GetHashCode();

         return ObjectAsserts<int, TestTerminus>.Create("Return Value",
                                                        actual,
                                                        TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public BooleanAsserts<TestTerminus> IsANone()
      {
         var returnValue = _option.IsANone();

         return BooleanAsserts<TestTerminus>.Create(@"Return Value",
                                                    returnValue,
                                                    TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public BooleanAsserts<TestTerminus> IsASome()
      {
         var returnValue = _option.IsASome();

         return BooleanAsserts<TestTerminus>.Create(@"Return Value",
                                                    returnValue,
                                                    TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public MapWasCalled.Asserts Map(FakeNewType whenSomeValue)
      {
         var whenSome = FakeFunction<FakeType, FakeNewType>.Create(whenSomeValue);

         var returnValue = _option.Map(whenSome.Func);

         return new(whenSome,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public MapToOptionWasCalled.Asserts Map(IOption<FakeNewType> whenSomeValue)
      {
         var whenSome = FakeFunction<FakeType, IOption<FakeNewType>>.Create(whenSomeValue);

         var returnValue = _option.Map(whenSome.Func);

         return new(whenSome,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public MapWasCalledWithExternalState.Asserts Map(FakeExternalState externalState,
                                                       FakeNewType       whenSomeValue)
      {
         var whenSome = FakeFunction<FakeExternalState, FakeType, FakeNewType>.Create(whenSomeValue);

         var returnValue = _option.Map(externalState,
                                       whenSome.Func);

         return new(whenSome,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public MapToOptionWasCalledWithExternalState.Asserts Map(FakeExternalState    externalState,
                                                               IOption<FakeNewType> whenSomeValue)
      {
         var whenSome = FakeFunction<FakeExternalState, FakeType, IOption<FakeNewType>>.Create(whenSomeValue);

         var returnValue = _option.Map(externalState,
                                       whenSome.Func);

         return new(whenSome,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public ReduceWasCalled.Asserts Reduce(FakeNewType whenSomeValue,
                                            FakeNewType whenNoneValue)
      {
         var whenNone = FakeFunction<FakeNewType>.Create(whenNoneValue);
         var whenSome = FakeFunction<FakeType, FakeNewType>.Create(whenSomeValue);

         var returnValue = _option.Reduce(whenSome.Func,
                                          whenNone.Func);

         return new(whenSome,
                    whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public ReduceWasCalledWithExternalState.Asserts Reduce(FakeExternalState externalState,
                                                             FakeNewType       whenSomeValue,
                                                             FakeNewType       whenNoneValue)
      {
         var whenNone = FakeFunction<FakeExternalState, FakeNewType>.Create(whenNoneValue);
         var whenSome = FakeFunction<FakeExternalState, FakeType, FakeNewType>.Create(whenSomeValue);

         var returnValue = _option.Reduce(externalState,
                                          whenSome.Func,
                                          whenNone.Func);

         return new(whenSome,
                    whenNone,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public new ObjectAsserts<string?, TestTerminus> ToString()
      {
         var actual = _option.ToString();

         return ObjectAsserts<string?, TestTerminus>.Create("Return Value",
                                                            actual,
                                                            TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act(IOption<FakeType> option)
         => _option = option;

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOption<FakeType> _option;

      /* ------------------------------------------------------------ */
   }
}