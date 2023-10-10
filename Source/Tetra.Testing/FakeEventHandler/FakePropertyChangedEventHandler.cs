using System.ComponentModel;

namespace Tetra.Testing;

public sealed class FakePropertyChangedEventHandler
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly List<PropertyChangedEventArgs> _arguments = new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FakePropertyChangedEventHandler
   (
      Action<PropertyChangedEventHandler> subscribe
   )
      => subscribe(OnFired);
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FakePropertyChangedEventHandler Create
   (
      Action<PropertyChangedEventHandler> subscribe
   )
      => new(subscribe);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public ISequence<PropertyChangedEventArgs> Arguments()
      => _arguments
        .Materialise();

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   public void OnFired
   (
      object?                  sender,
      PropertyChangedEventArgs args
   )
      => _arguments
        .Add(args);

   /* ------------------------------------------------------------ */
}