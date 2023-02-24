namespace Tetra.Testing;

public sealed class FakeOneWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeOneWayBinding<T> Create(DataContext          context,
                                             string               propertyName,
                                             Func<T> get)
      => new(context,
             get,
             propertyName);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public T Get()
      => _value;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<T> _get;
   private readonly string  _propertyName;

   //Mutable
   private T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakeOneWayBinding(DataContext          context,
                             Func<T> get,
                             string               propertyName)
   {
      _get          = get;
      _propertyName = propertyName;

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