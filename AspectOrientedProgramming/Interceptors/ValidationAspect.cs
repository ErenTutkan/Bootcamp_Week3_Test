using AspectOrientedProgramming.CrossCuttingConcern;
using Castle.DynamicProxy;
using FluentValidation;

namespace AspectOrientedProgramming.Interceptors
{
    public class ValidationAspect:MethodInterception 
    {
        private readonly Type _validator;

        public ValidationAspect(Type validator)
        {
            if (!typeof(IValidator).IsAssignableFrom(validator))
                throw new Exception("Doğrulama Türü Yanlış ");
            _validator = validator;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator =  (IValidator)Activator.CreateInstance(_validator);
            var entityType=_validator.BaseType.GetGenericArguments()[0];
            var entities=invocation.Arguments.Where(x=>x.GetType() == entityType).ToList();
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
       

    }
}
