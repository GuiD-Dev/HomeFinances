# Home Finances

An application to registry incomes and expenses in order to manage a home finances.

## Project Stack and Details

- .NET 10
- Entity Framework
- Clean Architecture
- PostgreSQL
- Docker
- React 19


## How to run the project

```bash
# Build webapi docker image
docker build -f docker/webapi.dockerfile -t home-finances-webapi .

# Run entire application with docker compose
docker compose -f docker/docker-compose.yml up -d
```


## Requirements

### Person Registry

- A registry must be implemented containing the basic management fuctionalities: creation and listing.
- On delete cases, all person transactions must be erased.
- The category record must contain:
    - Identifier (an unique value, automatically generated)
    - Description
    - Age (positive integer)

### Category Registry

- A registry must be implemented containing the basic management fuctionalities: creation and listing.
- The category record must contain:
    - Identifier (an unique value, automatically generated)
    - Description
    - Purpose (income/expense/both)

### Transaction registry

- A registry must be implemented containing the basic management functionalities: creation and listing.
- If the user informs a minor (under 18), only expenses must be accepted.
- The transaction record must contain:
    - Identifier (an unique value, automatically generated)
    - Description
    - Value (positive decimal)
    - Kind (income/expense)
    - Category (restrict the use of categories according to the value defined on field *Purpose*)
    - Person

### Query totals by person

- It must list all registered people, displaying the total incomes, expenses and balance (income - expense) of each one.
- At the end of the previous list, it should display the grand total of all people, including total incomes, total expenses and net balance.

### Query totals by category

- It must list all registered categories, displaying the total incomes, expenses and balance (income - expense) of each one.
- At the end of the previous list, it should display the grand total of all categories, including total incomes, total expenses and net balance.