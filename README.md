# Dotnet API with Graphql using [Hot Chocolate](https://github.com/ChilliCream/hotchocolate)
📣 *This is a self study project to allow me to better understand the `GraphQL` in the `.Net` environment and **not** a production ready API.*

✨ Code splitting.

✨ Repository pattern

✨ Unit of work pattern

✨ Data Loader implementation.

# Packages
* [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore?_src=template)
* [Pomelo.EntityFrameworkCore.MySql](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql/5.0.0-alpha.2?_src=template)
* [HotChocolate.AspNetCore](https://www.nuget.org/packages/HotChocolate.AspNetCore/12.5.0?_src=template)
* [HotChocolate.Data.EntityFramework](https://www.nuget.org/packages/HotChocolate.Data.EntityFramework/12.5.0?_src=template)

# Paths
*Playground:* `/graphql`

*Gql endpoint:* `/graphql`

# Schema
````graphql
type Query {
  account(accountId: UUID!): AccountType
  accounts: [AccountType]
  owner(ownerId: UUID!): OwnerType
  owners: [OwnerType]
  roles: [RoleType]
  users: [UserType]
}

type Mutation {
  accountCreate(data: AccountInsertInput): AccountType
  accountUpdate(data: AccountUpdateInput): AccountType
  accountDelete(accountId: UUID!): String
  ownerCreate(data: OwnerInsertInput): OwnerType
  ownerUpdate(data: OwnerUpdateInput): OwnerType
  ownerDelete(ownerId: UUID!): String
}

input AccountInsertInput {
  description: String
  type: EnumAccountType!
  ownerId: UUID!
}

type UserType {
  role: RoleType
  id: UUID!
  status: EnumUserStatus!
  email: String
  name: String
  roleId: UUID!
}

type RoleType {
  users: [UserType]
  id: UUID!
  code: String
  name: String
}

type OwnerType {
  accounts: [AccountType]
  id: UUID!
  address: String
  name: String
}

scalar UUID

type AccountType {
  owner: OwnerType
  id: UUID!
  description: String
  type: EnumAccountType!
  ownerId: UUID!
}

input AccountUpdateInput {
  id: UUID!
  description: String
  type: EnumAccountType!
  ownerId: UUID!
}

input OwnerInsertInput {
  name: String!
  address: String
}

input OwnerUpdateInput {
  id: UUID!
  name: String
  address: String
}

enum EnumAccountType {
  CASH
  SAVINGS
  EXPENSE
  INCOME
}

enum EnumUserStatus {
  NOT_ACTIVE
  ACTIVE
  BLOCKED
}
````

# Queries example

````graphql
# Get all Accounts
{
  accounts {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Get one Account
{
  account(accountId: "e58dc519-f9f7-414c-bb24-5252e1abc548") {
    id
    type
    description
    ownerId
    owner {
      id
      name
    }
  }
}

# Get all Owners
{
  owners{
    id
    address
    name
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Get one Owner
{
  owner(ownerId: "3e85e4e3-d02a-4d52-ba80-83c34be6e233"){
    id
    address
    name
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Get all Users
{
  users {
    id
    name
    email
    status
    roleId
    role {
      id
      code
    }
  }
}

# Get all Roles
{
  roles {
    id
    code
    name
    users {
      id
      name
      email
      status
    }
  }
}
````

# Mutations example

````graphql
# Create an Owner
mutation ownerCreate {
  ownerCreate(data: {
		name: "New owner",
		address: "owner address"
	}) {
    id
    name
    address
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Update an Owner
mutation ownerUpdate {
  ownerUpdate(data: {
    id: "038c786b-0f1e-460f-bd52-0ed2e224f4f2"
    name: "Update owner",
    address: "update address"
	}) {
    id
    name
    address
    accounts {
      id
      description
      ownerId
      type
    }
  }
}

# Delete an Owner
mutation ownerDelete {
  ownerDelete(ownerId: "60a7d9f7-22b8-4901-aed1-fc21e208d4a0")
}

# Create one Account
mutation accountCreate {
  accountCreate(data: {
		description: "New account",
		type: SAVINGS
		ownerId: "373cce1c-1d57-4dc2-8159-05b125a59799"
	}) {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Update an Account
mutation accountUpdate {
  accountUpdate(data: {
		id: "373cce1c-1d57-4dc2-8159-05b125a59799",
		description: "Update account"
		type: EXPENSE
		ownerId: "0cdded52-9e3a-4249-be4d-3a5dca8e99f8"
  }) {
    id
    type
    description
    ownerId
    owner {
      id
      address
      name
    }
  }
}

# Delete an Account
mutation accountDelete {
  accountDelete(accountId: "1d203454-ca82-4e00-8f8d-00e87b2c14ca")
}
````