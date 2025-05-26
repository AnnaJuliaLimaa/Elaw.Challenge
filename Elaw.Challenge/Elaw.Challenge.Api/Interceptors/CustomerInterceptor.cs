using FluentValidation;
using Elaw.Challenge.Application;
using Microsoft.AspNetCore.Mvc;

namespace Elaw.Challenge.Api
{
    public static class CustomerInterceptor
    {
        public static WebApplication ConfigureControllers(this WebApplication app)
        {
            app.MapGet(Values.Route.ClienteId, async (IValidator<CustomerViewModel> validator, ICustomerApplication service, Guid id) =>
            {
                var customer = service.GetById(id);

                if (customer == null)
                    return Results.NotFound("Cliente não encontrado");

                return Results.Ok(customer);

            });

            app.MapPost(Values.Route.Clientes, async (IValidator<CustomerViewModel> validator, ICustomerApplication service, [FromBody] CustomerViewModel customer) =>
            {
                var result = await validator.ValidateAsync(customer);

                if (!result.IsValid)
                {
                    return Results.ValidationProblem(result.ToDictionary());
                }

                service.Add(customer);

                return Results.Created($"/{customer.Id}", customer);
            });

            app.MapPut(Values.Route.ClienteId, async (IValidator<CustomerViewModel> validator, ICustomerApplication service, Guid id, [FromBody] CustomerViewModel customer) =>
            {
                customer.SetId(id);

                var result = await validator.ValidateAsync(customer);

                if (!result.IsValid)
                {
                    return Results.ValidationProblem(result.ToDictionary());
                }

                var updated = service.Update(id, customer);

                return Results.Created($"/{updated.Id}", customer);
            });

            app.MapDelete(Values.Route.ClienteId, async (IValidator<CustomerViewModel> validator, ICustomerApplication service, Guid id) =>
            {
                service.Delete(id);

                return Results.Ok($"Deletado com Sucesso");
            });

            return app;
        }
    }
}