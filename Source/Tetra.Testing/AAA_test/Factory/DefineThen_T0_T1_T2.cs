﻿// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class AAA_test
{
   public sealed class DefineThen<TGiven, TWhen, TThen>
      where TGiven : IArranges
      where TWhen : IAsserts
      where TThen : IAsserts
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public DefineThen<TGiven, TWhen, TNewThen> And<TNewThen>(IAssert<TThen, TNewThen> assert)
         where TNewThen : IAsserts
         => DefineThen<TGiven, TWhen, TNewThen>
           .Create(_given,
                   _when,
                   _then.And(assert));

      /* ------------------------------------------------------------ */

      public AAA_test Crystallise()
      {
         var givenCharacteriser = GivenCharacteriser.Create();

         _given.AddBriefCharacterisation(givenCharacteriser);
         _given.AddFullCharacterisation(givenCharacteriser);

         var whenCharacteriser = givenCharacteriser.When();

         _when.AddBriefCharacterisation(whenCharacteriser);
         _when.AddFullCharacterisation(whenCharacteriser);

         var thenCharacteriser = whenCharacteriser.Then();

         _then.AddBriefCharacterisation(thenCharacteriser);
         _then.AddFullCharacterisation(thenCharacteriser);

         return AAA_test.Create(disposables =>
                                {
                                   var given = _given.Arrange(disposables);
                                   return () =>
                                   {
                                      var when = _when.Act(given);

                                      return () => _then.Assert(when);
                                   };
                                },
                                thenCharacteriser.Finish());
      }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static DefineThen<TGiven, TWhen, TThen> Create(IArrange<TGiven>      given,
                                                              IAct<TGiven, TWhen>   when,
                                                              IAssert<TWhen, TThen> then)
         => new(given,
                then,
                when);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TGiven>      _given;
      private readonly IAssert<TWhen, TThen> _then;
      private readonly IAct<TGiven, TWhen>   _when;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private DefineThen(IArrange<TGiven>      given,
                         IAssert<TWhen, TThen> then,
                         IAct<TGiven, TWhen>   when)
      {
         _given = given;
         _then  = then;
         _when  = when;
      }

      /* ------------------------------------------------------------ */
   }
}