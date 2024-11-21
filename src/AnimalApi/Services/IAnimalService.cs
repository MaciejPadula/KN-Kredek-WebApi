using AnimalApi.Models;

namespace AnimalApi.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
    IEnumerable<Animal> GetAnimalsSorted(SortingDirection sortingDirection);
    Animal? GetAnimal(string name);
    void AddAnimal(Animal animal);
    void UpdateAnimal(Animal animal);
    void DeleteAnimal(string name);
}
