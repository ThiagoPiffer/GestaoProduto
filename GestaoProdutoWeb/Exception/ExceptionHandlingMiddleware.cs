using Newtonsoft.Json;
using System.Net;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            if (context.Response.StatusCode == 500)
                context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                status = (int)HttpStatusCode.InternalServerError,
                message = "Ocorreu um erro interno. Por favor, tente novamente mais tarde.",
                detailedMessage = ex.Message,  // Adicione esta linha para incluir a mensagem original da exceção
                stackTrace = ex.StackTrace     // Opcional: adicione esta linha se quiser incluir a pilha de chamadas
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
