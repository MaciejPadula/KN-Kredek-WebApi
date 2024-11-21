using AnimalApi.Models;

namespace AnimalApi.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    Animal? GetAnimal(string name);
    void AddAnimal(Animal animal);
    void UpdateAnimal(Animal animal);
    void DeleteAnimal(string name);
}
