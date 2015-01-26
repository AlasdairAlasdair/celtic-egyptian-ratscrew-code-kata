using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.SnapValidation
{
    internal class AggregateSnapValidator
    {
        private readonly IEnumerable<ISnapValidator> m_Validators;

        public AggregateSnapValidator(IEnumerable<ISnapValidator> validators)
        {
            m_Validators = validators;
        }

        internal bool DoesStackContainSnap(Stack stack)
        {
            return m_Validators.Any(validator => validator.DoesStackContainSnap(stack));
        }
    }
}
