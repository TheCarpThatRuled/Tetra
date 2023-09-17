namespace Check;

public sealed class FakeType
{
   /* ------------------------------------------------------------ */
   //  Fields
   /* ------------------------------------------------------------ */

   public readonly string Characterisation;

   /* ------------------------------------------------------------ */
   //  object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => Characterisation;

   /* ------------------------------------------------------------ */
   //  Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeType Create(string characterisation)
      => new(characterisation);

   /* ------------------------------------------------------------ */
   //  Private Constructors
   /* ------------------------------------------------------------ */

   private FakeType(string characterisation)
      => Characterisation = characterisation;

   /* ------------------------------------------------------------ */
}