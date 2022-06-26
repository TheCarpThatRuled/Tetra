using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert AnArgumentExceptionWasThrown(this Assert       asserts,
                                                     Option<Exception> actual,
                                                     string            expectedMessage)
      => actual
        .Reduce(() => throw Failed.Assert("No exception was thrown"),
                exception =>
                {
                   Assert.IsInstanceOfType(exception,
                                           typeof(ArgumentException));
                   Assert.IsNull(exception.InnerException,
                                 "The exception contains an inner exception ");
                   Assert.That
                         .AreEqual(expectedMessage,
                                   exception.Message,
                                   $"The exception does contain the expected message.\nExpected: \"{expectedMessage}\"\nActual: \"{exception.Message}\"");

                   return asserts;
                });

   /* ------------------------------------------------------------ */
}