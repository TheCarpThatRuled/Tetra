﻿namespace Tetra;

partial class DataContext
{
   protected sealed class TwoWayBinding<T>
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static TwoWayBinding<T> Create()
         => new();

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public T Pull()
         => default!;

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Push(T value) { }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private TwoWayBinding()
      {
         
      }

      /* ------------------------------------------------------------ */
   }
}