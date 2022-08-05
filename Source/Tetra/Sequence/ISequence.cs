﻿namespace Tetra;

public interface ISequence<out T> : IEnumerable<T>
{
   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   int Length();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
   // Operators
   /* ------------------------------------------------------------ */

   T this[Index i]{ get; }

   /* ------------------------------------------------------------ */

   T this[int i] { get; }

   /* ------------------------------------------------------------ */

   T this[uint i] { get; }

   /* ------------------------------------------------------------ */
}