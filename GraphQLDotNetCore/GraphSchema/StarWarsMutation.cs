using Data;
using GraphQL;
using GraphQL.Types;
using GraphSchema.Types;
using Models;

namespace GraphSchema
{
    /// <example>
    /// This is an example JSON request for a mutation
    /// {
    ///   "query": "mutation ($human:HumanInput!){ createHuman(human: $human) { id name } }",
    ///   "variables": {
    ///     "human": {
    ///       "name": "Boba Fett"
    ///     }
    ///   }
    /// }
    /// </example>
    public class StarWarsMutation : ObjectGraphType
    {
        public StarWarsMutation(StarWarsData data)
        {
            Name = "Mutation";

            Field<HumanType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<HumanInputType>> {Name = "human"}
                ),
                
                resolve: context =>
                {
                    if (context.GetArgument<Human>("human").Name =="mammad")
                    {
                        context.Errors.Add(new ExecutionError("Mammad is not human, he is an angel."));
                        return null;
                    }
                    var human = context.GetArgument<Human>("human");
                    return data.AddHuman(human);
                });
        }
    }
}
