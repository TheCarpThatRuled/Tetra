using FsCheck;
using static Tetra.Testing.AssertMessages;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AnArgumentExceptionWasThrown(Action action,
                                                       string expectedMessage,
                                                       string expectedParameter)
   {
      //Arrange
      var exception = Option<Exception>.None();

      //Act
      try
      {
         action();
      }
      catch (Exception e)
      {
         exception = e;
      }

      //Assert
      return AnArgumentExceptionWasThrown(exception,
                                          ArgumentExceptionMessage(expectedMessage,
                                                                   expectedParameter));

   }

   /* ------------------------------------------------------------ */

   public static Property AnArgumentExceptionWasThrown(Option<Exception> actual,
                                                       string            expectedMessage)
      => actual
        .Reduce(() => False("No exception was thrown"),
                exception => AsProperty(() => exception is ArgumentException)
                            .Label("The exception was not an ArgumentException")
                            .And(AsProperty(() => exception.InnerException is null)
                                   .Label("The exception contains an inner exception "))
                            .And(AsProperty(() => exception.Message == expectedMessage)
                                   .Label($"The exception does contain the expected message.\nExpected: \"{expectedMessage}\"\nActual: \"{exception.Message}\"")));

   /* ------------------------------------------------------------ */
}