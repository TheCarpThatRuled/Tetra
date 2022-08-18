﻿namespace Tetra;

public sealed class Open<T> : IOpenFileResult<T>.IOpen
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */


   /* ------------------------------------------------------------ */
   // IOpenFileResult<T>.IOpen Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// The content of this <c>Open</c>.
   /// </summary>
   public T Content()
      => _content;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Open(T content)
      => _content = content;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _content;

   /* ------------------------------------------------------------ */
}