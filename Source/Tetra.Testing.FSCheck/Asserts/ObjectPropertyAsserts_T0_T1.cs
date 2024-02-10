namespace Tetra.Testing;

public sealed class ObjectPropertyAsserts<T, TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T                _actual;
   private readonly string           _description;
   private readonly Func<TNext>      _next;
   private readonly Action<Property> _pushProperty;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ObjectPropertyAsserts
   (
      T                actual,
      string           description,
      Func<TNext>      next,
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

   public static ObjectPropertyAsserts<T, TNext> Create
   (
      Action<Property> pushProperty,
      string           description,
      T                actual,
      Func<TNext>      next
   )
      => new(actual,
             description,
             next,
             pushProperty);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsEqualTo
   (
      T expected
   )
   {
      _pushProperty(Properties.AreEqual(_description,
                                       expected,
                                       _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsReferenceEqualTo
   (
      T expected
   )
   {
      _pushProperty(Properties.AreReferenceEqual(_description,
                                                 expected,
                                                 _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */
}