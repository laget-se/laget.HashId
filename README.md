# laget.HashIds
Simple library for using hashed ids in DTOs

Based on https://hashids.org/

## Configuration
> This example is shown using Autofac since this is the go-to IoC for us.

```c#
await Host.CreateDefaultBuilder()
    .ConfigureContainer<ContainerBuilder>((context, builder) =>
    {
        builder.RegisterHashId();
    })
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .Build()
    .RunAsync();
```

Salts for the hashes will be loaded from the config file expecting the following format 
```json
{
    /* ..., */
    "HashIds": {
        "DefaultHashVersion": "xx",
        "SaltVersions": {
            "xx": "yyyy..."
        }
    }
}
```
Where 'xx' is a 2 character version code and 'yyyy' is the salt (of unlimited size) used by that version

## Usage

### Basic usage
```c#
    var hashId = HashId.FromLong(42);

    var longId = hash.ToLong();
```

### Usage in a class
```c#
    public class Dto 
    {
        public HashId Id { get; set; }
    }

    // Serializes to { Id: "somehash" }
```


### Example when used with the laget.Mapper nuget package
```c#
    public class ModelMapper : IMapper
    {
        [MapperMethod]
        public Dto ModelToDto(Model model) => new() { Id = model.Id.ToHashId() };

        [MapperMethod]
        public Model DtoToModel(Dto dto) => new() { Id = dto.Id.ToLong() };
    }
```