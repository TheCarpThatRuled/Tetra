using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FailureTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Failure)]
// ReSharper disable once InconsistentNaming
public class Create
{
   /* ------------------------------------------------------------ */
   // Failure<T> Create(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Message
   //WHEN
   //Failure_Create
   //THEN
   //a_Failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_Message_WHEN_Failure_Create_THEN_a_Failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var failure = Failure.Create(content);

         //Act
         var actual = failure.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}