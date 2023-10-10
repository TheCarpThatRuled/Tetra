namespace Check;

public sealed class FakeType
{
   /* ------------------------------------------------------------ */
   //  Fields
   /* ------------------------------------------------------------ */

   public readonly string Characterisation;

   /* ------------------------------------------------------------ */
   //  Private Constructors
   /* ------------------------------------------------------------ */

   private FakeType
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

   public static FakeType Create
   (
      string characterisation
   )
      => new(characterisation);

   /* ------------------------------------------------------------ */
}