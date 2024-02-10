namespace Tetra.Testing;

public sealed class BooleanPropertyAsserts<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly bool             _actual;
   private readonly string           _description;
   private readonly Func<T>          _next;
   private readonly Action<Property> _pushProperty;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private BooleanPropertyAsserts
   (
      bool             actual,
      string           description,
      Func<T>          next,
      Action<Property> pushProperty
   )
   {
      _actual       = actual;
      _description  = description;
      _next         = next;
      _pushProperty = pushProperty;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static BooleanPropertyAsserts<T> Create
   (
      Action<Property> pushProperty,
      string           description,
      bool             actual,
      Func<T>          next
   )
      => new(actual,
             description,
             next,
             pushProperty);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public T IsFalse()
   {
      _pushProperty(Properties.IsFalse(_description,
                                       _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */

   public T IsTrue()
   {
      _pushProperty(Properties.IsTrue(_description,
                                      _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */
}