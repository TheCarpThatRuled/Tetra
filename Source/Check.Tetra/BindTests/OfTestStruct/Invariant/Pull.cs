using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestStruct.Invariant;

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
      static Property Property(TestStruct value)
      {
         //Arrange
         var binding = Bind.Invariant(value);

         //Act
         var actual = binding.Pull();

         //Assert
         return AreEqual(nameof(IOneWayBinding<TestStruct>.Pull),
                         value,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}