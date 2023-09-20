﻿namespace Tetra.Testing;

public interface IReturnsAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ObjectAsserts<T, TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}