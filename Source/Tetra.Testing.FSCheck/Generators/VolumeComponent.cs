namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<VolumeComponent> VolumeComponent()
      => AsciiLetter()
        .Select(Tetra.VolumeComponent
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeComponent, VolumeComponent, VolumeComponent)> ThreeUniqueVolumeComponents()
      => VolumeComponent()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(VolumeComponent, VolumeComponent)> TwoUniqueVolumeComponents()
      => VolumeComponent()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}