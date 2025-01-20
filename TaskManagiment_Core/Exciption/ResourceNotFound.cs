using System.Runtime.Serialization;

namespace TaskManagiment_Core.Exciption
{
    [Serializable]
    public class ResourceNotFound : Exception
    {
        public ResourceNotFound() { }

        public ResourceNotFound(Type type) : base($"{type} is missing") { }

        protected ResourceNotFound(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResourceNotFound(string? message) : base(message) { }

        public ResourceNotFound(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
