﻿// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public sealed class Act<T>
   where T : IAsserts
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public Act(T asserts)
      => _asserts = asserts;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public T THEN()
      => _asserts;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _asserts;

   /* ------------------------------------------------------------ */
}