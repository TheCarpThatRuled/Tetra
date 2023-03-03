namespace Tetra;

partial class DataContext
{
   protected sealed class TwoWayBinding<T>
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public T Pull()
         => _binding
           .Pull();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Push(T value)
         => _binding
           .PushWithoutUpdate(value,
                              _onBindingUpdated);

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static TwoWayBinding<T> Create(ITwoWayBinding<T> binding,
                                              Action            onBindingUpdated)
         => new(binding,
                onBindingUpdated);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ITwoWayBinding<T> _binding;
      private readonly Action            _onBindingUpdated;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private TwoWayBinding(ITwoWayBinding<T> binding,
                            Action            onBindingUpdated)
      {
         _binding          = binding;
         _onBindingUpdated = onBindingUpdated;

         _binding.OnUpdated(onBindingUpdated);
      }

      /* ------------------------------------------------------------ */
   }
}