using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Option<T>(T content)
   /* ------------------------------------------------------------ */

   [TestMethod]
   public void GIVEN_an_int_WHEN_Option_of_int_implicit_operator_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         Option<int> actual = value;

         //Assert
         return IsASome(value,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}