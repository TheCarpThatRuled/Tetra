﻿using System;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test<TActions, TAsserts>
{
   public sealed class CompoundInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _first;
      private readonly IAction        _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundInitialAction
      (
         IInitialAction first,
         IAction        second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundInitialAction Create
      (
         IInitialAction first,
         IAction        second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IInitialAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         AAA_test.Disposables disposables
      )
      {
         var intermediate = _first.Run(disposables);
         Log.And();
         return _second.Run(intermediate);
      }

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => And(_first.Characterisation(),
                _second.Characterisation());

      /* ------------------------------------------------------------ */
   }
}