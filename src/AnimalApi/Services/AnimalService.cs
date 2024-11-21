using AnimalApi.Models;
using AnimalApi.Repositories;

namespace AnimalApi.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return _animalRepository.GetAnimals();
    }

    public void AddAnimal(Animal animal)
    {
        _animalRepository.AddAnimal(animal);
    }

    public void UpdateAnimal(Animal animal)
    {
        _animalRepository.UpdateAnimal(animal);
    }

    public Animal? GetAnimal(string name)
    {
        return _animalRepository.GetAnimal(name);
    }

    public void DeleteAnimal(string name)
    {
        _animalRepository.DeleteAnimal(name);
    }

    public IEnumerable<Animal> GetAnimalsSorted(SortingDirection sortingDirection)
    {
        var animals = _animalRepository.GetAnimals();

        if (sortingDirection == SortingDirection.Ascending)
        {
            return animals.OrderBy(a => a.Name);
        }

        if (sortingDirection == SortingDirection.Descending)
        {
            return animals.OrderByDescending(a => a.Name);
        }

        throw new InvalidOperationException("Invalid sorting direction.");
    }
}
