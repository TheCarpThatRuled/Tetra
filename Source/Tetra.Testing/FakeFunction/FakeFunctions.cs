namespace Tetra.Testing;

public sealed class FakeFunctions
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Dictionary<string, object> _functions = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeFunctions() { }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeFunctions Create()
      => new();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void Create<TReturn>
   (
      string  name,
      TReturn returnValue
   )
      => _functions[name] = FakeFunction<TReturn>.Create(returnValue);

   /* ------------------------------------------------------------ */

   public void Create<T0, TReturn>
   (
      string  name,
      TReturn returnValue
   )
      => _functions[name] = FakeFunction<T0, TReturn>.Create(returnValue);

   /* ------------------------------------------------------------ */

   public void Create<T0, T1, TReturn>
   (
      string  name,
      TReturn returnValue
   )
      => _functions[name] = FakeFunction<T0, T1, TReturn>.Create(returnValue);

   /* ------------------------------------------------------------ */

   public FakeFunction<TReturn>? Get<TReturn>
   (
      string name
   )
      => _functions[name] as FakeFunction<TReturn>;

   /* ------------------------------------------------------------ */

   public FakeFunction<T0, TReturn>? Get<T0, TReturn>
   (
      string name
   )
      => _functions[name] as FakeFunction<T0, TReturn>;

   /* ------------------------------------------------------------ */

   public FakeFunction<T0, T1, TReturn>? Get<T0, T1, TReturn>
   (
      string name
   )
      => _functions[name] as FakeFunction<T0, T1, TReturn>;

   /* ------------------------------------------------------------ */
}