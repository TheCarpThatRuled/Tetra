using Tetra;
using Tetra.Testing;

namespace Check.OptionEnvironment;

public sealed class Actions : TestEnvironment<Actions, Asserts>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeActions   _actions   = FakeActions.Create();
   private readonly FakeFunctions _functions = FakeFunctions.Create();

   //Mutable
   private bool               _captureReturnValue = false;
   private object?            _returnValue;
   private IOption<FakeType>? _this;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Actions() { }

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Actions Start
   (
      AAA_test.Disposables _
   )
      => new();

   /* ------------------------------------------------------------ */
   // Protected Overridden TestEnvironment<Actions, Asserts> Methods
   /* ------------------------------------------------------------ */

   protected override Asserts CreateAsserts()
      => new(_this!,
             _returnValue,
             _actions,
             _functions);

   /* ------------------------------------------------------------ */

   protected override Actions PerformFinalise()
   {
      _captureReturnValue = true;

      return this;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CallDo
   (
      string whenNoneName,
      string whenSomeName
   )
   {
      _actions.Create(whenNoneName);
      _actions.Create<FakeType>(whenSomeName);

      var returnValue = This().Do(_actions.Get<FakeType>(whenSomeName)!.Action,
                                  _actions.Get(whenNoneName)!.Action);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallDo
   (
      string            whenNoneName,
      string            whenSomeName,
      FakeExternalState externalState
   )
   {
      _actions.Create<FakeExternalState>(whenNoneName);
      _actions.Create<FakeExternalState, FakeType>(whenSomeName);

      var returnValue = This().Do(externalState,
                                  _actions.Get<FakeExternalState, FakeType>(whenSomeName)!.Action,
                                  _actions.Get<FakeExternalState>(whenNoneName)!.Action);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
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

   public Actions CallExpandSomeToLeft
   (
      string    whenNoneName,
      FakeRight whenNoneValue
   )
   {
      _functions.Create(whenNoneName,
                        whenNoneValue);

      var returnValue = This().ExpandSomeToLeft(_functions.Get<FakeRight>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallExpandSomeToLeft
   (
      string            whenNoneName,
      FakeRight         whenNoneValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeRight>(whenNoneName,
                                                      whenNoneValue);

      var returnValue = This().ExpandSomeToLeft(externalState,
                                                _functions.Get<FakeExternalState, FakeRight>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallExpandSomeToRight
   (
      string   whenNoneName,
      FakeLeft whenNoneValue
   )
   {
      _functions.Create(whenNoneName,
                        whenNoneValue);

      var returnValue = This().ExpandSomeToRight(_functions.Get<FakeLeft>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallExpandSomeToRight
   (
      string            whenNoneName,
      FakeLeft          whenNoneValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeLeft>(whenNoneName,
                                                     whenNoneValue);

      var returnValue = This().ExpandSomeToRight(externalState,
                                                 _functions.Get<FakeExternalState, FakeLeft>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallIsANone()
   {
      var returnValue = This().IsANone();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallIsASome()
   {
      var returnValue = This().IsASome();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallMap
   (
      string      whenSomeName,
      FakeNewType whenSomeValue
   )
   {
      _functions.Create<FakeType, FakeNewType>(whenSomeName,
                                               whenSomeValue);

      var returnValue = This().Map(_functions.Get<FakeType, FakeNewType>(whenSomeName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallMap
   (
      string            whenSomeName,
      FakeNewType       whenSomeValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeType, FakeNewType>(whenSomeName,
                                                                  whenSomeValue);

      var returnValue = This().Map(externalState,
                                   _functions.Get<FakeExternalState, FakeType, FakeNewType>(whenSomeName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallOptionTNone()
   {
      _this = Option<FakeType>.None();

      if (_captureReturnValue)
      {
         _returnValue = _this;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallOptionSome
   (
      FakeType content
   )
   {
      _this = Option.Some(content);

      if (_captureReturnValue)
      {
         _returnValue = _this;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallOptionTSome
   (
      FakeType content
   )
   {
      _this = Option<FakeType>.Some(content);

      if (_captureReturnValue)
      {
         _returnValue = _this;
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
      string      whenNoneName,
      FakeNewType whenNoneValue,
      string      whenSomeName,
      FakeNewType whenSomeValue
   )
   {
      _functions.Create(whenNoneName,
                        whenNoneValue);
      _functions.Create<FakeType, FakeNewType>(whenSomeName,
                                               whenSomeValue);

      var returnValue = This().Unify(_functions.Get<FakeType, FakeNewType>(whenSomeName)!.Func,
                                     _functions.Get<FakeNewType>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallUnify
   (
      string            whenNoneName,
      FakeNewType       whenNoneValue,
      string            whenSomeName,
      FakeNewType       whenSomeValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeNewType>(whenNoneName,
                                                        whenNoneValue);
      _functions.Create<FakeExternalState, FakeType, FakeNewType>(whenSomeName,
                                                                  whenSomeValue);

      var returnValue = This().Unify(externalState,
                                     _functions.Get<FakeExternalState, FakeType, FakeNewType>(whenSomeName)!.Func,
                                     _functions.Get<FakeExternalState, FakeNewType>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   public IOption<FakeType> This()
      => _this ?? throw Failed.InTestSetup("The unit under test has not been created");

   /* ------------------------------------------------------------ */
}