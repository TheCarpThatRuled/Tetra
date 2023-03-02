namespace Tetra.Testing;

public sealed class FakeAction
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a <c>FakeAction</c> that will record the number of times it was invoked.
   /// </summary>
   /// <returns>A <c>FakeAction</c>.</returns>
   public static FakeAction Create()
      => new();

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The number of times this <c>FakeAction</c> has been invoked.
   /// </summary>
   public int Invocations()
      => _invocations;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The method that should be passed into the argument that should be faked.
   /// </summary>
   public void Action()
      => ++_invocations;

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Resets the invocation count.
   /// </summary>
   public void PrepareForAct()
      => _invocations = 0;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private int _invocations = 0;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeAction() { }

   /* ------------------------------------------------------------ */
}