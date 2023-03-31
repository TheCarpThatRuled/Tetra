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
         exception = Option.Some(e);
      }

      //Assert
      return AnArgumentExceptionWasThrown(ArgumentExceptionMessage(expectedMessage,
                                                                   expectedParameter),
                                          exception);

   }

   /* ------------------------------------------------------------ */

   public static Property AnArgumentExceptionWasThrown(string            expectedMessage,
                                                       IOption<Exception> actual)
      => actual
        .Reduce(exception => AsProperty(() => exception is ArgumentException)
                            .Label("The exception was not an ArgumentException")
                            .And(AsProperty(() => exception.InnerException is null)
                                   .Label("The exception contains an inner exception "))
                            .And(AsProperty(() => exception.Message == expectedMessage)
                                   .Label($"The exception does contain the expected message.\nExpected: \"{expectedMessage}\"\nActual: \"{exception.Message}\"")),
                () => False("No exception was thrown"));

   /* ------------------------------------------------------------ */
}