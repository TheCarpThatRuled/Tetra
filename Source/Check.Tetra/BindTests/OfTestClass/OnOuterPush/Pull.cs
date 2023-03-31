using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestClass.OnOuterPush;

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
      static Property Property(TestClass value)
      {
         //Arrange
         var binding = Bind.To(value);

         //Act
         var actual = binding.Pull();

         //Assert
         return AreEqual(nameof(ITwoWayBinding<TestClass>.Pull),
                         value,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}