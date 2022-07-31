using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Option<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //Option_of_TestClass_implicit_operator
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Option_of_TestClass_implicit_operator_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         Option<TestClass> actual = value;

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}