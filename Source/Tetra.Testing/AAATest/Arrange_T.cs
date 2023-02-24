// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public abstract class Arrange<TAct, TArrangeInstance, TActInstance> : IArrange
   where TAct : IAct
   where TArrangeInstance : IArrangeInstance<TActInstance>
   where TActInstance : IActInstance
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TAct WHEN()
      => CreateAct(_factory.Given(characteriser =>
      {
         _characterisation(characteriser);

         return _given.Then(given => given.WHEN());
      }));

   /* ------------------------------------------------------------ */
   // Protected Constructors
   /* ------------------------------------------------------------ */

   protected Arrange(AAATest.DefineGiven                                          factory,
                     Func<AAATest.GivenCharacteriser, AAATest.GivenCharacteriser> characterisation,
                     Func<AAATest.Disposables, TArrangeInstance>                  given)
   {
      _factory          = factory;
      _characterisation = characterisation;
      _given            = given;
   }

   /* ------------------------------------------------------------ */
   // Protected Abstract Methods
   /* ------------------------------------------------------------ */

   protected abstract TAct CreateAct(AAATest.DefineWhen<TActInstance> factory);

   /* ------------------------------------------------------------ */
   // Protected Methods
   /* ------------------------------------------------------------ */

   protected void Add(Func<AAATest.GivenCharacteriser, AAATest.GivenCharacteriser> characterisation,
                      Func<TArrangeInstance, TArrangeInstance>                     action)
   {
      _characterisation = _characterisation.Then(characterisation);
      _given            = _given.Then(action);
   }

   /* ------------------------------------------------------------ */

   protected TNewArrange Add<TNewArrange, TNewArrangeInstance>(
      Func<AAATest.DefineGiven, Func<AAATest.GivenCharacteriser, AAATest.GivenCharacteriser>, Func<AAATest.Disposables, TNewArrangeInstance>, TNewArrange> create,
      Func<AAATest.GivenCharacteriser, AAATest.GivenCharacteriser>                                                                                         characterisation,
      Func<TArrangeInstance, TNewArrangeInstance>                                                                                                          action)

      => create(_factory,
                _characterisation.Then(characterisation),
                _given.Then(action));

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly AAATest.DefineGiven _factory;

   //Mutable
   private Func<AAATest.GivenCharacteriser, AAATest.GivenCharacteriser> _characterisation;
   private Func<AAATest.Disposables, TArrangeInstance>                  _given;

   /* ------------------------------------------------------------ */
}