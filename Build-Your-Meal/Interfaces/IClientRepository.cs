using Build_Your_Meal.Models;

namespace Build_Your_Meal.Interfaces;

public interface IClientRepository
{
    List<Client> GetAllClients();
    Client GetClient(int id);
    bool ClientExist(int id);
    bool CreateClient(Client client);
    bool Save();
    bool DeleteClient(int id);
    bool UpdateClient(Client client);
}
