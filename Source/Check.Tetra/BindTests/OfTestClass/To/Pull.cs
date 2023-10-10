using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestClass.To;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //To
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_To_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property
      (
         TestClass value
      )
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