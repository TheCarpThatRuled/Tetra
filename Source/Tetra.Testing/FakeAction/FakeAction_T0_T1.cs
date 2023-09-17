namespace Tetra.Testing;

public sealed class FakeAction<T0, T1>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a <c>FakeAction</c> that will record the number of times it was invoked and the parameters it was invoked with.
   /// </summary>
   /// <returns>A <c>FakeAction</c>.</returns>
   public static FakeAction<T0, T1> Create()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   /// <summary>
   /// A list of the parameters this <c>FakeAction</c> has been invoked with
   /// </summary>
   public IReadOnlyList<(T0, T1)> Invocations()
      => _invocations;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The method that should be passed into the argument that should be faked.
   /// </summary>
   public void Action(T0 arg0,
                      T1 arg1)
      => _invocations
        .Add((arg0, arg1));

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Resets the invocation trace.
   /// </summary>
   public void PrepareForAct()
      => _invocations
        .Clear();

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly List<(T0, T1)> _invocations = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeAction() { }

   /* ------------------------------------------------------------ */
}