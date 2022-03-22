using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timestamp.Core.Validation;

namespace Timestamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly List<ValidationResult> _notifications = new List<ValidationResult>();
        private void NotifyModelStateErrors()
        {
            foreach (var key in ModelState.Keys)
            {
                if (string.IsNullOrEmpty(key))
                    continue;

                var errors = ModelState[key].Errors;

                foreach (var erro in errors)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    NotifyError(new ValidationResult(key, erroMsg));
                }
            }
        }

        private void NotifyError(ValidationResult message) => _notifications.Add(message);

        protected bool ValidModelState()
        {
            if (ModelState.IsValid)
                return true;

            NotifyModelStateErrors();

            return false;
        }

        protected new IActionResult BadRequest()
        {
            if (_notifications.Count > 0)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notifications.Select(x => x)
                });
            }
            throw new Exception();
        }
    }
}
