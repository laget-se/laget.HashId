namespace laget.HashId.Exceptions
{
    public class HashIdNotRegisteredException : Exception
    {
        public HashIdNotRegisteredException()
            : base("HashIds has not been properly registered\nUse the ContainerBuilderExtension RegisterHashId in your Program.cs in order to user HashIds")
        {
        }
    }
}