using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.IEnumerableTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.IEnumerable)]
public class WithIndices
{
   /* ------------------------------------------------------------ */
   // public IEnumerable<(T item, int index)> WithIndices<T>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_int
   //WHEN
   //WithIndices
   //THEN
   //an_enumerable_containing_the_item_and_its_index_is_returned

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_int_WHEN_WithIndices_THEN_an_enumerable_containing_the_item_and_its_index_is_returned()
   {
      static Property Property
      (
         int[] sequence
      )
      {
         //Arrange
         //Act
         var actual = sequence
                     .WithIndices()
                     .ToArray();

         //Assert
         if (sequence.Length != actual.Length)
         {
            return False(Failed.InTheAsserts("The sequences are unequal in length.",
                                             Failed.Expected(sequence),
                                             Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
         }

         for (var i = 0; i < sequence.Length; ++i)
         {
            if (sequence[i]
             != actual[i]
                  .item)
            {
               return False(Failed.InTheAsserts($"The item at position {i} is not the expected item.",
                                                Failed.Expected(sequence),
                                                Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
            }

            if (i
             != actual[i]
                  .index)
            {
               return False(Failed.InTheAsserts($"The index at position {i} is not '{i}'.",
                                                Failed.Expected(sequence),
                                                Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
            }
         }

         return True();
      }

      Prop.ForAll<int[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_TestClass
   //WHEN
   //WithIndices
   //THEN
   //an_enumerable_containing_the_item_and_its_index_is_returned

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_TestClass_WHEN_WithIndices_THEN_an_enumerable_containing_the_item_and_its_index_is_returned()
   {
      static Property Property
      (
         TestClass[] sequence
      )
      {
         //Arrange
         //Act
         var actual = sequence
                     .WithIndices()
                     .ToArray();

         //Assert
         if (sequence.Length != actual.Length)
         {
            return False(Failed.InTheAsserts("The sequences are unequal in length.",
                                             Failed.Expected(sequence),
                                             Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
         }

         for (var i = 0; i < sequence.Length; ++i)
         {
            if (sequence[i]
             != actual[i]
                  .item)
            {
               return False(Failed.InTheAsserts($"The item at position {i} is not the expected item.",
                                                Failed.Expected(sequence),
                                                Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
            }

            if (i
             != actual[i]
                  .index)
            {
               return False(Failed.InTheAsserts($"The index at position {i} is not '{i}'.",
                                                Failed.Expected(sequence),
                                                Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
            }
         }

         return True();
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_IEnumerable_of_TestStruct
   //WHEN
   //WithIndices
   //THEN
   //an_enumerable_containing_the_item_and_its_index_is_returned

   [TestMethod]
   public void GIVEN_an_IEnumerable_of_TestStruct_WHEN_WithIndices_THEN_an_enumerable_containing_the_item_and_its_index_is_returned()
   {
      static Property Property
      (
         TestStruct[] sequence
      )
      {
         //Arrange
         //Act
         var actual = sequence
                     .WithIndices()
                     .ToArray();

         //Assert
         if (sequence.Length != actual.Length)
         {
            return False(Failed.InTheAsserts("The sequences are unequal in length.",
                                             Failed.Expected(sequence),
                                             Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
         }

         for (var i = 0; i < sequence.Length; ++i)
         {
            if (sequence[i]
             != actual[i]
                  .item)
            {
               return False(Failed.InTheAsserts($"The item at position {i} is not the expected item.",
                                                Failed.Expected(sequence),
                                                Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
            }

            if (i
             != actual[i]
                  .index)
            {
               return False(Failed.InTheAsserts($"The index at position {i} is not '{i}'.",
                                                Failed.Expected(sequence),
                                                Failed.Actual(actual.Select(x => $"{x.item}, {x.index}"))));
            }
         }

         return True();
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}