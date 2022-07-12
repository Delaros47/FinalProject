using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal.CrossCuttingConcerns.Validation;
using Universal.Utilities.Interceptors;

namespace Universal.Utilities.Aspects.Autofac.Validation
{
    #region Comment
    /*
     * Type _validatorType takes from our attribute typeof(ProductValidator) exactly get ProductValidator and check it if
     * it is not Validator type then it gives us an error
     */
    #endregion
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("It is not a Validation Class");
            }

            _validatorType = validatorType;
        }
        #region Comment
        /*
         Activator.CreateInstance is reflection it creates an instance from ProductValidator in runtime then
        entityType goes to ProductValidator and from it AbstractValidator<Product> gets the generic argument means Product
        entities go to method for example Add method it gets parameters and with foreach and validates it
         */
        #endregion
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
