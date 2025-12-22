using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.API.Interfaces;
using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.Application.Services;

public class TransactionService(IPersonRepository personRepository, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository) : ITransactionService
{
    public IEnumerable<TransactionDto> ListTransactions()
    {
        return transactionRepository.GetMany().Select(transaction => (TransactionDto)transaction);
    }

    public Transaction GetTransaction(int id)
    {
        return transactionRepository.GetOneById(id);
    }

    public TransactionDto InsertTransaction(TransactionDto dto)
    {
        var category = categoryRepository.GetOneById(dto.CategoryId);
        if (category is null)
            throw new Exception("Category not found");

        var person = personRepository.GetOneById(dto.PersonId);
        if (person is null)
            throw new Exception("Person not found");

        var transaction = (Transaction)dto;
        transaction.Category = category;
        transaction.Person = person;

        return (TransactionDto)transactionRepository.Insert(transaction);
    }

    public bool DeleteTransaction(int id)
    {
        return transactionRepository.Delete(id);
    }
}