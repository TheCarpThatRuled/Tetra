﻿namespace Tetra;

public interface ISuccess<out T>
{
   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public T Content();

   /* ------------------------------------------------------------ */
}