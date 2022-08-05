using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
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