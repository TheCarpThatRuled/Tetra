using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_IsAFailure
{
   /* ------------------------------------------------------------ */
   // public bool IsAFailure()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //IsAFailure
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_IsAFailure_THEN_false_is_returned()
   {
      static Property Property(IResult<int, int> result)
      {
         //Arrange
         //Act
         var actual = result.IsAFailure();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.SuccessResultOfInt32AndInt32>();

      Prop.ForAll<IResult<int, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}