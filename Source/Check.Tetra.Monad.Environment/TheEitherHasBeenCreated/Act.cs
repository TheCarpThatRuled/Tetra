using Tetra;
using Tetra.Testing;

namespace Check;

public static partial class TheEitherHasBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      //  Methods
      /* ------------------------------------------------------------ */

      public AndDoWasCalledAsserts Do()
      {
         var whenRight = FakeAction<FakeRight>.Create();
         var whenLeft  = FakeAction<FakeLeft>.Create();

         var returnValue = _either.Do(whenLeft.Action,
                                      whenRight.Action);

         return new(_either,
                    whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public AndDoWasCalledWithExternalStateAsserts Do(FakeExternalState externalState)
      {
         var whenRight = FakeAction<FakeExternalState, FakeRight>.Create();
         var whenLeft  = FakeAction<FakeExternalState, FakeLeft>.Create();

         var returnValue = _either.Do(externalState,
                                      whenLeft.Action,
                                      whenRight.Action);

         return new(_either,
                    whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public new BooleanAsserts<TestTerminus> Equals(object? other)
      {
         var actual = _either.Equals(other);

         return BooleanAsserts<TestTerminus>.Create("Return Value",
                                                    actual,
                                                    TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public BooleanAsserts<TestTerminus> EqualsSelf()
         => Equals(_either);

      /* ------------------------------------------------------------ */

      public new ObjectAsserts<int, TestTerminus> GetHashCode()
      {
         var actual = _either.GetHashCode();

         return ObjectAsserts<int, TestTerminus>.Create("Return Value",
                                                        actual,
                                                        TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public BooleanAsserts<TestTerminus> IsARight()
      {
         var returnValue = _either.IsARight();

         return BooleanAsserts<TestTerminus>.Create(@"Return Value",
                                                    returnValue,
                                                    TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public BooleanAsserts<TestTerminus> IsALeft()
      {
         var returnValue = _either.IsALeft();

         return BooleanAsserts<TestTerminus>.Create(@"Return Value",
                                                    returnValue,
                                                    TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public AndMapWasCalledAsserts Map(FakeNewLeft  whenLeftValue,
                                        FakeNewRight whenRightValue)
      {
         var whenLeft  = FakeFunction<FakeLeft, FakeNewLeft>.Create(whenLeftValue);
         var whenRight = FakeFunction<FakeRight, FakeNewRight>.Create(whenRightValue);

         var returnValue = _either.Map(whenLeft.Func,
                                       whenRight.Func);

         return new(whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public AndMapWasCalledWithFuncsToEitherAsserts Map(IEither<FakeNewLeft, FakeNewRight> whenLeftValue,
                                                        IEither<FakeNewLeft, FakeNewRight> whenRightValue)
      {
         var whenLeft  = FakeFunction<FakeLeft, IEither<FakeNewLeft, FakeNewRight>>.Create(whenLeftValue);
         var whenRight = FakeFunction<FakeRight, IEither<FakeNewLeft, FakeNewRight>>.Create(whenRightValue);

         var returnValue = _either.Map(whenLeft.Func,
                                       whenRight.Func);

         return new(whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public AndMapWasCalledWithExternalStateAsserts Map(FakeExternalState externalState,
                                                         FakeNewLeft       whenLeftValue,
                                                         FakeNewRight      whenRightValue)
      {
         var whenLeft  = FakeFunction<FakeExternalState, FakeLeft, FakeNewLeft>.Create(whenLeftValue);
         var whenRight = FakeFunction<FakeExternalState, FakeRight, FakeNewRight>.Create(whenRightValue);

         var returnValue = _either.Map(externalState,
                                       whenLeft.Func,
                                       whenRight.Func);

         return new(whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public AndMapWasCalledWithFuncsToEitherAndExternalStateAsserts Map(FakeExternalState                  externalState,
                                                                        IEither<FakeNewLeft, FakeNewRight> whenLeftValue,
                                                                        IEither<FakeNewLeft, FakeNewRight> whenRightValue)
      {
         var whenLeft  = FakeFunction<FakeExternalState, FakeLeft, IEither<FakeNewLeft, FakeNewRight>>.Create(whenLeftValue);
         var whenRight = FakeFunction<FakeExternalState, FakeRight, IEither<FakeNewLeft, FakeNewRight>>.Create(whenRightValue);

         var returnValue = _either.Map(externalState,
                                       whenLeft.Func,
                                       whenRight.Func);

         return new(whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public AndReduceWasCalledAsserts Reduce(FakeNewType whenLeftValue,
                                              FakeNewType whenRightValue)
      {
         var whenRight = FakeFunction<FakeRight, FakeNewType>.Create(whenRightValue);
         var whenLeft  = FakeFunction<FakeLeft, FakeNewType>.Create(whenLeftValue);

         var returnValue = _either.Reduce(whenLeft.Func,
                                          whenRight.Func);

         return new(whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public AndReduceWasCalledWithExternalStateAsserts Reduce(FakeExternalState externalState,
                                                               FakeNewType       whenLeftValue,
                                                               FakeNewType       whenRightValue)
      {
         var whenRight = FakeFunction<FakeExternalState, FakeRight, FakeNewType>.Create(whenRightValue);
         var whenLeft  = FakeFunction<FakeExternalState, FakeLeft, FakeNewType>.Create(whenLeftValue);

         var returnValue = _either.Reduce(externalState,
                                          whenLeft.Func,
                                          whenRight.Func);

         return new(whenLeft,
                    whenRight,
                    returnValue);
      }

      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeLeft, TestTerminus> ReduceLeftToOption()
      {
         var actual = _either.ReduceLeftToOption();

         return OptionAsserts<FakeLeft, TestTerminus>.Create("Return Value",
                                                             actual,
                                                             TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public OptionAsserts<FakeRight, TestTerminus> ReduceRightToOption()
      {
         var actual = _either.ReduceRightToOption();

         return OptionAsserts<FakeRight, TestTerminus>.Create("Return Value",
                                                              actual,
                                                              TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */

      public new ObjectAsserts<string?, TestTerminus> ToString()
      {
         var actual = _either.ToString();

         return ObjectAsserts<string?, TestTerminus>.Create("Return Value",
                                                            actual,
                                                            TestTerminus.Create);
      }

      /* ------------------------------------------------------------ */
      //  Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act(IEither<FakeLeft, FakeRight> either)
         => _either = either;

      /* ------------------------------------------------------------ */
      //  Private Fields
      /* ------------------------------------------------------------ */

      private readonly IEither<FakeLeft, FakeRight> _either;

      /* ------------------------------------------------------------ */
   }
}