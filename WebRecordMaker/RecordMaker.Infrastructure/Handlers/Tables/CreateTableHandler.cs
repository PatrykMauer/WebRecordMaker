using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Tables;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Tables
{
    public class CreateTableHandler:ICommandHandler<CreateTable>
    {
        private readonly ITableService _tableService;
        
        public CreateTableHandler(ITableService tableService)
        {
            _tableService = tableService;
        }
        public async Task HandleAsync(CreateTable command)
        {
            await _tableService.AddAsync(command.UserId,command.Size);
        }
    }
}