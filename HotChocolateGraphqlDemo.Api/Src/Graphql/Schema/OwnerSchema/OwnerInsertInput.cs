using HotChocolate;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema
{
    public class OwnerInsertInput
    {
        [GraphQLNonNullType]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
