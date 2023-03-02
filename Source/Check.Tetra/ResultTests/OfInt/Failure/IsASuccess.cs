using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_IsASuccess
{
   /* ------------------------------------------------------------ */
   // bool IsASuccess()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //IsASuccess
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_IsASuccess_THEN_false_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<int>.Failure(content);

         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}