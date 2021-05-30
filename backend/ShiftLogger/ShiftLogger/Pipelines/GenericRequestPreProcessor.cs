using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using ShiftLogger.Application;

namespace ShiftLogger.Pipelines
{
    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : IRequestValidator
    {
        private readonly TextWriter _writer;

        public GenericRequestPreProcessor(TextWriter writer)
        {
            _writer = writer;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            return _writer.WriteLineAsync("- Starting Up");
        }
    }
}