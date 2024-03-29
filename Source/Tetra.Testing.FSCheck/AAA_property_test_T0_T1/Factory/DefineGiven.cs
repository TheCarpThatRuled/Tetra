﻿// ReSharper disable InconsistentNaming

using static Tetra.Testing.AAA_property_test;

namespace Tetra.Testing;

partial class AAA_property_test<TActions, TAsserts>
{
   public sealed class DefineGiven
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction        _given;
      private readonly Arbitrary<Parameters> _library;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineGiven
      (
         IInitialAction        given,
         Arbitrary<Parameters> library
      )
      {
         _library = library;
         _given   = given;
      }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineGiven Create
      (
         Arbitrary<Parameters> library,
         IInitialAction        given
      )
         => new(given,
                library);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineGiven And
      (
         IAction given
      )
         => Create(_library,
                   _given.And(given));

      /* ------------------------------------------------------------ */

      public DefineWhen WHEN
      (
         IAction when
      )
         => DefineWhen
           .Create(_library,
                   _given,
                   when);

      /* ------------------------------------------------------------ */
   }
}