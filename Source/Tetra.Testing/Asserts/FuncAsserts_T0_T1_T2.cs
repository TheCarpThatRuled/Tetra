﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class FuncAsserts<T, TReturn, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeFunction<T, TReturn> _actual;
   private readonly string                   _description;
   private readonly Func<TNext>              _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FuncAsserts
   (
      FakeFunction<T, TReturn> actual,
      string                   description,
      Func<TNext>              next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FuncAsserts<T, TReturn, TNext> Create
   (
      string                   description,
      FakeFunction<T, TReturn> actual,
      Func<TNext>              next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce
   (
      T expected
   )
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        expected,
                        _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext WasNotInvoked()
   {
      Assert
        .That
        .WasNotInvoked(_description,
                       _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
}