//using FluentValidation;
//using SimpleInjector;
//using Wallet.Authentication.Api.Controller.Mutation;
//using Wallet.Authentication.Api.Controller.Query;

//public class Bootstrapper
//{
//    public void Inject(Container container)
//    {
//        InjectBaseDependencies(container);
//        InjectMediatorDependencies(container);
//        InjectValidatorDependencies(container);
//        InjectRepositoriesDependencies(container);
//        InjectGraphQLDependencies(container);
//    }

//    private void InjectBaseDependencies(Container container)
//    {
//    }

//    private void InjectMediatorDependencies(Container container)
//    {

//    }

//    private void InjectValidatorDependencies(Container container)
//    {
//        var assemblies = new[] { typeof(IValidator<>).Assembly };
//        container.Collection.Register(typeof(IValidator<>), assemblies);
//    }

//    private void InjectRepositoriesDependencies(Container container)
//    {
//    }

//    private void InjectGraphQLDependencies(Container container)
//    {
//        container.Register<AuthenticationQuery>(Lifestyle.Singleton);
//        container.Register<AuthenticationMutation>(Lifestyle.Singleton);
//    }
//}