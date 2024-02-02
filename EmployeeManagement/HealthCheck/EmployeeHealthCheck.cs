using EmployeeManagement.Controller;
using EmployeeManagement.Model;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EmployeeManagement.HealthCheck
{
    public class EmployeeHealthCheck : IHealthCheck
    {
        private readonly TodoContext _context;

        public EmployeeHealthCheck(TodoContext context)
        {
            _context = context;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            EmployeeController employee = new EmployeeController(_context);
            
            if (_context.TodoItems.ToList().Count > 1)
            {
                return Task.FromResult(
                HealthCheckResult.Healthy("A healthy result."));
            }
            return Task.FromResult(
       new HealthCheckResult(
           context.Registration.FailureStatus, "An unhealthy result."));
        }
    }
}
