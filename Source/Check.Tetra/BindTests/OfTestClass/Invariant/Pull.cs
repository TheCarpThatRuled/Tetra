using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestClass.Invariant;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Invariant
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_Invariant_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var binding = Bind.Invariant(value);

         //Act
         var actual = binding.Pull();

         //Assert
         return AreEqual(nameof(IOneWayBinding<TestClass>.Pull),
                         value,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}