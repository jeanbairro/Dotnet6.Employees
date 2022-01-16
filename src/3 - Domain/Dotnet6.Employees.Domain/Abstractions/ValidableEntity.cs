using System.Collections.Generic;
using System.Linq;

namespace Dotnet6.Employees.Domain.Abstractions
{
    public abstract class ValidableEntity
    {
        private List<string> _errors;

        public ValidableEntity()
        {
            _errors = new List<string>();
        }

        public void AddError(string erro)
        {
            _errors ??= new List<string>();
            _errors.Add(erro);
        }

        public void AddError(IEnumerable<string> errors)
        {
            errors ??= new List<string>();
            foreach (var error in errors) AddError(error);
        }

        public List<string> GetErrors() => _errors;

        public virtual bool IsValid()
        {
            if (_errors == null) return false;
            return !_errors.Any();
        }
    }
}