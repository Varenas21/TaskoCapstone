using Microsoft.AspNetCore.Mvc;


namespace TaskoCapstone.Models
{
    public class TimerService : IHostedService
    {
        private readonly ILogger<TimerService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TimeSpan _timeout = TimeSpan.FromMinutes(10); // set the timeout to 10 minutes
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(1); // set the interval to 1 second
        private readonly PeriodicTimer _timer;
        private DateTime _startTime;

        public TimerService(ILogger<TimerService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _timer = new PeriodicTimer(_interval); // create a new PeriodicTimer with the specified interval
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timer service started.");
            _startTime = DateTime.Now; // get the current time as the start time
            Task.Run(async () => await DoWorkAsync(cancellationToken)); // run the DoWorkAsync method in a background task
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timer service stopped.");
            _timer.Dispose(); // dispose the timer
            return Task.CompletedTask;
        }

        private async Task DoWorkAsync(CancellationToken cancellationToken)
        {
            while (await _timer.WaitForNextTickAsync(cancellationToken)) // wait for the next tick of the timer
            {
                try
                {
                    var currentTime = DateTime.Now; // get the current time
                    var elapsedTime = currentTime - _startTime; // calculate the elapsed time
                    _logger.LogInformation($"Elapsed time: {elapsedTime}");

                    if (elapsedTime >= _timeout) // check if the timeout is reached
                    {
                        var referer = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString(); // get the referer URL
                        _logger.LogInformation($"Redirecting to {referer}");
                        var result = new RedirectResult(referer); // create a new RedirectResult with the referer URL
                        await result.ExecuteResultAsync(new ActionContext // execute the result
                        {
                            HttpContext = _httpContextAccessor.HttpContext
                        });
                        break; // break the loop
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred in the timer service.");
                }
            }
        }
    }
}
