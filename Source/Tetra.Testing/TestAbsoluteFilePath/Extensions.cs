namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class TestAbsoluteFilePath_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static TestAbsoluteDirectoryPath Parent(this TestAbsoluteFilePath path)
      => TestAbsoluteDirectoryPath
        .Create(path.Volume(),
                path.Directories());

   /* ------------------------------------------------------------ */

   public static IReadOnlyList<TestAbsoluteDirectoryPath> ToAncestry(this TestAbsoluteFilePath path)
      => path
        .Parent()
        .ToAncestry();

   /* ------------------------------------------------------------ */

   public static AbsoluteFilePath ToTetra(this TestAbsoluteFilePath path)
      => AbsoluteFilePath
        .Create(path.Volume(),
                path.Directories(),
                path.File());

   /* ------------------------------------------------------------ */
}