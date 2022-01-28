using HotChocolate;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema
{
    public class OwnerUpdateInput
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
