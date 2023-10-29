using Tetra;
using Tetra.Testing;

namespace Check.EitherEnvironment;

public sealed class Actions : TestEnvironment<Asserts>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeActions   _actions   = FakeActions.Create();
   private readonly FakeFunctions _functions = FakeFunctions.Create();

   //Mutable
   private bool                          _captureReturnValue = false;
   private object?                       _returnValue;
   private IEither<FakeLeft, FakeRight>? _this;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Actions() { }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Actions Start
   (
      AAA_test1.Disposables _
   )
      => new();

   /* ------------------------------------------------------------ */
   // Protected Overridden TestEnvironment<Asserts> Methods
   /* ------------------------------------------------------------ */

   protected override Asserts CreateAsserts()
      => new(_this!,
             _returnValue,
             _actions,
             _functions);

   /* ------------------------------------------------------------ */

   protected override void Finalise()
      => _captureReturnValue = true;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CallDo
   (
      string whenLeftName,
      string whenRightName
   )
   {
      _actions.Create<FakeLeft>(whenLeftName);
      _actions.Create<FakeRight>(whenRightName);

      var returnValue = This().Do(_actions.Get<FakeLeft>(whenLeftName)!.Action,
                                  _actions.Get<FakeRight>(whenRightName)!.Action);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallDo
   (
      string            whenLeftName,
      string            whenRightName,
      FakeExternalState externalState
   )
   {
      _actions.Create<FakeExternalState, FakeLeft>(whenLeftName);
      _actions.Create<FakeExternalState, FakeRight>(whenRightName);

      var returnValue = This().Do(externalState,
                                  _actions.Get<FakeExternalState, FakeLeft>(whenLeftName)!.Action,
                                  _actions.Get<FakeExternalState, FakeRight>(whenRightName)!.Action);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallEitherLeft
   (
      FakeLeft content
   )
   {
      _this = Either<FakeLeft, FakeRight>.Left(content);

      if (_captureReturnValue)
      {
         _returnValue = _this;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallEitherRight
   (
      FakeRight content
   )
   {
      _this = Either<FakeLeft, FakeRight>.Right(content);

      if (_captureReturnValue)
      {
         _returnValue = _this;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallEquals
   (
      object? other
   )
   {
      var returnValue = This().Equals(other);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallEqualsWithSelf()
   {
      // ReSharper disable once EqualExpressionComparison
      var returnValue = This().Equals(_this);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallGetHashCode()
   {
      var returnValue = This().GetHashCode();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallIsALeft()
   {
      var returnValue = This().IsALeft();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallIsARight()
   {
      var returnValue = This().IsARight();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallReduceLeftToOption()
   {
      var returnValue = This().ReduceLeftToOption();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallReduceRightToOption()
   {
      var returnValue = This().ReduceRightToOption();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallMap
   (
      string      whenLeftName,
      FakeNewLeft whenLeftValue,
      string      whenRightName,
      FakeNewRight whenRightValue
   )
   {
      _functions.Create<FakeLeft, FakeNewLeft>(whenLeftName,
                                               whenLeftValue);
      _functions.Create<FakeRight, FakeNewRight>(whenRightName,
                                                whenRightValue);

      var returnValue = This().Map(_functions.Get<FakeLeft, FakeNewLeft>(whenLeftName)!.Func,
                                   _functions.Get<FakeRight, FakeNewRight>(whenRightName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallMap
   (
      string            whenLeftName,
      FakeNewLeft       whenLeftValue,
      string            whenRightName,
      FakeNewRight       whenRightValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeLeft, FakeNewLeft>(whenLeftName,
                                               whenLeftValue);
      _functions.Create<FakeExternalState, FakeRight, FakeNewRight>(whenRightName,
                                                                    whenRightValue);

      var returnValue = This().Map(externalState,
                                   _functions.Get<FakeExternalState, FakeLeft, FakeNewLeft>(whenLeftName)!.Func,
                                   _functions.Get<FakeExternalState, FakeRight, FakeNewRight>(whenRightName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallToString()
   {
      var returnValue = This().ToString();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallUnify
   (
      string      whenLeftName,
      FakeNewType whenLeftValue,
      string      whenRightName,
      FakeNewType whenRightValue
   )
   {
      _functions.Create<FakeLeft, FakeNewType>(whenLeftName,
                                               whenLeftValue);
      _functions.Create<FakeRight, FakeNewType>(whenRightName,
                                                whenRightValue);

      var returnValue = This().Unify(_functions.Get<FakeLeft, FakeNewType>(whenLeftName)!.Func,
                                     _functions.Get<FakeRight, FakeNewType>(whenRightName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallUnify
   (
      string            whenLeftName,
      FakeNewType       whenLeftValue,
      string            whenRightName,
      FakeNewType       whenRightValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeLeft, FakeNewType>(whenLeftName,
                                                                  whenLeftValue);
      _functions.Create<FakeExternalState, FakeRight, FakeNewType>(whenRightName,
                                                                   whenRightValue);

      var returnValue = This().Unify(externalState,
                                    _functions.Get<FakeExternalState, FakeLeft, FakeNewType>(whenLeftName)!.Func,
                                    _functions.Get<FakeExternalState, FakeRight, FakeNewType>(whenRightName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   public IEither<FakeLeft, FakeRight> This()
      => _this ?? throw Failed.InTestSetup("The unit under test has not been created");

   /* ------------------------------------------------------------ */
}