﻿namespace Tetra.Testing;

public interface IReturnsAsserts<T, TAsserts>
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ReturnsAsserts<T, TAsserts> ReturnValue();

   /* ------------------------------------------------------------ */
}