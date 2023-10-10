namespace Tetra.Testing;

public sealed class FakeEventHandler
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private int _numberOfTimesFired;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeEventHandler
   (
      Action<Action> subscribe
   )
      => subscribe(OnFired);
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeEventHandler Create
   (
      Action<Action> subscribe
   )
      => new(subscribe);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public int NumberOfTimesFired()
      => _numberOfTimesFired;

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   public void OnFired()
      => ++_numberOfTimesFired;

   /* ------------------------------------------------------------ */
}