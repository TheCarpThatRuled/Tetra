namespace Tetra.Testing;

public sealed class FakeActions
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Dictionary<string, object> _actions = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeActions() { }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeActions Create()
      => new();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void Create
   (
      string name
   )
      => _actions[name] = FakeAction.Create();

   /* ------------------------------------------------------------ */

   public void Create<T>
   (
      string name
   )
      => _actions[name] = FakeAction<T>.Create();

   /* ------------------------------------------------------------ */

   public void Create<T0, T1>
   (
      string name
   )
      => _actions[name] = FakeAction<T0, T1>.Create();

   /* ------------------------------------------------------------ */

   public FakeAction? Get
   (
      string name
   )
      => _actions[name] as FakeAction;

   /* ------------------------------------------------------------ */

   public FakeAction<T>? Get<T>
   (
      string name
   )
      => _actions[name] as FakeAction<T>;

   /* ------------------------------------------------------------ */

   public FakeAction<T0, T1>? Get<T0, T1>
   (
      string name
   )
      => _actions[name] as FakeAction<T0, T1>;

   /* ------------------------------------------------------------ */
}