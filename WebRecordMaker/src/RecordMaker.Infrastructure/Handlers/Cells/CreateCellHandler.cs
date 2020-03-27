using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Cells;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Cells
{
    public class CreateCellHandler : ICommandHandler<CreateCell>
    {
        private readonly IHandler _handler;
        private readonly ITableService _tableService;

        public CreateCellHandler(IHandler handler, ITableService tableService)
        {
            _handler = handler;
            _tableService = tableService;
        }


        public async Task HandleAsync(CreateCell command)
            => await _handler
                .Run(async () =>
                {
                    await _tableService.AddCellAsync(command.TableId, command.UserId,
                        command.RowNumber, command.ColumnLetter, command.Text);
                })
                .ExecuteAsync();


    }
}