using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // AreEqual Extensions
   /* ------------------------------------------------------------ */

   public static Assert AreEqual(this Assert assert,
                                 object? expected,
                                 object? actual)
   {
      Log.ToDebugOutput_AreEqual(expected,
                                 actual);

      Assert.AreEqual(expected,
                      actual);

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert AreEqual(this Assert assert,
                                 object? expected,
                                 object? actual,
                                 string message)
   {
      Log.ToDebugOutput_AreEqual(expected,
                                 actual);

      Assert.AreEqual(expected,
                      actual,
                      message);

      return assert;
   }

   /* ------------------------------------------------------------ */
   // IsBool Extensions
   /* ------------------------------------------------------------ */

   public static Assert IsFalse(this Assert assert,
                                bool actual)
   {
      Assert.IsFalse(actual);

      return assert;
   }

   /* ------------------------------------------------------------ */

   public static Assert IsTrue(this Assert assert,
                               bool actual)
   {
      Assert.IsTrue(actual);

      return assert;
   }

   /* ------------------------------------------------------------ */
}