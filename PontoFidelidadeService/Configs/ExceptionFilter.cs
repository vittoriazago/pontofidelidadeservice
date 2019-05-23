using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PontoFidelidade.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PontoFidelidade.WebApi.Configs
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var ex = context.Exception;
            var message = ex.Message;

            switch (ex)
            {
                case SemPermissaoAlteracaoException spex:
                    status = HttpStatusCode.PreconditionFailed;
                    break;
                case LojaNaoEncontradaException lnex:
                    status = HttpStatusCode.NotFound;
                    break;
                case UsuarioInvalidoException uiex:
                    status = HttpStatusCode.Unauthorized;
                    break;
                case ClienteJaCadastradoException cex:
                    status = HttpStatusCode.Conflict;
                    break;
                case EntidadeInvalidaException eiex:
                    status = HttpStatusCode.BadRequest;
                    break;
                case SaldoInsuficienteException eiex:
                    status = HttpStatusCode.PreconditionFailed;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ocorreu um erro! Tente novamente mais tarde!";
                    break;
            }

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(new { Message = message });

        }
    }
}