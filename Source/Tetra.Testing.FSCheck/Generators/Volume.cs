using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<Volume> Volume()
      => AsciiLetter()
        .Select(Tetra
               .Volume
               .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(Volume, Volume, Volume)> ThreeUniqueVolumes()
      => AsciiLetter()
        .Three()
        .Where(tuple => tuple.Item1 != tuple.Item2
                     && tuple.Item1 != tuple.Item3
                     && tuple.Item2 != tuple.Item3)
        .Select(tuple => (Tetra.Volume.Create(tuple.Item1),
                          Tetra.Volume.Create(tuple.Item2),
                          Tetra.Volume.Create(tuple.Item3)));

   /* ------------------------------------------------------------ */

   public static Gen<(Volume, Volume)> TwoUniqueVolumes()
      => AsciiLetter()
        .Two()
        .Where(tuple => tuple.Item1 != tuple.Item2)
        .Select(tuple => (Tetra.Volume.Create(tuple.Item1),
                          Tetra.Volume.Create(tuple.Item2)));

   /* ------------------------------------------------------------ */
}