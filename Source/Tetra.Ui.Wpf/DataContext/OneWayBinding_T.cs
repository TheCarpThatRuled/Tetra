﻿namespace Tetra;

partial class DataContext
{
   protected sealed class OneWayBinding<T>
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IOneWayBinding<T> _binding;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private OneWayBinding
      (
         IOneWayBinding<T> binding,
         Action            onBindingUpdated
      )
      {
         _binding = binding;
         _binding.OnUpdated(onBindingUpdated);
      }
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public T Pull()
         => _binding
           .Pull();

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static OneWayBinding<T> Create
      (
         IOneWayBinding<T> binding,
         Action            onBindingUpdated
      )
         => new(binding,
                onBindingUpdated);

      /* ------------------------------------------------------------ */
   }
}