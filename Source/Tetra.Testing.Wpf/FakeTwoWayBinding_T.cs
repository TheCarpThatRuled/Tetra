namespace Tetra.Testing;

public sealed class FakeTwoWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeTwoWayBinding<T> Create(DataContext context,
                                             string      propertyName,
                                             Func<T>     get,
                                             Action<T>   set)
      => new(context,
             get,
             propertyName,
             set);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public T Get()
      => _value;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void Set(T value)
   {
      _value = value;

      _set(value);
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<T>   _get;
   private readonly string    _propertyName;
   private readonly Action<T> _set;

   //Mutable
   private T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeTwoWayBinding(DataContext context,
                             Func<T>     get,
                             string      propertyName,
                             Action<T>   set)
   {
      _get          = get;
      _propertyName = propertyName;
      _set          = set;

      context.PropertyChanged += ContextOnPropertyChanged;

      _value = get();
   }

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private void ContextOnPropertyChanged(object?                                        sender,
                                         System.ComponentModel.PropertyChangedEventArgs e)
   {
      if (e.PropertyName == _propertyName)
      {
         _value = _get();
      }
   }

   /* ------------------------------------------------------------ */
}