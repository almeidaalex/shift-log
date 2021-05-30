using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using ShiftLogger.Infra;

namespace ShiftLogger.Pipelines
{
    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly TextWriter _writer;
        private readonly ShiftLoggerContext _context;

        public GenericRequestPostProcessor(TextWriter writer, ShiftLoggerContext context)
        {
            _writer = writer;
            _context = context;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
            await _writer.WriteLineAsync("- All Done");
        }
    }
}