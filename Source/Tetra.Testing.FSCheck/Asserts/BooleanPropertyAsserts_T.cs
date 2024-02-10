namespace Tetra.Testing;

public sealed class BooleanPropertyAsserts<TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly bool             _actual;
   private readonly string           _description;
   private readonly Func<TNext>      _next;
   private readonly Action<Property> _pushProperty;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private BooleanPropertyAsserts
   (
      bool             actual,
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

   public static BooleanPropertyAsserts<TNext> Create
   (
      Action<Property> pushProperty,
      string           description,
      bool             actual,
      Func<TNext>      next
   )
      => new(actual,
             description,
             next,
             pushProperty);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsFalse()
   {
      _pushProperty(Properties.IsFalse(_description,
                                       _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsTrue()
   {
      _pushProperty(Properties.IsTrue(_description,
                                      _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */
}