using System.ComponentModel;

namespace Cooper.Infrastructure.Enums
{
    internal enum ErrorMessages
    {
        [Description("El Id provisto no coincide con el Id de la entidad")]
        IdDontMatch,
        [Description("No se encontro ninguna entidad con el Id provisto")]
        EntityNotFound
    }
}
