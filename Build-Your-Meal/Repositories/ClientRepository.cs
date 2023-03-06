using Build_Your_Meal.Data;
using Build_Your_Meal.Interfaces;
using Build_Your_Meal.Models;
using Microsoft.EntityFrameworkCore;

namespace Build_Your_Meal.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DataContext _context;

    public ClientRepository(DataContext context)
    {
        _context = context;
    }


    public bool ClientExist(int id)
    {
        return _context.Clients.Any(c => c.Id == id);
    }

    public bool CreateClient(Client client)
    {
        _context.Clients.Add(client);
        return Save();
    }

    public bool DeleteClient(int id)
    {
        _context.Clients.Where(c => c.Id == id).ExecuteDelete();
        return Save();
    }

    public List<Client> GetAllClients()
    {
        return _context.Clients.ToList();
    }

    public Client GetClient(int id)
    {
        return _context.Clients.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdateClient(Client client)
    {
        _context.Clients.Update(client);
        return Save();
    }
}
