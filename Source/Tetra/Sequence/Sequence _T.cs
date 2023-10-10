﻿using System.Collections;

namespace Tetra;

public sealed class Sequence<T> : ISequence<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T[] _array;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Sequence
   (
      T[] array
   )
      => _array = array;

   /* ------------------------------------------------------------ */
   // IEnumerable<T> Properties
   /* ------------------------------------------------------------ */

   public IEnumerator<T> GetEnumerator()
      => ((IEnumerable<T>) _array)
        .GetEnumerator();

   /* ------------------------------------------------------------ */

   IEnumerator IEnumerable.GetEnumerator()
      => GetEnumerator();

   /* ------------------------------------------------------------ */
   // ISequence<T> Properties
   /* ------------------------------------------------------------ */

   public int Length()
      => _array.Length;

   /* ------------------------------------------------------------ */
   // ISequence<T> Methods
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // ISequence<T> Operators
   /* ------------------------------------------------------------ */

   public T this
   [
      Index i
   ]
      => _array[i];

   /* ------------------------------------------------------------ */

   public T this
   [
      int i
   ]
      => _array[i];

   /* ------------------------------------------------------------ */

   public T this
   [
      uint i
   ]
      => _array[i];
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ISequence<T> Empty()
      => new Sequence<T>(Array.Empty<T>());

   /* ------------------------------------------------------------ */
   public static ISequence<T> From
   (
      params T[] array
   )
      => new Sequence<T>(array);

   /* ------------------------------------------------------------ */
}