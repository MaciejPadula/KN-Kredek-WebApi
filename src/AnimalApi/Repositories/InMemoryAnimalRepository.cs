using AnimalApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace AnimalApi.Repositories;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly List<Animal> _animals = [];

    private readonly IMemoryCache _memoryCache;

    public InMemoryAnimalRepository(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void DeleteAnimal(string name)
    {
        var animal = _animals.FirstOrDefault(a => a.Name == name);
        if (animal != null)
        {
            _animals.Remove(animal);
        }
    }

    public Animal? GetAnimal(string name)
    {
        return _memoryCache.GetOrCreate(
            $"{nameof(GetAnimal)}_{name}",
            entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                return GetAnimalInternal(name);
            });
    }

    private Animal? GetAnimalInternal(string name)
    {
        return _animals.FirstOrDefault(a => a.Name == name);
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return _memoryCache.GetOrCreate(
            nameof(GetAnimals),
            _ => _animals) ?? [];
    }

    public void UpdateAnimal(Animal animal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Name == animal.Name);
        if (existingAnimal != null)
        {
            existingAnimal.EyesCount = animal.EyesCount;
            existingAnimal.LegsCount = animal.LegsCount;
        }
    }
}
