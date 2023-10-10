namespace Check;

public sealed class FakeRight
{
   /* ------------------------------------------------------------ */
   //  Fields
   /* ------------------------------------------------------------ */

   public readonly string Characterisation;

   /* ------------------------------------------------------------ */
   //  Private Constructors
   /* ------------------------------------------------------------ */

   private FakeRight
   (
      string characterisation
   )
      => Characterisation = characterisation;

   /* ------------------------------------------------------------ */
   //  object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => Characterisation;

   /* ------------------------------------------------------------ */
   //  Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeRight Create
   (
      string characterisation
   )
      => new(characterisation);

   /* ------------------------------------------------------------ */
}