using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<VolumeComponent> VolumeComponent()
      => AsciiLetter()
        .Select(Tetra
               .VolumeComponent
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeComponent, VolumeComponent, VolumeComponent)> ThreeUniqueVolumeComponents()
      => AsciiLetter()
        .Three()
        .Where(tuple => tuple.Item1 != tuple.Item2
                     && tuple.Item1 != tuple.Item3
                     && tuple.Item2 != tuple.Item3)
        .Select(tuple => (Tetra.VolumeComponent.Create(tuple.Item1),
                          Tetra.VolumeComponent.Create(tuple.Item2),
                          Tetra.VolumeComponent.Create(tuple.Item3)));

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeComponent, VolumeComponent)> TwoUniqueVolumeComponents()
      => AsciiLetter()
        .Two()
        .Where(tuple => tuple.Item1 != tuple.Item2)
        .Select(tuple => (Tetra.VolumeComponent.Create(tuple.Item1),
                          Tetra.VolumeComponent.Create(tuple.Item2)));

   /* ------------------------------------------------------------ */
}