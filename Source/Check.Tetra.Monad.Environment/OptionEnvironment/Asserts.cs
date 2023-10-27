using Tetra;
using Tetra.Testing;

namespace Check.OptionEnvironment;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeActions                                    _actions;
   private readonly FakeFunctions                                  _functions;
   private readonly IReadOnlyDictionary<string, IOption<FakeType>> _options;
   private readonly object?                                        _returnValue;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Asserts
   (
      object?                                        returnValue,
      IReadOnlyDictionary<string, IOption<FakeType>> options,
      FakeActions                                    actions,
      FakeFunctions                                  functions
   )
   {
      _actions     = actions;
      _functions   = functions;
      _options     = options;
      _returnValue = returnValue;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ActionAsserts<Asserts> Action
   (
      string name
   )
      => ActionAsserts<Asserts>
        .Create(name,
                _actions.Get(name) ?? throw Failed.Assert($@"The test has not created a {nameof(FakeAction)} for ""{name}"""),
                () => this);

   /* ------------------------------------------------------------ */

   public ActionAsserts<T, Asserts> Action<T>
   (
      string name
   )
      => ActionAsserts<T, Asserts>
        .Create(name,
                _actions.Get<T>(name) ?? throw Failed.Assert($@"The test has not created a {nameof(FakeAction)}<{typeof(T).Name}> for ""{name}"""),
                () => this);

   /* ------------------------------------------------------------ */

   public ActionAsserts<T0, T1, Asserts> Action<T0, T1>
   (
      string name
   )
      => ActionAsserts<T0, T1, Asserts>
        .Create(name,
                _actions.Get<T0, T1>(name) ?? throw Failed.Assert($@"The test has not created a {nameof(FakeAction)}<{typeof(T0).Name}, {typeof(T1).Name}> for ""{name}"""),
                () => this);

   /* ------------------------------------------------------------ */

   public FuncAsserts<TReturn, Asserts> Function<TReturn>
   (
      string name
   )
      => FuncAsserts<TReturn, Asserts>
        .Create(name,
                _functions.Get<TReturn>(name)
             ?? throw Failed.Assert($@"The test has not created a {nameof(FakeFunction<TReturn>)}<{typeof(TReturn).Name}> for ""{name}"""),
                () => this);

   /* ------------------------------------------------------------ */

   public FuncAsserts<T, TReturn, Asserts> Function<T, TReturn>
   (
      string name
   )
      => FuncAsserts<T, TReturn, Asserts>
        .Create(name,
                _functions.Get<T, TReturn>(name)
             ?? throw Failed.Assert($@"The test has not created a {nameof(FakeFunction<TReturn>)}<{typeof(T).Name}, {typeof(TReturn).Name}> for ""{name}"""),
                () => this);

   /* ------------------------------------------------------------ */

   public FuncAsserts<T0, T1, TReturn, Asserts> Function<T0, T1, TReturn>
   (
      string name
   )
      => FuncAsserts<T0, T1, TReturn, Asserts>
        .Create(name,
                _functions.Get<T0, T1, TReturn>(name)
             ?? throw Failed.Assert($@"The test has not created a {nameof(FakeFunction<TReturn>)}<{typeof(T0).Name}, {typeof(T1).Name}, {typeof(TReturn).Name}> for ""{name}"""),
                () => this);

   /* ------------------------------------------------------------ */

   public ObjectAsserts<T, Asserts> Returns<T>()
      => ObjectAsserts<T, Asserts>
        .Create("return value",
                (T) _returnValue,
                () => this);

   /* ------------------------------------------------------------ */

   public BooleanAsserts<Asserts> ReturnsABoolean()
      => BooleanAsserts<Asserts>
        .Create("return value",
                (bool) _returnValue,
                () => this);

   /* ------------------------------------------------------------ */

   public EitherAsserts<TLeft, TRight, Asserts> ReturnsAnEither<TLeft, TRight>()
      => EitherAsserts<TLeft, TRight, Asserts>
        .Create("return value",
                (IEither<TLeft, TRight>) _returnValue,
                () => this);

   /* ------------------------------------------------------------ */

   public OptionAsserts<T, Asserts> ReturnsAnOption<T>()
      => OptionAsserts<T, Asserts>
        .Create("return value",
                (IOption<T>) _returnValue,
                () => this);

   /* ------------------------------------------------------------ */

   public ReturnsThisAsserts<Asserts> ReturnsThis
   (
      string name
   )
      => ReturnsThisAsserts<Asserts>
        .Create(_options[name],
                _returnValue,
                () => this);

   /* ------------------------------------------------------------ */
}