﻿using System.Numerics;

namespace Tetra;

internal sealed class Count<T> where T : INumber<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Count<T> Create(T initialCount)
      => new(initialCount);

   /* ------------------------------------------------------------ */

   public static Count<T> FromZero()
      => Create(T.Zero);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public T Value()
      => _value;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Count<T> Decrement()
   {
      --_value;

      return this;
   }

   /* ------------------------------------------------------------ */

   public Count<T> Increment()
   {
      ++_value;

      return this;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Count(T initialCount)
      => _value = initialCount;

   /* ------------------------------------------------------------ */
}