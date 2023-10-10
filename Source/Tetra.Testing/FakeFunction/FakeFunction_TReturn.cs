namespace Tetra.Testing;

public sealed class FakeFunction<TReturn>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private int _invocations;

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
   public static FakeFunction<TReturn> Create
   (
      TReturn returnValue
   )
      => new(returnValue);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    The number of times this <c>FakeFunction</c> has been invoked.
   /// </summary>
   public int Invocations()
      => _invocations;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    The method that should be passed into the argument that should be faked.
   /// </summary>
   public TReturn Func()
   {
      ++_invocations;

      return _returnValue;
   }

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Resets the invocation count.
   /// </summary>
   public void PrepareForAct()
      => _invocations = 0;

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