namespace Tetra.Testing;

public sealed class FakeEventHandler
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeEventHandler Create(Action<Action> subscribe)
      => new(subscribe);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public int NumberOfTimesFired()
      => _numberOfTimesFired;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private int _numberOfTimesFired = 0;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeEventHandler(Action<Action> subscribe)
      => subscribe(OnFired);

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   public void OnFired()
      => ++_numberOfTimesFired;

   /* ------------------------------------------------------------ */
}