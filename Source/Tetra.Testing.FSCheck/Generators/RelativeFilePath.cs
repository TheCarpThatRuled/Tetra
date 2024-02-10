namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<RelativeFilePath> RelativeFilePath()
      => ValidPathWithoutARootOrATrailingDirectorySeparator()
        .Select(Tetra.RelativeFilePath
                     .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(RelativeFilePath, RelativeFilePath, RelativeFilePath)> ThreeUniqueRelativeFilePaths()
      => RelativeFilePath()
        .ThreeValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.third.Value())
                     && !StringComparer.OrdinalIgnoreCase.Equals(tuple.second.Value(),
                                                                 tuple.third.Value()));

   /* ------------------------------------------------------------ */

   public static Gen<(RelativeFilePath, RelativeFilePath)> TwoIdenticalRelativeFilePaths()
      => ValidPathWithoutARootOrATrailingDirectorySeparator()
        .Select(path => (Tetra.RelativeFilePath
                              .Create(path),
                         Tetra.RelativeFilePath
                              .Create(path)));

   /* ------------------------------------------------------------ */

   public static Gen<(RelativeFilePath, RelativeFilePath)> TwoUniqueRelativeFilePaths()
      => RelativeFilePath()
        .TwoValueTuples()
        .Where(tuple => !StringComparer.OrdinalIgnoreCase.Equals(tuple.first.Value(),
                                                                 tuple.second.Value()));

   /* ------------------------------------------------------------ */
}