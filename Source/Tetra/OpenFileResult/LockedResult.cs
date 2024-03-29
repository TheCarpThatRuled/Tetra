﻿namespace Tetra;

internal sealed class LockedResult<T> : IOpenFileResult<T>
{
   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   internal readonly Locked Content;

   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   private LockedResult
   (
      Locked content
   )
      => Content = content;

   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Methods
   /* ------------------------------------------------------------ */

   public IOpenFileResult<T> Do
   (
      Action<Locked>  whenLocked,
      Action<Missing> whenMissing,
      Action<T>       whenOpen
   )
   {
      whenLocked(Content);

      return this;
   }

   /* ------------------------------------------------------------ */

   public IOpenFileResult<TNew> Map<TNew>
   (
      Func<T, TNew> whenOpen
   )
      => new LockedResult<TNew>(Content);

   /* ------------------------------------------------------------ */

   public TNew Reduce<TNew>
   (
      Func<Locked, TNew>  whenLocked,
      Func<Missing, TNew> whenMissing,
      Func<T, TNew>       whenOpen
   )
      => whenLocked(Content);
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */


   public static LockedResult<T> Create
   (
      Message          message,
      AbsoluteFilePath path
   )
      => new(new(message,
                 path));

   /* ------------------------------------------------------------ */
}