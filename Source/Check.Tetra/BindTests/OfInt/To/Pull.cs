using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfInt.To;

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
      static Property Property(int value)
      {
         //Arrange
         var binding = Bind.To(value);

         //Act
         var actual = binding.Pull();

         //Assert
         return AreEqual(nameof(ITwoWayBinding<int>.Pull),
                         value,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}