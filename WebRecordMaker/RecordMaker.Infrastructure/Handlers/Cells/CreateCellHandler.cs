using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Cells;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Cells
{
    public class CreateCellHandler : ICommandHandler<CreateCell>
    {
        private readonly ITableService _tableService;

        public CreateCellHandler(ITableService tableService)
        {
            _tableService = tableService;
        }
        
        public async Task HandleAsync(CreateCell command)
        {
          await _tableService.AddCellAsync(command.TableId, command.UserId,
                command.RowNumber, command.ColumnLetter, command.Text);
        }
    }
}