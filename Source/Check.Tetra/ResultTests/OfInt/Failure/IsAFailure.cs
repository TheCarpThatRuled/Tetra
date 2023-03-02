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
public class Failure_IsAFailure
{
   /* ------------------------------------------------------------ */
   // bool IsAFailure()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //IsAFailure
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_IsAFailure_THEN_true_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<int>.Failure(content);

         //Act
         var actual = result.IsAFailure();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}