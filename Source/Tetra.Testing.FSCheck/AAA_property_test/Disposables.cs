﻿namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test
{
   public sealed class Disposables
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<IDisposable> _disposables = new();

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Disposables() { }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Disposables Create()
         => new();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Register
      (
         IDisposable disposable
      )
         => _disposables
           .Add(disposable);

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      internal void Dispose()
      {
         foreach (var disposable in _disposables)
         {
            disposable.Dispose();
         }
      }

      /* ------------------------------------------------------------ */
   }
}