namespace Tetra.Testing;

public sealed class FakeFunction<T0, T1, TReturn>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly List<(T0, T1)> _invocations = new();

   private TReturn _returnValue;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeFunction
   (
      TReturn returnValue
   )
      => _returnValue = returnValue;
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Creates a <c>FakeFunction</c> that will return a value when invoked.
   /// </summary>
   /// <param name="returnValue">The value that should be returned when this is invoked.</param>
   /// <returns>A <c>FakeFunction</c> that will return <c>returnValue</c> when invoked.</returns>
   public static FakeFunction<T0, T1, TReturn> Create
   (
      TReturn returnValue
   )
      => new(returnValue);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    A list of the parameters this <c>FakeFunction</c> has been invoked with
   /// </summary>
   public IReadOnlyList<(T0, T1)> Invocations()
      => _invocations;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    The method that should be passed into the argument that should be faked.
   /// </summary>
   public TReturn Func
   (
      T0 arg0,
      T1 arg1
   )
   {
      _invocations.Add((arg0, arg1));

      return _returnValue;
   }

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Resets the invocation trace.
   /// </summary>
   public void PrepareForAct()
      => _invocations
        .Clear();

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Update the value that should be returned when this <c>FakeFunction</c> is invoked.
   /// </summary>
   /// <param name="returnValue">The value that should be returned when this is invoked.</param>
   public void UpdateReturnValue
   (
      TReturn returnValue
   )
      => _returnValue = returnValue;

   /* ------------------------------------------------------------ */
}