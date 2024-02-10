namespace Tetra.Testing;

public sealed class OptionPropertyAsserts<T, TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOption<T>       _actual;
   private readonly string           _description;
   private readonly Func<TNext>      _next;
   private readonly Action<Property> _pushProperty;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private OptionPropertyAsserts
   (
      IOption<T>       actual,
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

   public static OptionPropertyAsserts<T, TNext> Create
   (
      Action<Property> pushProperty,
      string           description,
      IOption<T>       actual,
      Func<TNext>      next
   )
      => new(actual,
             description,
             next,
             pushProperty);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsANone()
   {
      _pushProperty(Properties.IsANone(_description,
                                       _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsASome
   (
      T expected
   )
   {
      _pushProperty(Properties.IsASome(_description,
                                       expected,
                                       _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsASomeAnd
   (
      Func<T, bool> predicate
   )
   {
      _pushProperty(Properties.IsASomeAnd(_description,
                                          (
                                             _,
                                             a
                                          ) => predicate(a)
                                            .ToProperty(),
                                          _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsEqualTo
   (
      object? expected
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
      object? expected
   )
   {
      _pushProperty(Properties.AreReferenceEqual(_description,
                                                 expected,
                                                 _actual));

      return _next();
   }

   /* ------------------------------------------------------------ */
}