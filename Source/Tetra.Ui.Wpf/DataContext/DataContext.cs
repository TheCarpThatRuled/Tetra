using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tetra;

public abstract partial class DataContext : INotifyPropertyChanged
{
   /* ------------------------------------------------------------ */
   // INotifyPropertyChanged Events and Invokers
   /* ------------------------------------------------------------ */

   public event PropertyChangedEventHandler? PropertyChanged;

   /* ------------------------------------------------------------ */

   protected void OnPropertyChanged
   (
      [CallerMemberName] string? memberName = null
   )
      => PropertyChanged
       ?.Invoke(this,
                new(memberName));

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected Binding<T> Bind<T>
   (
      string memberName,
      T      initialValue
   )
      => Binding<T>
        .Create(initialValue,
                () => OnPropertyChanged(memberName));

   /* ------------------------------------------------------------ */

   protected OneWayBinding<T> Bind<T>
   (
      string            memberName,
      IOneWayBinding<T> binding
   )
      => OneWayBinding<T>
        .Create(binding,
                () => OnPropertyChanged(memberName));

   /* ------------------------------------------------------------ */

   protected TwoWayBinding<T> Bind<T>
   (
      string            memberName,
      ITwoWayBinding<T> binding
   )
      => TwoWayBinding<T>
        .Create(binding,
                () => OnPropertyChanged(memberName));

   /* ------------------------------------------------------------ */
}