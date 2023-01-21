using System.ComponentModel;

namespace Tetra;

public abstract partial class DataContext : INotifyPropertyChanged
{
   /* ------------------------------------------------------------ */
   // INotifyPropertyChanged Events
   /* ------------------------------------------------------------ */

   public event PropertyChangedEventHandler? PropertyChanged;

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected Binding<T> Bind<T>(string memberName,
                                T      initialValue)
      => Binding<T>
        .Create(initialValue);

   /* ------------------------------------------------------------ */

   protected OneWayBinding<T> Bind<T>(string            memberName,
                                      IOneWayBinding<T> binding)
      => OneWayBinding<T>
        .Create();

   /* ------------------------------------------------------------ */

   protected TwoWayBinding<T> Bind<T>(string            memberName,
                                      ITwoWayBinding<T> binding)
      => TwoWayBinding<T>
        .Create();

   /* ------------------------------------------------------------ */

}