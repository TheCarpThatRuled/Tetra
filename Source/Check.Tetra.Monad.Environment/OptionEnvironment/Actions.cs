using Tetra;
using Tetra.Testing;

namespace Check.OptionEnvironment;

public sealed class Actions : TestEnvironment<Asserts>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Dictionary<string, IOption<FakeType>> _options   = new();
   private readonly FakeActions                           _actions   = FakeActions.Create();
   private readonly FakeFunctions                         _functions = FakeFunctions.Create();

   //Mutable
   private bool    _captureReturnValue = false;
   private object? _returnValue;

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
      => new(_returnValue,
             _options,
             _actions,
             _functions);

   /* ------------------------------------------------------------ */

   protected override void Finalise()
      => _captureReturnValue = true;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CallOptionTNone
   (
      string name
   )
   {
      var option = Option<FakeType>.None();

      _options.Add(name,
                   option);

      if (_captureReturnValue)
      {
         _returnValue = option;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallOptionSome
   (
      string   name,
      FakeType content
   )
   {
      var option = Option.Some(content);

      _options.Add(name,
                   option);

      if (_captureReturnValue)
      {
         _returnValue = option;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallOptionTSome
   (
      string   name,
      FakeType content
   )
   {
      var option = Option<FakeType>.Some(content);

      _options.Add(name,
                   option);

      if (_captureReturnValue)
      {
         _returnValue = option;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallDo
   (
      string optionName,
      string whenNoneName,
      string whenSomeName
   )
   {
      _actions.Create(whenNoneName);
      _actions.Create<FakeType>(whenSomeName);

      var returnValue = _options[optionName]
        .Do(_actions.Get<FakeType>(whenSomeName)!.Action,
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
      string            optionName,
      string            whenNoneName,
      string            whenSomeName,
      FakeExternalState externalState
   )
   {
      _actions.Create<FakeExternalState>(whenNoneName);
      _actions.Create<FakeExternalState, FakeType>(whenSomeName);

      var returnValue = _options[optionName]
        .Do(externalState,
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
      string  optionName,
      object? other
   )
   {
      var returnValue = _options[optionName]
        .Equals(other);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallEqualsWithSelf
   (
      string optionName
   )
   {
      var option = _options[optionName];

      // ReSharper disable once EqualExpressionComparison
      var returnValue = option.Equals(option);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallGetHashCode
   (
      string optionName
   )
   {
      var returnValue = _options[optionName]
        .GetHashCode();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallIsANone
   (
      string optionName
   )
   {
      var returnValue = _options[optionName]
        .IsANone();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallIsASome
   (
      string optionName
   )
   {
      var returnValue = _options[optionName]
        .IsASome();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallExpandSomeToLeft
   (
      string    optionName,
      string    whenNoneName,
      FakeRight whenNoneValue
   )
   {
      _functions.Create(whenNoneName,
                        whenNoneValue);

      var returnValue = _options[optionName]
        .ExpandSomeToLeft(_functions.Get<FakeRight>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallExpandSomeToLeft
   (
      string            optionName,
      string            whenNoneName,
      FakeRight         whenNoneValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeRight>(whenNoneName,
                                                      whenNoneValue);

      var returnValue = _options[optionName]
        .ExpandSomeToLeft(externalState,
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
      string   optionName,
      string   whenNoneName,
      FakeLeft whenNoneValue
   )
   {
      _functions.Create(whenNoneName,
                        whenNoneValue);

      var returnValue = _options[optionName]
        .ExpandSomeToRight(_functions.Get<FakeLeft>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallExpandSomeToRight
   (
      string            optionName,
      string            whenNoneName,
      FakeLeft          whenNoneValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeLeft>(whenNoneName,
                                                     whenNoneValue);

      var returnValue = _options[optionName]
        .ExpandSomeToRight(externalState,
                           _functions.Get<FakeExternalState, FakeLeft>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallMap
   (
      string      optionName,
      string      whenSomeName,
      FakeNewType whenSomeValue
   )
   {
      _functions.Create<FakeType, FakeNewType>(whenSomeName,
                                               whenSomeValue);

      var returnValue = _options[optionName]
        .Map(_functions.Get<FakeType, FakeNewType>(whenSomeName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallMap
   (
      string            optionName,
      string            whenSomeName,
      FakeNewType       whenSomeValue,
      FakeExternalState externalState
   )
   {
      _functions.Create<FakeExternalState, FakeType, FakeNewType>(whenSomeName,
                                                                  whenSomeValue);

      var returnValue = _options[optionName]
        .Map(externalState,
             _functions.Get<FakeExternalState, FakeType, FakeNewType>(whenSomeName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallToString
   (
      string optionName
   )
   {
      var returnValue = _options[optionName]
        .ToString();

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions CallUnify
   (
      string      optionName,
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

      var returnValue = _options[optionName]
        .Unify(_functions.Get<FakeType, FakeNewType>(whenSomeName)!.Func,
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
      string            optionName,
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

      var returnValue = _options[optionName]
        .Unify(externalState,
               _functions.Get<FakeExternalState, FakeType, FakeNewType>(whenSomeName)!.Func,
               _functions.Get<FakeExternalState, FakeNewType>(whenNoneName)!.Func);

      if (_captureReturnValue)
      {
         _returnValue = returnValue;
      }

      return this;
   }

   /* ------------------------------------------------------------ */
}