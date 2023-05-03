using MediatR;


namespace ApiSystemCQRSAplication.GyfSystem.Commands.DeleteSystem
{
    public class DeleteSystemCommand
    {
        public class DeleteSystem : IRequest
        {
            /// <summary>
            /// Identificador del sistema a eliminar.
            /// </summary>
            public string? IdSystem { get; set; }
        }
    }
}
