using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

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
   //Option_of_TestStruct_implicit_operator
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Option_of_TestStruct_implicit_operator_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         Option<TestStruct> actual = value;

         //Assert
         return IsASome(value,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}