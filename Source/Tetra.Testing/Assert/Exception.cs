using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class Assert_Extensions
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Assert AnArgumentExceptionWasThrown
   (
      this Assert        asserts,
      string             expectedMessage,
      IOption<Exception> actual
   )
      => actual
        .Unify(exception =>
               {
                  Assert.IsInstanceOfType(exception,
                                          typeof(ArgumentException));
                  Assert.IsNull(exception.InnerException,
                                "The exception contains an inner exception ");
                  Assert.That
                        .AreEqual($"The exception does contain the expected message.\nExpected: \"{expectedMessage}\"\nActual: \"{exception.Message}\"",
                                  expectedMessage,
                                  exception.Message);

                  return asserts;
               },
               () => throw Failed.Assert("No exception was thrown"));

   /* ------------------------------------------------------------ */
}