using HotChocolate;

using HotChocolateGraphqlDemo.Api.Src.Models;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.AccountSchema
{
    public class AccountInsertInput
    {
        public string Description { get; set; }

        [GraphQLNonNullType]
        public EnumAccountType Type { get; set; }

        [GraphQLNonNullType]
        public Guid OwnerId { get; set; }
    }
}
