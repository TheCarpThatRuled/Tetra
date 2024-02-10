using Tetra;
using Tetra.Testing;

namespace Check.EitherEnvironment;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeActions                   _actions;
   private readonly FakeFunctions                 _functions;
   private readonly object?                       _returnValue;
   private readonly IEither<FakeLeft, FakeRight>? _this;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Asserts
   (
      IEither<FakeLeft, FakeRight>? @this,
      object?                       returnValue,
      FakeActions                   actions,
      FakeFunctions                 functions
   )
   {
      _actions     = actions;
      _functions   = functions;
      _returnValue = returnValue;
      _this        = @this;
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
                _actions.Get(name)
             ?? throw Failed
                     .InTheAsserts($"""
                                    The test has not created a {nameof(FakeAction)} for "{name}"
                                    """)
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public ActionAsserts<T, Asserts> Action<T>
   (
      string name
   )
      => ActionAsserts<T, Asserts>
        .Create(name,
                _actions.Get<T>(name)
             ?? throw Failed
                     .InTheAsserts($"""
                                    The test has not created a {nameof(FakeAction)}<{typeof(T).Name}> for "{name}"
                                    """)
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public ActionAsserts<T0, T1, Asserts> Action<T0, T1>
   (
      string name
   )
      => ActionAsserts<T0, T1, Asserts>
        .Create(name,
                _actions.Get<T0, T1>(name)
             ?? throw Failed
                     .InTheAsserts($"""
                                    The test has not created a {nameof(FakeAction)}<{typeof(T0).Name}, {typeof(T1).Name}> for "{name}"
                                    """)
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public FuncAsserts<TReturn, Asserts> Function<TReturn>
   (
      string name
   )
      => FuncAsserts<TReturn, Asserts>
        .Create(name,
                _functions.Get<TReturn>(name)
             ?? throw Failed
                     .InTheAsserts($"""
                                    The test has not created a {nameof(FakeFunction<TReturn>)}<{typeof(TReturn).Name}> for "{name}"
                                    """)
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public FuncAsserts<T, TReturn, Asserts> Function<T, TReturn>
   (
      string name
   )
      => FuncAsserts<T, TReturn, Asserts>
        .Create(name,
                _functions.Get<T, TReturn>(name)
             ?? throw Failed
                     .InTheAsserts($"""
                                    The test has not created a {nameof(FakeFunction<TReturn>)}<{typeof(T).Name}, {typeof(TReturn).Name}> for "{name}"
                                    """)
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public FuncAsserts<T0, T1, TReturn, Asserts> Function<T0, T1, TReturn>
   (
      string name
   )
      => FuncAsserts<T0, T1, TReturn, Asserts>
        .Create(name,
                _functions.Get<T0, T1, TReturn>(name)
             ?? throw Failed
                     .InTheAsserts($"""
                                    The test has not created a {nameof(FakeFunction<TReturn>)}<{typeof(T0).Name}, {typeof(T1).Name}, {typeof(TReturn).Name}> for "{name}"
                                    """)
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public ObjectAsserts<T, Asserts> Returns<T>()
      => ObjectAsserts<T, Asserts>
        .Create("return value",
                (T) _returnValue!,
                () => this);

   /* ------------------------------------------------------------ */

   public BooleanAsserts<Asserts> ReturnsABoolean()
      => BooleanAsserts<Asserts>
        .Create("return value",
                _returnValue as bool?
             ?? throw Failed
                     .InTheAsserts("The return value was not a bool")
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public EitherAsserts<TLeft, TRight, Asserts> ReturnsAnEither<TLeft, TRight>()
      => EitherAsserts<TLeft, TRight, Asserts>
        .Create("return value",
                _returnValue as IEither<TLeft, TRight>
             ?? throw Failed
                     .InTheAsserts($"The return value was not an {nameof(IEither<TLeft, TRight>)}<{typeof(TLeft).Name}, {typeof(TRight).Name}>")
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public OptionAsserts<T, Asserts> ReturnsAnOption<T>()
      => OptionAsserts<T, Asserts>
        .Create("return value",
                _returnValue as IOption<T>
             ?? throw Failed
                     .InTheAsserts($"The return value was not an {nameof(IOption<T>)}<{typeof(T).Name}>")
                     .ToAssertFailedException(),
                () => this);

   /* ------------------------------------------------------------ */

   public ReturnsThisAsserts<Asserts> ReturnsThis()
      => ReturnsThisAsserts<Asserts>
        .Create(_this,
                _returnValue,
                () => this);

   /* ------------------------------------------------------------ */
}