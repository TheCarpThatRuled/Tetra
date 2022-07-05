using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
public class Ancestry
{
   /* ------------------------------------------------------------ */
   // IReadOnlyList<VolumeRootedDirectoryPath> Ancestry(this VolumeRootedDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath
   //WHEN
   //Ancestry
   //THEN
   //a_sequence_of_VolumeRootedDirectoryPaths_representing_each_node_from_the_root_to_the_left_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_WHEN_Ancestry_THEN_a_sequence_of_VolumeRootedDirectoryPaths_representing_each_node_from_the_root_to_the_left_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var directoryChains = new List<IEnumerable<DirectoryComponent>> {Array.Empty<DirectoryComponent>(),};

         foreach (var directory in directories)
         {
            directoryChains.Add(directoryChains[^1]
                                  .Append(directory));
         }

         var expected = directoryChains
                       .Select(x => VolumeRootedDirectoryPath.Create(volume,
                                                                     x.ToArray()))
                       .ToArray();

         //Act
         var actual = expected[^1].Ancestry();

         //Assert
         return AreSequenceEqual(expected,
                                 actual);
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }
}