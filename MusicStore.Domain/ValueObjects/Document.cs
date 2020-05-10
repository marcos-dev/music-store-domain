using Flunt.Validations;
using MusicStore.Domain.Enums;
using MusicStore.Shared.ValueObjects;

namespace MusicStore.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Invalid Document"));
        }

        public string Number { get; private set; }

        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            return (Type == EDocumentType.CPF && Number.Length == 11) || (Type == EDocumentType.RG && Number.Length == 9);
        }
    }
}
