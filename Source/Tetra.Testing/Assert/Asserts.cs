using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming

[ExcludeFromCodeCoverage]
public static partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // AreEqual Extensions
   /* ------------------------------------------------------------ */

   public static Assert AreEqual(this Assert assert,
                                 string      description,
                                 object?     expected,
                                 object?     actual)
   {
      Log.ToDebugOutput_AreEqual(description,
                                 expected,
                                 actual);

      Assert.AreEqual(expected,
                      actual,
                      description);

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert AreReferenceEqual(this Assert assert,
                                          string      description,
                                          object?     expected,
                                          object?     actual)
   {
      Log.ToDebugOutput_AreReferenceEqual(description,
                                          expected,
                                          actual);

      if (!ReferenceEquals(expected,
                           actual))
      {
         throw Failed.Assert($"{description}: the expected and actual are not reference equal",
                             expected,
                             actual);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert AreEqualOrdinalIgnoreCase(this Assert assert,
                                                  string      description,
                                                  string      expected,
                                                  string      actual)
   {
      Log.ToDebugOutput_AreEqual(description,
                                 expected,
                                 actual);

      if (!expected.Equals(actual,
                           StringComparison.OrdinalIgnoreCase))
      {
         throw Failed.Assert(description,
                             expected,
                             actual);
      }

      return assert;
   }

   /* ------------------------------------------------------------ */
   // IsBool Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsFalse(this Assert assert,
                                string      description,
                                bool        actual)
   {
      Log.ToDebugOutput_IsFalse(description,
                                actual);

      Assert.IsFalse(actual,
                     description);

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsTrue(this Assert assert,
                               string      description,
                               bool        actual)
   {
      Log.ToDebugOutput_IsTrue(description,
                               actual);

      Assert.IsTrue(actual,
                    description);

      return assert;
   }

   /* ------------------------------------------------------------ */
}