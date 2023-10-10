using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestStruct.OnOuterPush;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //OnOuterPush
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_OnOuterPush_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property
      (
         TestStruct value
      )
      {
         //Arrange
         var binding = Bind.To(value);

         //Act
         var actual = binding.Pull();

         //Assert
         return AreEqual(nameof(ITwoWayBinding<TestStruct>.Pull),
                         value,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}